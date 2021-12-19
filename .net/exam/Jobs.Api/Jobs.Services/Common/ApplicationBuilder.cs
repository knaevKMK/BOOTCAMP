namespace Jobs.Services.Common
{
    using Jobs.Services.Common.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
 public static   class ApplicationBuilder
    {
        public static IApplicationBuilder PrepareDatabse(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            data.Database.EnsureCreated();
            data.Database.Migrate();
            return app;
        }

    }
}
