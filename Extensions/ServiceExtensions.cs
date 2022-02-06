// <copyright file="ServiceExtensions.cs">
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
            .Where(p =>  p.IsDefined(scopedRegistration, false) || p.IsDefined(transientRegistration, false) || p.IsDefined(singletonRegistration, false) && !p.IsInterface)
            .Select(s => new
            {
                Service = s.GetInterface($"I{s.Name}"),
                Implementation = s 
            });


        foreach (var type in types)
        {
            if (type.Implementation.IsDefined(scopedRegistration, false))
            {
                services.AddScoped(type.Service, type.Implementation);
            }
            
            if (type.Implementation.IsDefined(transientRegistration, false))
            {
                services.AddTransient(type.Service, type.Implementation);
            }
            
            if (type.Implementation.IsDefined(singletonRegistration, false))
            {
                services.AddSingleton(type.Service, type.Implementation);
            }
        }
    }
}