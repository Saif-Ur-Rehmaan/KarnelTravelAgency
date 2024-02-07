using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnelTravelAgency.Core
{
  
        public class Admin
        {
        [Key]
            public int AdminID { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int RoleID { get; set; }
            public Role Role { get; set; }
        }
    
}
