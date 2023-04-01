// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-04-01 23:18
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="MediatRQueueExtension.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using AggregatedGenericResultMessage.Abstractions;
using HFMRProcessor.Abstractions;
using MediatR;

// ReSharper disable UnusedParameter.Global

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor.Extensions
{
    /// <summary>
    ///     Queue extension
    /// </summary>
    public static class MediatRQueueExtension
    {
        /// <summary>
        ///     Dispatcher service
        /// </summary>
        private static IDispatcherService _dispatcherService;

        /// <summary>
        ///     Initialize extension configuration
        /// </summary>
        /// <param name="messageDispatcher">Dispatcher service</param>
        public static void InitializeConfiguration(IDispatcherService messageDispatcher)
            => _dispatcherService = messageDispatcher;

        /// <summary>
        ///     Set request to enqueue
        /// </summary>
        /// <param name="mediator">Mediator</param>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">Mediator request</param>
        /// <returns></returns>
        public static IResult Enqueue(this IMediator mediator, string jobId, IRequest request)
            => _dispatcherService?.Dispatch(jobId, request);

        /// <summary>
        ///     Set request to enqueue
        /// </summary>
        /// <typeparam name="T">Template request type</typeparam>
        /// <param name="mediator">Mediator</param>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">Mediator request</param>
        /// <returns></returns>
        public static IResult Enqueue<T>(this IMediator mediator, string jobId, IRequest<T> request)
            => _dispatcherService?.Dispatch(jobId, request);

        /// <summary>
        ///     Set request to enqueue with delay
        /// </summary>
        /// <param name="mediator">Mediator</param>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">Mediator request</param>
        /// <param name="delay">Timespan delay</param>
        /// <returns></returns>
        public static IResult EnqueueAwait(this IMediator mediator, string jobId, IRequest request, TimeSpan delay)
            => _dispatcherService?.DispatchAwait(jobId, request, delay);

        /// <summary>
        ///     Set request to enqueue with delay
        /// </summary>
        /// <typeparam name="T">Template request type</typeparam>
        /// <param name="mediator">Mediator</param>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">Mediator request</param>
        /// <param name="delay">Timespan delay</param>
        /// <returns></returns>
        public static IResult EnqueueAwait<T>(this IMediator mediator, string jobId, IRequest<T> request, TimeSpan delay)
            => _dispatcherService?.DispatchAwait(jobId, request, delay);
    }
}