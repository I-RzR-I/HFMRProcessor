// ReSharper disable CommentTypo
// ***********************************************************************
//  Assembly         : RzR.Services.HFMRProcessor
//  Author           : RzR
//  Created On       : 2023-03-30 00:36
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-02 00:46
// ***********************************************************************
//  <copyright file="MediatRCommunicationHelper.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System.ComponentModel;
using System.Threading.Tasks;
using MediatR;

// ReSharper disable UnusedParameter.Global

// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace HFMRProcessor.Helpers
{
    /// <summary>
    ///     MediatR communication helper
    /// </summary>
    /// <remarks></remarks>
    public class MediatRCommunicationHelper
    {
        private readonly IMediator _mediator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatRCommunicationHelper" /> class.
        /// </summary>
        /// <param name="mediator"></param>
        /// <remarks></remarks>
        public MediatRCommunicationHelper(IMediator mediator) => _mediator = mediator;

        /// <summary>
        ///     Send request
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">MediatR request</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [DisplayName("{0}")]
        public async Task SendRequest(string jobId, IRequest request) => await _mediator.Send(request);

        /// <summary>
        ///     Send request
        /// </summary>
        /// <param name="jobId">Uniq job identifier</param>
        /// <param name="request">MediatR request</param>
        /// <returns></returns>
        /// <typeparam name="T"></typeparam>
        /// <remarks></remarks>
        [DisplayName("{0}")]
        public async Task SendRequest<T>(string jobId, IRequest<T> request) => await _mediator.Send(request);
    }
}