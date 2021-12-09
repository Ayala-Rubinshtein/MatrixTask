using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using DAL.Model;

namespace DAL
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterPayServicesRepositor(this IServiceCollection serviceCollection)
        {

            //הוספה לכל טבלה משמעותית בפרויקט
        }

        public static void RegisterPayContext(this IServiceCollection serviceCollection, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var connectionString = "Server=ravcevel.database.windows.net;Database=Vizel;persist security info=True;user id=voicesystem;password=Sari-30020010;multipleactiveresultsets=True;";

            serviceCollection.AddDbContext<Model.VizelContext>(options =>
          {
              options.UseLoggerFactory(loggerFactory).UseSqlServer(connectionString);
          });
        }
    }

}
