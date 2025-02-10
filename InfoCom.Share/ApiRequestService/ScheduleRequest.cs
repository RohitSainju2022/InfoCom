using InfoCom.Share.ApiHttpService;
using InfoCom.Share.Constant;
using InfoCom.Share.ServiceResponse;
using InfoCom.Ui.Models.Models;

namespace InfoCom.Share.ApiRequestService
{
    public interface IScheduleRequest
    {
        Task<ServiceResponse<List<ScheduleModel>>> GetSchedules();
        Task<ServiceResponse<ScheduleModel>> PostSchedule(ScheduleModel ScheduleModel);
        Task<ServiceResponse<ScheduleModel>> UpdateSchedule(ScheduleModel ScheduleModel);
        Task<ServiceResponse<ScheduleModel>> GetScheduleById(int id);
        Task<ServiceResponse<bool>> DeleteSchedule(int id);
        //Task<ServiceResponse<List<ScheduleModel>>> GetScheduleByFilter(ScheduleModel filterModel);

    }

    public class ScheduleRequest : IScheduleRequest
    {
        private readonly IHttpService _httpService;

        public ScheduleRequest(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<ServiceResponse<List<ScheduleModel>>> GetSchedules() =>
        _httpService.Get<ServiceResponse<List<ScheduleModel>>>(ApiUri.ScheduleUri);

        public async Task<ServiceResponse<ScheduleModel>?> GetScheduleById(int id) =>
         await _httpService.Get<ServiceResponse<ScheduleModel>>(
             ApiUri.ScheduleUri + ApiUri.Slash + $"{id}");

        public async Task<ServiceResponse<ScheduleModel>> PostSchedule(ScheduleModel ScheduleModel) =>
            await _httpService.Post<ScheduleModel, ServiceResponse<ScheduleModel>>(
                ApiUri.ScheduleUri, ScheduleModel);


        public async Task<ServiceResponse<bool>> DeleteSchedule(int id) =>
            await _httpService.Delete<ServiceResponse<bool>>(
                ApiUri.ScheduleUri + ApiUri.Slash + $"{id}");

        public Task<ServiceResponse<ScheduleModel>> UpdateSchedule(ScheduleModel ScheduleModel) =>
            _httpService.Put<ScheduleModel, ServiceResponse<ScheduleModel>>(
                ApiUri.ScheduleUri + ApiUri.Slash + $"{ScheduleModel.Id}", ScheduleModel);

        //public async Task<ServiceResponse<List<ScheduleModel>>> GetScheduleByFilter(ScheduleModel filterModel) =>
        //    await _httpService.Post<ScheduleModel, ServiceResponse<List<ScheduleModel>>>(
        //        ApiUri.ScheduleUri + ApiUri.Filter, filterModel);

    }
}
