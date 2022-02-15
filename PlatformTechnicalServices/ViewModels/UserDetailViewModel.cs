using System;
using System.Collections.Generic;

namespace PlatformTechnicalServices.ViewModels
{
    public class UserDetailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public IList<string> UserRoles { get; set; }
        public string SelectedRoleId { get; set; }
    }
}
