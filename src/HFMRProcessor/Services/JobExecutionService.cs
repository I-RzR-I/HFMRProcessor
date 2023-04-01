// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="JobExecutionService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AggregatedGenericResultMessage;
using AggregatedGenericResultMessage.Abstractions;
using AggregatedGenericResultMessage.Extensions.Common;
using AggregatedGenericResultMessage.Extensions.Result;
using Hangfire;
using Hangfire.Storage;
using HFMRProcessor.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor.Services
{
    /// <inheritdoc cref="IJobExecutionService" />
    public class JobExecutionService : IJobExecutionService
    {
        /// <summary>
        ///     Logger
        /// </summary>
        private readonly ILogger<JobExecutionService> _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JobExecutionService" /> class.
        /// </summary>
        /// <param name="logger">Application logger</param>
        /// <remarks></remarks>
        public JobExecutionService(ILogger<JobExecutionService> logger) => _logger = logger;

        /// <inheritdoc />
        public async Task<IResult<DateTime>> GetLastSuccessfulRunAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = JobStorage.Current.GetConnection())
                {
                    var job = connection.GetRecurringJobs().FirstOrDefault(p => p.Id == jobId);

                    if (!job.IsNull())
                    {
                        var lastRun = JobStorage.Current.GetMonitoringApi().SucceededJobs(0, int.Parse(job?.LastJobId!))
                            .Where(x => x.Value.Job.Args [0].ToString() == jobId)
                            .OrderByDescending(x => x.Key)
                            .FirstOrDefault();

                        if (lastRun.Value?.SucceededAt != null)
                            return Result<DateTime>.Success(lastRun.Value.SucceededAt.Value);
                    }
                }

                return await Task.FromResult(Result<DateTime>.Success(DateTime.MinValue));
            }
            catch (Exception e)
            {
                const string message = "An error occurred on getting last successful execution!";
                _logger.LogError(e, message);

                return Result<DateTime>
                    .Failure(message)
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public async Task<IResult<IEnumerable<TReturn>>> GetJobResultReturnedItemsAsync<TReturn>(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var jobMonitoringApi = JobStorage.Current.GetMonitoringApi();
                var job = jobMonitoringApi.JobDetails(jobId);
                var resultSerialized = job.History [0].Data ["Result"];
                var returnedItems = JsonConvert.DeserializeObject<List<TReturn>>(resultSerialized);

                return await Task.FromResult(Result<IEnumerable<TReturn>>.Success(returnedItems));
            }
            catch (Exception e)
            {
                const string message = "An error occurred on getting list of job results!";
                _logger.LogError(e, message);

                return Result<IEnumerable<TReturn>>
                    .Failure(message)
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public async Task<IResult<TReturn>> GetJobResultReturnedItemAsync<TReturn>(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var jobMonitoringApi = JobStorage.Current.GetMonitoringApi();
                var job = jobMonitoringApi.JobDetails(jobId);
                var resultSerialized = job.History [0].Data ["Result"];
                var returnedItems = JsonConvert.DeserializeObject<TReturn>(resultSerialized);

                return await Task.FromResult(Result<TReturn>.Success(returnedItems));
            }
            catch (Exception e)
            {
                const string message = "An error occurred on getting list of job result!";
                _logger.LogError(e, message);

                return Result<TReturn>
                    .Failure(message)
                    .WithError(e);
            }
        }
    }
}