using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMsit133.Models
{
   

    public partial class MemberMetadata
    {
       [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("信箱")]
        public string Email { get; set; }
        [DisplayName("年齡")]
        public int? Age { get; set; }
        
    }
    public partial class AddressMetadata 
    {
        [DisplayName("城市")]
        public string City { get; set; }
        [DisplayName("鄉鎮")]
        public string SiteId { get; set; }
        [DisplayName("路名")]
        public string Road { get; set; }

    }
}
