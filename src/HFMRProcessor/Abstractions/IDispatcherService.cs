// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="IDispatcherService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Linq.Expressions;
using AggregatedGenericResultMessage.Abstractions;
using MediatR;

// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

#endregion

namespace HFMRProcessor.Abstractions
{
    /// <summary>
    ///     Dispatcher service
    /// </summary>
    /// <remarks></remarks>
    public interface IDispatcherService
    {
        /// <summary>
        ///     Dispatch method
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="methodCall">Called method</param>
        /// <returns>Uniq request identifier</returns>
        /// <remarks></remarks>
        IResult<string> Dispatch(string jobId, Expression<Action> methodCall);

        /// <summary>
        ///     Dispatch MediatR request
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">MediatR request</param>
        /// <returns>Uniq request identifier</returns>
        /// <remarks></remarks>
        IResult<string> Dispatch(string jobId, IRequest request);

        /// <summary>
        ///     Dispatch MediatR request
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">MediatR request</param>
        /// <returns>Uniq request identifier</returns>
        /// <typeparam name="T">Request template</typeparam>
        /// <remarks></remarks>
        IResult<string> Dispatch<T>(string jobId, IRequest<T> request);

        /// <summary>
        ///     Dispatch method delayed
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="methodCall">Called method</param>
        /// <param name="delay">Timespan delay</param>
        /// <returns>Uniq request identifier</returns>
        /// <remarks></remarks>
        IResult<string> DispatchAwait(string jobId, Expression<Action> methodCall, TimeSpan delay);

        /// <summary>
        ///     Dispatch MediatR request delayed
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">MediatR request</param>
        /// <param name="delay">Timespan delay</param>
        /// <returns>Uniq request identifier</returns>
        /// <remarks></remarks>
        IResult<string> DispatchAwait(string jobId, IRequest request, TimeSpan delay);

        /// <summary>
        ///     Dispatch MediatR request delayed
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">MediatR request</param>
        /// <param name="delay">Timespan delay</param>
        /// <returns>Uniq request identifier</returns>
        /// <typeparam name="T">Request template</typeparam>
        /// <remarks></remarks>
        IResult<string> DispatchAwait<T>(string jobId, IRequest<T> request, TimeSpan delay);
    }
}