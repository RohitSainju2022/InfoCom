using System.Net;
using AutoMapper;
using InfoCom.Data.InfoComDbContext;
using InfoCom.Share.Constant;
using InfoCom.Share.ServiceResponse;
using InfoCom.Ui.Models.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.MediatR.MediatRService.ScheduleService
{
    public  record GetScheduleQuery : IRequest<ServiceResponse<List<ScheduleModel>>>;
    public record GetSchedulerHandler(IDbContextFactory<ApplicationDbContext> DbContextfactory,
        IMapper Mapper, IMediator Mediator) :
        IRequestHandler<GetScheduleQuery, ServiceResponse<List<ScheduleModel>>>
    {
        public async Task<ServiceResponse<List<ScheduleModel>>> Handle(GetScheduleQuery request,
            CancellationToken cancellationToken)
        {
            ServiceResponse<List<ScheduleModel>> response = new();
            List<string> errors = new();
            using (var dbContext = await DbContextfactory.CreateDbContextAsync(cancellationToken))
            {
                var dbSchedules = await dbContext.Schedules
                    .Where(u => !u.IsDeleted)
                    .ToListAsync(cancellationToken);
                if (dbSchedules.Count > 0)
                {
                    response.Result = Mapper.Map<List<ScheduleModel>>(dbSchedules);
                    response.Type = ServiceResponseTypes.SUCCESS;
                }
                else
                {
                    errors.Add(ScheduleConstant.Schedule_NotFound);
                    response.Type = ServiceResponseTypes.NOTFOUND;
                    response.ErrorCode = (HttpStatusCode.NotFound).ToString();
                    response.Errors = errors;
                }
            }
            return response;
        }
    }
}
