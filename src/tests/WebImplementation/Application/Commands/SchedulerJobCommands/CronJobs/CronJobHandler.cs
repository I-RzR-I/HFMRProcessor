// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-04-01 18:49
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-01 18:51
// ***********************************************************************
//  <copyright file="CronJobHandler.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

#endregion

namespace WebImplementation.Application.Commands.SchedulerJobCommands.CronJobs
{
    public class CronJobHandler : IRequestHandler<CronJobCommand>
    {
        public async Task<Unit> Handle(CronJobCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Background job using MediatR command");

            return await Task.FromResult(Unit.Value);
        }
    }
}