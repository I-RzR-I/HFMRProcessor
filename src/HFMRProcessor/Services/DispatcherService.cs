// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="DispatcherService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Linq.Expressions;
using AggregatedGenericResultMessage;
using AggregatedGenericResultMessage.Abstractions;
using AggregatedGenericResultMessage.Extensions.Result;
using Hangfire;
using HFMRProcessor.Abstractions;
using HFMRProcessor.Helpers;
using MediatR;
using Microsoft.Extensions.Logging;

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor.Services
{
    /// <inheritdoc cref="IDispatcherService" />
    public class DispatcherService : IDispatcherService
    {
        /// <summary>
        ///     Dispatcher service logger
        /// </summary>
        private readonly ILogger<DispatcherService> _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DispatcherService" /> class.
        /// </summary>
        /// <param name="logger">Current logger</param>
        /// <remarks></remarks>
        public DispatcherService(ILogger<DispatcherService> logger) => _logger = logger;

        /// <inheritdoc />
        public IResult<string> Dispatch(string jobId, Expression<Action> methodCall)
        {
            try
            {
                var uniqId = new BackgroundJobClient()
                    .Enqueue(methodCall);

                return Result<string>.Success(uniqId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Result<string>.Failure()
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public IResult<string> Dispatch(string jobId, IRequest request)
        {
            try
            {
                var uniqId = new BackgroundJobClient()
                    .Enqueue<MediatRCommunicationHelper>(x => x.SendRequest(jobId, request));

                return Result<string>.Success(uniqId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Result<string>.Failure()
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public IResult<string> Dispatch<T>(string jobId, IRequest<T> request)
        {
            try
            {
                var uniqId = new BackgroundJobClient()
                    .Enqueue<MediatRCommunicationHelper>(x => x.SendRequest(jobId, request));

                return Result<string>.Success(uniqId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Result<string>.Failure()
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public IResult<string> DispatchAwait(string jobId, Expression<Action> methodCall, TimeSpan delay)
        {
            try
            {
                var uniqId = new BackgroundJobClient()
                    .Schedule(methodCall, delay);

                return Result<string>.Success(uniqId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Result<string>.Failure()
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public IResult<string> DispatchAwait(string jobId, IRequest request, TimeSpan delay)
        {
            try
            {
                var uniqId = new BackgroundJobClient()
                    .Schedule<MediatRCommunicationHelper>(x => x.SendRequest(jobId, request), delay);

                return Result<string>.Success(uniqId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Result<string>.Failure()
                    .WithError(e);
            }
        }

        /// <inheritdoc />
        public IResult<string> DispatchAwait<T>(string jobId, IRequest<T> request, TimeSpan delay)
        {
            try
            {
                var uniqId = new BackgroundJobClient()
                    .Schedule<MediatRCommunicationHelper>(x => x.SendRequest(jobId, request), delay);

                return Result<string>.Success(uniqId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                return Result<string>.Failure()
                    .WithError(e);
            }
        }
    }
}