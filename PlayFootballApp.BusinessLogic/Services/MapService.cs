using PlayFootballApp.BusinessLogic.Interfaces;
using PlayFootballApp.BusinessLogic.Models.Home;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Services
{
    public class MapService : IMapService
    {
        public GeoCoordinate GetClosestPitch(GeoCoordinate start, List<PitchViewModel> pitches)
        {
            var resultCoord = new GeoCoordinate((double)pitches[0].LocalisationX, (double)pitches[0].LocalisationY);
            double minDist = start.GetDistanceTo(resultCoord);

            for(int i=1; i<pitches.Count; i++)
            {
                var eCoord = new GeoCoordinate((double)pitches[i].LocalisationX, (double)pitches[i].LocalisationY);
                double currentDist = start.GetDistanceTo(eCoord);

                if(currentDist < minDist)
                {
                    minDist = currentDist;
                    resultCoord = eCoord;
                }
            }

            return resultCoord;
        }

        public List<int> GetPitchesFurtherThan(int distance, List<PitchViewModel> pitches, GeoCoordinate start)
        {
            List<int> toDelete = new List<int>();
            for (int i = 0; i < pitches.Count; i++)
            {
                var eCoord = new GeoCoordinate((double)pitches[i].LocalisationX, (double)pitches[i].LocalisationY);

                var currentDist = start.GetDistanceTo(eCoord);

                if (currentDist > distance)
                    toDelete.Add(i);
            }

            return toDelete;
        }
    }
}
