// <copyright file="CustomerService.cs" company="Commerce Control Limited">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using RegisterServicesWithReflection.Data;
using RegisterServicesWithReflection.Models;
using RegisterServicesWithReflection.Services.Interfaces;

namespace RegisterServicesWithReflection.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly DataContext _dataContext;

    public CustomerService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<Customer> GetCustomer(Guid id)
    {
        Customer? customer = _dataContext.Customers.FirstOrDefault(x => x.Id == id);

        return customer ?? new Customer();
    }
}