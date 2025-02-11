using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InfoCom.Data.InfoComDbContext;
using InfoCom.Model;
using InfoCom.Share.Constant;
using InfoCom.Share.Mapper.CustomMapper;
using InfoCom.Share.ServiceResponse;
using InfoCom.Ui.Models.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.MediatR.MediatRService.ScheduleService
{    public record InsertScheduleCommand(ScheduleModel ScheduleModel) : IRequest<ServiceResponse<ScheduleModel>>;
    public record InsertScheduleCommandHandler(IDbContextFactory<ApplicationDbContext> DbContextFactory,
        IMapper Mapper, IMediator Mediator) :
        IRequestHandler<InsertScheduleCommand, ServiceResponse<ScheduleModel>>
    {
        public async Task<ServiceResponse<ScheduleModel>> Handle(InsertScheduleCommand request, CancellationToken cancellationToken)
        {
            ServiceResponse<ScheduleModel> response = new();
            List<string> errors = new();
            if (request.ScheduleModel != null)
            {
                using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
                {
                    var dbSchedule = ScheduleCustomMapper.ToEntity(new Schedule(), request.ScheduleModel);
                    dbContext.Schedules.Add(dbSchedule);
                    var result = await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            else
            {
                response.Type = ServiceResponseTypes.BADPARAMETERS;
                response.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();
                response.Errors = errors;
            }

            return response;
        }
    }
}
