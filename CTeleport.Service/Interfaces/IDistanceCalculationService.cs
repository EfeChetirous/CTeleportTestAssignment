using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Service.Interfaces
{
    public interface IDistanceCalculationService
    {
        Task<Result> GetDistanceAsync(DistanceCalculationRequestModel requestModel);
    }
}
