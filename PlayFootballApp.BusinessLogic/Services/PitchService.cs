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
                        var record = allOpenHours.Where(x => x.WeekDay == int.Parse(weekDays[i]) && x.EndHour == endHours[i] && x.StartHour == startHours[i]).FirstOrDefault();

                        if (record == null)
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

            pitch.PitchOpenHours.OrderBy(x=>x.WeekDay);

            foreach(var openHour in pitch.PitchOpenHours)
            {
                result.EndHours += openHour.EndHour + ";";
                result.StartHours += openHour.StartHour + ";";
                result.WeekDays += ((int)openHour.WeekDay).ToString() + ";";
            }

            return result;
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
                        var record = allOpenHours.Where(x => x.WeekDay == int.Parse(weekDays[i]) && x.EndHour == endHours[i] && x.StartHour == startHours[i]).FirstOrDefault();

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
