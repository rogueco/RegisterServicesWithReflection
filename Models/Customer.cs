// <copyright file="Customer.cs" company="Commerce Control Limited">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

namespace RegisterServicesWithReflection.Models;

public class Customer
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}