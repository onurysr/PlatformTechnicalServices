using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Models
{
    public static class RoleModels
    {
        public static string Admin = "Admin";
        public static string Operator = "Operator";
        public static string Teknisyen = "Teknisyen";
        public static string Musteri = "Musteri";
        public static string Passive = "Passive";

        public static ICollection<string> Roles => new List<string> { Admin, Operator, Teknisyen, Musteri, Passive };

    }
}
