using EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Presentation.Configuration
{
    public static class EmailConfig
    {
        public static IServiceCollection AddEmailServiceConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();


            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();


            return services;
        }
    }
}
