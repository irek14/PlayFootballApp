using PlayFootballApp.BuisnessEntities.Entities;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Models.Pitch;
using PlayFootballApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlayFootballApp.BusinessLogic.Models.Home;

namespace PlayFootballApp.BusinessLogic.Services
{
    public class PitchService : IPitchService
    {
        PlayFootballContext _context;

        public PitchService(PlayFootballContext context)
        {
            _context = context;
        }

        public async Task AddPitch(PitchCreateViewModel pitch)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Pitch newPitch = new Pitch()
                    {
                        Id = Guid.NewGuid(),
                        LocalisationX = pitch.LocalisationX,
                        LocalisationY = pitch.LocalisationY,
                        Name = pitch.Name,
                        SpotNumber = pitch.SpotNumber
                    };
                    _context.Pitch.Add(newPitch);

                    string[] weekDays = pitch.WeekDays.Split(";");
                    string[] startHours = pitch.StartHours.Split(";");
                    string[] endHours = pitch.EndHours.Split(";");

                    var allOpenHours = _context.PitchOpenHours;

                    for (int i = 0; i < weekDays.Length - 1; i++)
                    {
                        var record = allOpenHours.Where(x => x.Id == newPitch.Id && x.WeekDay == int.Parse(weekDays[i]) && x.EndHour == endHours[i] && x.StartHour == startHours[i]).FirstOrDefault();

                        if (record == null)
                        {
                            PitchOpenHours openHours = new PitchOpenHours()
                            {
                                Id = Guid.NewGuid(),
                                PitchId = newPitch.Id,
                                WeekDay = int.Parse(weekDays[i]),
                                EndHour = endHours[i],
                                StartHour = startHours[i]
                            };
                            _context.PitchOpenHours.Add(openHours);
                        }
                        else
                        {
                            record.IsArchived = false;
                        }
                    }

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }

        public void DeletePitch(Guid pitchId)
        {
            Pitch pitch = _context.Pitch.Where(x => x.Id == pitchId).FirstOrDefault();

            if (pitch == null)
                return;

            pitch.IsArchived = true;
            _context.SaveChanges();
        }

        public List<TablePitchViewModel> GetAllPitches()
        {
            return (from pitch in _context.Pitch
                    where !pitch.IsArchived
                    select new TablePitchViewModel()
                    {
                        Id = pitch.Id,
                        LocalisationX = pitch.LocalisationX,
                        LocalisationY = pitch.LocalisationY,
                        Name = pitch.Name,
                        SpotNumber = (int)pitch.SpotNumber
                    }).ToList();
        }

        public List<PitchViewModel> GetPitchAvability(Guid userId)
        {
            var avability = _context.PitchAvailability.Include(x => x.Pitch).Include(x => x.PitchOpenHours)
                .Select(x => new PitchAvabilityViewModel()
                {
                    Id = x.Id,
                    Date = x.OpenDate,
                    StartHour = x.PitchOpenHours.StartHour,
                    EndHour = x.PitchOpenHours.EndHour,
                    PitchId = x.PitchId,
                    PitchName = x.Pitch.Name,
                    Spot = (int)x.Pitch.SpotNumber,
                    ReservedSpot = x.ReservedPlaces,
                    FreeSpot = (int)x.Pitch.SpotNumber - x.ReservedPlaces
                });

            var pitches = avability.Select(x => new PitchViewModel()
            {
                PitchId = x.PitchId,
                PitchName = x.PitchName,
                Spot = x.Spot
            }).Distinct().ToList();

            var myReservation = _context.Reservation.Where(x => x.UserId == userId);

            for(int i=0; i<pitches.Count(); i++)
            {
                pitches[i].PitchAvability = avability.Where(x => x.PitchId == pitches[i].PitchId).OrderBy(x=>x.Date).ThenBy(x=>x.StartHour).ToList();

                for(int j=0; j<pitches[i].PitchAvability.Count(); j++)
                {
                    if (myReservation.Any(x => x.PitchAvailabilityId == pitches[i].PitchAvability[j].Id && !x.IsArchived))
                        pitches[i].PitchAvability[j].IsBookedByMy = true;
                    else
                        pitches[i].PitchAvability[j].IsBookedByMy = false;
                }
            }

            return pitches;
        }

