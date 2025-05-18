// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Feast.Aspire.Hosting.Extensions.OpenDashboard;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceExtensions
{
    /// <summary>
    /// Adds the OpenDashboard service to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to add the OpenDashboard service to.</param>
    public static IServiceCollection AddOpenDashboard(this IServiceCollection services)
    {
        services.TryAddSingleton(s =>
        {
            var options = s.GetService<IOptions<Aspire.Hosting.Dashboard.DashboardOptions>>();
            if (options is null)
            {
                throw new InvalidOperationException("Aspire.Hosting.Dashboard.DashboardOptions is not registered.");
            }

            return new DashboardOptions(options.Value.DashboardToken);
        });
        return services;
    }
}
