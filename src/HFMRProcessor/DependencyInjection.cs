// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="DependencyInjection.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;
using AggregatedGenericResultMessage.Extensions.Common;
using Hangfire;
using Hangfire.Dashboard;
using HFMRProcessor.Abstractions;
using HFMRProcessor.Extensions;
using HFMRProcessor.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor
{
    /// <summary>
    ///     Dependency injection
    /// </summary>
    /// <remarks></remarks>
    public static class DependencyInjection
    {
        /// <summary>
        ///     Configure HangFire services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Application configuration</param>
        /// <remarks></remarks>
        public static void ConfigureHangFireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.InitializeHangFireService(configuration);

            services.AddTransient<IDispatcherService, DispatcherService>();
            services.AddScoped<IJobExecutionService, JobExecutionService>();

            var provider = services.BuildServiceProvider();
            MediatRQueueExtension.InitializeConfiguration(provider.GetRequiredService<IDispatcherService>());
        }

        /// <summary>
        ///     Register processor as a server
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Application configuration</param>
        /// <remarks></remarks>
        public static void RegisterProcessorAsServer(this IServiceCollection services, IConfiguration configuration)
        {
            var cfgHeartbeatInterval = configuration.GetHandFireHeartbeatInterval();
            var cfgServerCheckInterval = configuration.GetHandFireServerCheckInterval();

            if (!cfgHeartbeatInterval.IsSuccess)
                throw new ArgumentOutOfRangeException(cfgHeartbeatInterval.GetFirstMessage());
            if (!cfgServerCheckInterval.IsSuccess)
                throw new ArgumentOutOfRangeException(cfgServerCheckInterval.GetFirstMessage());

            var heartbeatInterval = string.IsNullOrEmpty(cfgHeartbeatInterval.Response)
                ? TimeSpan.FromMinutes(1)
                : TimeSpan.FromMinutes(long.Parse(cfgHeartbeatInterval.Response));

            var serverCheckInterval = string.IsNullOrEmpty(cfgServerCheckInterval.Response)
                ? TimeSpan.FromMinutes(1)
                : TimeSpan.FromMinutes(long.Parse(cfgServerCheckInterval.Response));

            services.AddHangfireServer(opts =>
            {
                opts.HeartbeatInterval = heartbeatInterval;
                opts.ServerCheckInterval = serverCheckInterval;
            });
        }

        /// <summary>
        ///     Use custom HangFire dashboard url
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="customUrl">Custom dashboard link</param>
        /// <param name="filters">Auth header filters</param>
        /// <remarks></remarks>
        public static void UseCustomHangFireDashboard(
            this IApplicationBuilder app, string customUrl,
            IReadOnlyCollection<IDashboardAsyncAuthorizationFilter> filters)
            => app.UseHangfireDashboard(string.IsNullOrEmpty(customUrl)
                    ? "/hangfire"
                    : customUrl,
                new DashboardOptions { AsyncAuthorization = filters });
    }
}