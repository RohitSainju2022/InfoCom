using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfoCom.Data.InfoComDbContext;
using InfoCom.Share.Constant;
using InfoCom.Share.ServiceResponse;
using InfoCom.Ui.Models.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.MediatR.MediatRService.ScheduleService
{
    public record GetScheduleByIdQuery(int Id) : IRequest<ServiceResponse<ScheduleModel>>;
    public record GetScheduleByIdQueryHandler(IDbContextFactory<ApplicationDbContext> DbContextFactory,
        IMapper Mapper, IMediator Mediator) :
        IRequestHandler<GetScheduleByIdQuery, ServiceResponse<ScheduleModel>>
    {
        public async Task<ServiceResponse<ScheduleModel>> Handle(GetScheduleByIdQuery request,
            CancellationToken cancellationToken)
        {
            ServiceResponse<ScheduleModel> response = new();
            List<string> errors = new();
            using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var dbSchedule = await dbContext.Schedules
                    .Where(u => !u.IsDeleted && u.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);
                if (dbSchedule != null)
                {
                    response.Result = Mapper.Map<ScheduleModel>(dbSchedule);
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
