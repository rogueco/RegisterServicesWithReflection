// <copyright file="DataContext.cs" company="Commerce Control Limited">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using Microsoft.EntityFrameworkCore;
using RegisterServicesWithReflection.Models;

namespace RegisterServicesWithReflection.Data;

public class DataContext : DbContext 
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Customer> Customers { get; set; }
}