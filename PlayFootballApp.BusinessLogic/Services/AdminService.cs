using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlayFootballApp.BuisnessEntities.Entities;

namespace PlayFootballApp.BusinessLogic.Services
{
    public class AdminService : IAdminService
    {
        PlayFootballContext _context;

        public AdminService(PlayFootballContext context)
        {
            _context = context;
        }

        public bool AddPitchAvability(DateTime startDate, DateTime endDate)
        {
            if(endDate < startDate || endDate == DateTime.MinValue || startDate == DateTime.MinValue)
                return false;

            DateTime currentDate;
            try
            {
                currentDate = _context.PitchAvailability.Max(x => x.OpenDate);
            }
            catch(Exception e)
            {
                currentDate = startDate;
            }

            if (currentDate < startDate)
                currentDate = startDate;

            var openHours = _context.PitchOpenHours;

            while(currentDate <= endDate)
            {
                int day = (int)currentDate.DayOfWeek;
                if (day == 0) //because Sunday is 0 at enum and at DB is 7
                    day = 7;

                var currentOpenHours = openHours.Where(x => x.WeekDay == day);

                foreach(PitchOpenHours hours in currentOpenHours)
                {
                    _context.PitchAvailability.Add(new PitchAvailability()
                    {
                        Id = Guid.NewGuid(),
                        OpenDate = currentDate,
                        PitchId = hours.PitchId,
                        PitchOpenHoursId = hours.Id
                    });
                }

                currentDate = currentDate.AddDays(1);
            }

            _context.SaveChanges();

            return true;
        }
    }
}
