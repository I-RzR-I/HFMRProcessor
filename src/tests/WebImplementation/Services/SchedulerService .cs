// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-03-30 18:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-03-30 19:07
// ***********************************************************************
//  <copyright file="SchedulerService .cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Threading.Tasks;
using MediatR;
using WebImplementation.Abstractions;
using WebImplementation.Application.Commands.SchedulerJobCommands.CronJobs;

#endregion

namespace WebImplementation.Services
{
    public class SchedulerService : ISchedulerService
    {
        private readonly IMediator _mediator;

        public SchedulerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task DoWork()
        {
            Console.WriteLine("Background job based on service");

            return Task.CompletedTask;
        }

        public async Task DoWorkAsync()
        {
            await _mediator.Send(new CronJobCommand());
        }

        /// <inheritdoc />
        public void Invoke(string message)
        {
            Console.WriteLine($"Background job on service, invoke from {message}");
        }
    }
}