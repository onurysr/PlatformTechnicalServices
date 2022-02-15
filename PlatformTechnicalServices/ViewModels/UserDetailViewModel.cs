using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.ViewModels
{
    public class UserDetailViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }

        public List<UserDetailRolesViewModel> Roles { get; set; }
    }
}
