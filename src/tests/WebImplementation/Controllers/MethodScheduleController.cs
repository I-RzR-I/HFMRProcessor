// ***********************************************************************
//  Assembly         : RzR.Services.WebImplementation
//  Author           : RzR
//  Created On       : 2023-04-01 22:01
// 
//  Last Modified By : RzR
//  Last Modified On : 2023-04-01 22:01
// ***********************************************************************
//  <copyright file="MethodScheduleController.cs" company="">
//   Copyright (c) RzR. All rights reserved.
//  </copyright>
// 
//  <summary>
//  </summary>
// ***********************************************************************

using System;
using HFMRProcessor.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebImplementation.Abstractions;

namespace WebImplementation.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MethodScheduleController : ControllerBase
    {
        private readonly IDispatcherService _dispatcherService;
        private readonly ISchedulerService _schedulerService;

        public MethodScheduleController(IDispatcherService dispatcherService, ISchedulerService schedulerService)
        {
            _dispatcherService = dispatcherService;
            _schedulerService = schedulerService;
        }

        [HttpGet]
        public IActionResult Dispatch()
        {
            _dispatcherService
                .Dispatch(Guid.NewGuid().ToString("N"),
                    () => _schedulerService.Invoke("MethodScheduleController.Dispatch"));

            return Ok();
        }

        [HttpGet]
        public IActionResult DispatchAwait()
        {
            _dispatcherService
                .DispatchAwait(Guid.NewGuid().ToString("N"),
                    () => _schedulerService.Invoke("MethodScheduleController.DispatchAwait"),
                    TimeSpan.FromMinutes(1));

            return Ok();
        }
    }
}