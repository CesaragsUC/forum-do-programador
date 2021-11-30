using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Presentation.Configuration
{
    //https://github.com/nabinked/NToastNotify
    public static class ToastrConfig
    {
        public static IServiceCollection AddToastrConfig(this IServiceCollection services,
             IConfiguration configuration)
        {

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.TopRight
            });

            //Or simply go 
            //services.AddMvc().AddNToastNotifyToastr();

            return services;
        }
    }
}
