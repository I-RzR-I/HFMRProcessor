// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-03-30 18:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-03-30 19:07
// ***********************************************************************
//  <copyright file="HangFireCronDefinition.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using AppInitDefinitionDecorate;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebImplementation.Abstractions;
using WebImplementation.Services;

#endregion

namespace WebImplementation.ApplicationDefinition
{
    public class HangFireCronDefinition : InitDefinitionDecorate
    {
        public HangFireCronDefinition()
        {
            base.InitializeOrder = 3;
            base.IsDecorationEnable = true;
        }

        /// <inheritdoc />
        public override void ServiceConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            //Setting up a simple scheduler service using dependency.
            services.AddTransient<ISchedulerService, SchedulerService>();

            //Setting a schedule methods execution
            RecurringJob.AddOrUpdate("ExampleBackgroundProcessUsingInjectedService",
                () => services.BuildServiceProvider().GetService<ISchedulerService>()!.DoWork(),
                "*/10 * * * *");

            RecurringJob.AddOrUpdate("ExampleBackgroundProcessUsingMediatR",
                () => services.BuildServiceProvider().GetService<ISchedulerService>()!.DoWorkAsync(),
                "*/15 * * * *");
        }
    }
}