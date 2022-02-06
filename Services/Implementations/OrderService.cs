// <copyright file="OrderService.cs">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using RegisterServicesWithReflection.Services.Base;
using RegisterServicesWithReflection.Services.Interfaces;

namespace RegisterServicesWithReflection.Services.Implementations;

[TransientRegistration]
public class OrderService : IOrderService
{
    
}