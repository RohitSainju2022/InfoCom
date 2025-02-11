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
    public record UpdateScheduleCommand(int Id, ScheduleModel ScheduleModel) : IRequest<ServiceResponse<ScheduleModel>>;

    public record UpdateScheduleCommandHandler(IDbContextFactory<ApplicationDbContext> DbContextFactory,
        IMapper Mapper, IMediator Mediator)
        : IRequestHandler<UpdateScheduleCommand, ServiceResponse<ScheduleModel>>
    {
        public async Task<ServiceResponse<ScheduleModel>> Handle(UpdateScheduleCommand request,
            CancellationToken cancellationToken)
        {
            ServiceResponse<ScheduleModel> response = new();
            List<string> errors = new();
            using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var dbSchedule = await dbContext.Schedules
                    .Where(u => u.Id == request.Id && !u.IsDeleted)
                    .FirstOrDefaultAsync(cancellationToken);

                if (dbSchedule != null)
                {
                    Mapper.Map(request.ScheduleModel, dbSchedule);
                    dbContext.Entry(dbSchedule).State = EntityState.Modified;
                    var result = await dbContext.SaveChangesAsync(cancellationToken);
                    if (result != 0)
                    {
                        response.Result = request.ScheduleModel;
                        response.Type = ServiceResponseTypes.SUCCESS;
                    }
                    else
                    {
                        //errors.Add(UserConstant.User_Update_Error);
                        response.Type = ServiceResponseTypes.ERROR;
                        response.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();
                        response.Errors = errors;
                    }
                }

                else
                {
                    errors.Add(ScheduleConstant.Schedule_NotFound);
                    response.Type = ServiceResponseTypes.NOTFOUND;
                    response.ErrorCode = ((int)HttpStatusCode.NotFound).ToString();
                    response.Errors = errors;
                }
            }
            return response;

        }

    }
}
