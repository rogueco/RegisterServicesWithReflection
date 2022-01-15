// <copyright file="ClientController.cs">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using System.Net;
using Microsoft.AspNetCore.Mvc;
using RegisterServicesWithReflection.Models;
using RegisterServicesWithReflection.Services.Interfaces;

namespace RegisterServicesWithReflection.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Customer>> GetCustomer(Guid id)
    {
        Customer customer = await _customerService.GetCustomer(id);
        return customer;
    }
}