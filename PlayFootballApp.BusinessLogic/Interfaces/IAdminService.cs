using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Interfaces
{
    public interface IAdminService
    {
        bool AddPitchAvability(DateTime startDate, DateTime endDate);
    }
}
