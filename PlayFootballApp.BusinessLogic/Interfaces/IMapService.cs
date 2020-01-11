using PlayFootballApp.BusinessLogic.Models.Home;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Interfaces
{
    public interface IMapService
    {
        GeoCoordinate GetClosestPitch(GeoCoordinate start, List<PitchViewModel> pitches);
        List<int> GetPitchesFurtherThan(int distance, List<PitchViewModel> pitches, GeoCoordinate start);
    }
}
