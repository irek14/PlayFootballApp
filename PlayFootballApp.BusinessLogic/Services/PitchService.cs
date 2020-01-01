using PlayFootballApp.BuisnessEntities.Entities;
using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Models.Pitch;
using PlayFootballApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

                    for (int i = 0; i < weekDays.Length - 1; i++)
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

                    _context.SaveChanges();

                    transaction.Commit();
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

        }
    }
}
