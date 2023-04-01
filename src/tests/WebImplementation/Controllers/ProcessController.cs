// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-03-30 18:55
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-03-30 19:07
// ***********************************************************************
//  <copyright file="ProcessController.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

#region U S A G E S

using System;
using HFMRProcessor.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebImplementation.Application.Commands.SimpleCommands.LongTestCommand;
using WebImplementation.Application.Commands.SimpleCommands.TestCommand;

#endregion

namespace WebImplementation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProcessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProcessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Enqueue()
        {
            _mediator.Enqueue(Guid.NewGuid().ToString(), new TestCommandCommand());

            return Ok();
        }

        [HttpGet]
        public IActionResult LongEnqueue()
        {
            _mediator.Enqueue(Guid.NewGuid().ToString(), new LongTestCommandCommand());

            return Ok();
        }
    }
}