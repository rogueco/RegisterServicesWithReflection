// <copyright file="ICustomerService.cs">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using RegisterServicesWithReflection.Models;
using RegisterServicesWithReflection.Services.Base;

namespace RegisterServicesWithReflection.Services.Interfaces;

public interface ICustomerService
{
    Task<Customer> GetCustomer(Guid id);
    
    Task<Customer> CreateCustomer(Customer customer);
}