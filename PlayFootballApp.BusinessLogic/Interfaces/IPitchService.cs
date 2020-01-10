using PlayFootballApp.BusinessLogic.Models.Home;
using PlayFootballApp.BusinessLogic.Models.Pitch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayFootballApp.BusinessLogic.Interfaces
{
    public interface IPitchService
    {
        Task AddPitch(PitchCreateViewModel pitch);
        PitchCreateViewModel GetPitchWithId(Guid id);
        Task UpdatePitch(PitchCreateViewModel pitch);
        List<TablePitchViewModel> GetAllPitches();
        void DeletePitch(Guid pitchId);
        FindEventsViewModel GetPitchAvability(Guid userId, DateTime startDate, DateTime endDate, int spotNumber, decimal localisationX, decimal localisationY, int distanceInMeters);
        bool ReserveSpot(Guid avabilityId, int spots, Guid userId);
        bool ResignSpot(Guid avabilityId, Guid userId);
    }
}
