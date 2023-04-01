// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="IJobExecutionService.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AggregatedGenericResultMessage.Abstractions;

// ReSharper disable IdentifierTypo

#endregion

namespace HFMRProcessor.Abstractions
{
    /// <summary>
    ///     Job execution service
    /// </summary>
    public interface IJobExecutionService
    {
        /// <summary>
        ///     Get last successful job execution
        /// </summary>
        /// <param name="jobId">Required. Uniq job id</param>
        /// <param name="cancellationToken">Optional. The default value is default.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        Task<IResult<DateTime>> GetLastSuccessfulRunAsync(string jobId, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get received job result
        /// </summary>
        /// <param name="jobId">Required. Uniq job id</param>
        /// <param name="cancellationToken">Optional. The default value is default.</param>
        /// <returns></returns>
        /// <typeparam name="TReturn">Result template type</typeparam>
        /// <remarks></remarks>
        Task<IResult<IEnumerable<TReturn>>> GetJobResultReturnedItemsAsync<TReturn>(
            string jobId,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Get received job result
        /// </summary>
        /// <param name="jobId">Required. Uniq job id</param>
        /// <param name="cancellationToken">Optional. The default value is default.</param>
        /// <returns></returns>
        /// <typeparam name="TReturn">Result template type</typeparam>
        /// <remarks></remarks>
        Task<IResult<TReturn>> GetJobResultReturnedItemAsync<TReturn>(
            string jobId,
            CancellationToken cancellationToken = default);
    }
}