        public PitchCreateViewModel GetPitchWithId(Guid id)
        {
            Pitch pitch = _context.Pitch.Where(x => x.Id == id).Include(x=>x.PitchOpenHours).FirstOrDefault();

            if (pitch == null)
                return null;

            PitchCreateViewModel result = new PitchCreateViewModel()
            {
                Id = pitch.Id,
                LocalisationX = pitch.LocalisationX,
                LocalisationY = pitch.LocalisationY,
                Name = pitch.Name,
                SpotNumber = (int)pitch.SpotNumber,
                EndHours = "",
                StartHours = "",
                WeekDays = ""              
            };

            var openHours = pitch.PitchOpenHours.OrderBy(x=>((int)x.WeekDay)).ThenBy(x=>x.StartHour).Where(x=>!x.IsArchived);

            foreach(var openHour in openHours)
            {
                result.EndHours += openHour.EndHour + ";";
                result.StartHours += openHour.StartHour + ";";
                result.WeekDays += ((int)openHour.WeekDay).ToString() + ";";
            }

            return result;
        }

        public bool ReserveSpot(Guid avabilityId, int spots, Guid userId)
        {
            var avability = _context.PitchAvailability.Where(x => x.Id == avabilityId).FirstOrDefault();
           
            if (avability == null)
                return false;

            var pitch = _context.Pitch.Where(x => x.Id == avability.PitchId).First();

            if (pitch.SpotNumber - avability.ReservedPlaces < spots)
                return false;

            avability.ReservedPlaces += spots;

            _context.Reservation.Add(new Reservation()
            {
                Id = Guid.NewGuid(),
                PitchAvailabilityId = avability.Id,
                Date = DateTime.Now,
                UserId = userId,
                ReservedSpots = spots
            });

            _context.SaveChanges();

            return true;
        }

        public bool ResignSpot(Guid avabilityId, Guid userId)
        {
            var avability = _context.PitchAvailability.Where(x => x.Id == avabilityId).FirstOrDefault();

            if (avability == null)
                return false;

            var pitch = _context.Pitch.Where(x => x.Id == avability.PitchId).First();
            var reservation = _context.Reservation.Where(x => x.PitchAvailabilityId == avabilityId && x.UserId == userId).FirstOrDefault();

            if (reservation == null)
                return false;

            reservation.IsArchived = true;
            reservation.CancelDate = DateTime.Now;

            avability.ReservedPlaces -= reservation.ReservedSpots;

            _context.SaveChanges();

            return true;
        }

        public async Task UpdatePitch(PitchCreateViewModel pitch)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Pitch updatedPitch = _context.Pitch.Where(x => x.Id == pitch.Id).First();

                    updatedPitch.LocalisationX = pitch.LocalisationX;
                    updatedPitch.LocalisationY = pitch.LocalisationY;
                    updatedPitch.Name = pitch.Name;
                    updatedPitch.SpotNumber = pitch.SpotNumber;
                    _context.Pitch.Update(updatedPitch);

                    string[] weekDays = pitch.WeekDays.Split(";");
                    string[] startHours = pitch.StartHours.Split(";");
                    string[] endHours = pitch.EndHours.Split(";");

                    var allOpenHours = _context.PitchOpenHours;
                    var oldRecords = _context.PitchOpenHours.Where(x => x.PitchId == pitch.Id);
                    foreach(var record in oldRecords)
                    {
                        record.IsArchived = true;
                    }

                    for (int i = 0; i < weekDays.Length - 1; i++)
                    {
                        var record = allOpenHours.Where(x => x.PitchId == updatedPitch.Id && x.WeekDay == int.Parse(weekDays[i]) && x.EndHour == endHours[i] && x.StartHour == startHours[i]).FirstOrDefault();

                        if(record == null)
                        {
                            PitchOpenHours openHours = new PitchOpenHours()
                            {
                                Id = Guid.NewGuid(),
                                PitchId = pitch.Id,
                                WeekDay = int.Parse(weekDays[i]),
                                EndHour = endHours[i],
                                StartHour = startHours[i]
                            };
                            _context.PitchOpenHours.Add(openHours);
                        }
                        else
                        {
                            record.IsArchived = false;
                        }

                    }

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
