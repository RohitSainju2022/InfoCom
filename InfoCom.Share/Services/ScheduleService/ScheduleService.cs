using InfoCom.Share.ApiRequestService;
using InfoCom.Share.Constant;
using InfoCom.Share.Services.CoreServices;
using InfoCom.Ui.Models.Models;

namespace InfoCom.Share.Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<List<ScheduleModel>> GetSchedules();
        Task<ScheduleModel> GetScheduleById(int id);
        Task<(bool, string)> PostSchedule(ScheduleModel model);
        Task<(bool, string)> UpdateSchedule(ScheduleModel model);
        Task<bool> DeleteSchedule(int id);
        //Task<List<ScheduleModel>> GetSchedulesByFilter(ScheduleModel filterModel);
    }
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRequest _scheduleRequest;
        private readonly ISessionState<AuthenticationModel> _session;
        private static readonly string LocalStorageKey = StorageKeyConstant.StorageKeyName;

        public ScheduleService(IScheduleRequest Schedulerequest, ISessionState<AuthenticationModel> session)
        {
            _scheduleRequest = Schedulerequest;
            _session = session;
        }
        public async Task<List<ScheduleModel>> GetSchedules()
        {
            var response = await _scheduleRequest.GetSchedules();
            if (response.Type == ServiceResponseTypes.SUCCESS)
            {
                return response.Result;
            }
            return new List<ScheduleModel>();
        }

        public async Task<ScheduleModel> GetScheduleById(int id)
        {
            var response = await _scheduleRequest.GetScheduleById(id);
            if (response.Type == ServiceResponseTypes.SUCCESS)
            {
                return response.Result;
            }
            return new ScheduleModel();
        }

        public async Task<(bool, string)> PostSchedule(ScheduleModel model)
        {
            var response = await _scheduleRequest.PostSchedule(model);
            if (response.Result == null)
            {
                return (false, response.ErrorMessage);
            }
            return (true, response.Result.Id.ToString());
        }

        public async Task<(bool, string)> UpdateSchedule(ScheduleModel model)
        {
            var response = await _scheduleRequest.UpdateSchedule(model);
            if (response.Result == null)
            {
                return (false, response.ErrorMessage);
            }
            return (true, response.Result.Id.ToString());
        }

        public async Task<bool> DeleteSchedule(int id)
        {
            var response = await _scheduleRequest.DeleteSchedule(id);
            return response.Result;
        }

        //public async Task<List<ScheduleModel>> GetSchedulesByFilter(ScheduleModel filterModel)
        //{
        //    var response = await _scheduleRequest.GetSchedulesByFilter(filterModel);
        //    if (response.Type == ServiceResponseTypes.SUCCESS)
        //    {
        //        return response.Result;
        //    }
        //    return new List<ScheduleModel>();
        //}
    }
}
