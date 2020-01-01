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
    }
}
