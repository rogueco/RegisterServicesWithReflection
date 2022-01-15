// <copyright file="CustomerService.cs" company="Commerce Control Limited">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using Microsoft.EntityFrameworkCore;
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
        Customer customer = await _dataContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
        return customer ?? new Customer();
    }

    public async Task<Customer> CreateCustomer(Customer customer)
    {
        _dataContext.Customers.Add(customer);
        bool result = await _dataContext.SaveChangesAsync() > 0;

        return result ? customer : new Customer();
    }
}