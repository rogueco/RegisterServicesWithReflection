// <copyright file="ServiceExtensions.cs">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using RegisterServicesWithReflection.Services.Implementations;
using RegisterServicesWithReflection.Services.Interfaces;

namespace RegisterServicesWithReflection.Extensions;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IInventoryService, InventoryService>();
        services.AddSingleton<IPaymentService, PaymentService>();
        services.AddTransient<IOrderService, OrderService>();
    }
}