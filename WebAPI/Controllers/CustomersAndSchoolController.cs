﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersAndSchoolController : ControllerBase
    {
        private ICustomersAndSchoolService _customersAndSchoolService;

        public CustomersAndSchoolController(ICustomersAndSchoolService customersAndSchoolService)
        {
            _customersAndSchoolService = customersAndSchoolService;
        }


    }
}
