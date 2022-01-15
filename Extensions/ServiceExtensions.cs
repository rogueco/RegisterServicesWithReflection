// <copyright file="ServiceExtensions.cs" company="Commerce Control Limited">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <author>Tom Fletcher, Software Engineer</author>

using RegisterServicesWithReflection.Services.Base;

namespace RegisterServicesWithReflection.Extensions;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Define types that need matching
        Type scopedRegistration = typeof(ScopedRegistrationAttribute);
        Type singletonRegistration = typeof(SingletonRegistrationAttribute);
        Type transientRegistration = typeof(TransientRegistrationAttribute); 


        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p =>  p.IsDefined(scopedRegistration, true) || p.IsDefined(transientRegistration, true) || p.IsDefined(singletonRegistration, true) && !p.IsInterface).Select(s => new
            {
                Service = s.GetInterface($"I{s.Name}"),
                Implementation = s 
            }).Where(x => x.Service != null);


        foreach (var type in types)
        {
            if (type.Service.IsDefined(scopedRegistration, true))
            {
                services.AddScoped(type.Service, type.Implementation);
            }
            
            if (type.Service.IsDefined(transientRegistration, true))
            {
                services.AddTransient(type.Service, type.Implementation);
            }
            
            if (type.Service.IsDefined(singletonRegistration, true))
            {
                services.AddSingleton(type.Service, type.Implementation);
            }
        }
    }
}