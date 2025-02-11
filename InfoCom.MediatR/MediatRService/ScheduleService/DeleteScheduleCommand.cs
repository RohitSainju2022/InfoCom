using System;
using System.Net;
using InfoCom.Data.InfoComDbContext;
using InfoCom.Share.Constant;
using InfoCom.Share.ServiceResponse;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InfoCom.MediatR.MediatRService.ScheduleService
{
    public record DeleteScheduleCommand(int Id) : IRequest<ServiceResponse<bool>>;

    public record DeleteScheduleCommandHandler(IDbContextFactory<ApplicationDbContext> DbContextFactory,
        IMediator Mediator) :
        IRequestHandler<DeleteScheduleCommand, ServiceResponse<bool>>
    {
        public async Task<ServiceResponse<bool>> Handle(DeleteScheduleCommand request,
            CancellationToken cancellationToken)
        {
            ServiceResponse<bool> response = new();
            List<string> errors = new();
            using (var dbContext = await DbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var dbSchedule = await dbContext.Schedules
                    .Where(u => u.Id == request.Id && !u.IsDeleted)
                    .FirstOrDefaultAsync(cancellationToken);

                if (dbSchedule != null)
                {
                    dbSchedule.IsDeleted = true;
                    var result = await dbContext.SaveChangesAsync(cancellationToken);
                    if (result != 0)
                    {
                        response.Result = true;
                        response.Type = ServiceResponseTypes.SUCCESS;
                    }
                    else
                    {
                        //response.Type = ServiceResponseTypes.ERROR;
                        response.ErrorCode = (HttpStatusCode.InternalServerError).ToString();
                        response.Errors = errors;
                    }
                }
                else
                {
                    response.Result = false;
                    response.Type = ServiceResponseTypes.ERROR;
                    response.ErrorCode = (HttpStatusCode.InternalServerError).ToString();
                    response.Errors = errors;
                }
            }
            return response;
        }
    }
}
