using System;
using System.Collections.Generic;

#nullable disable

namespace Msit133WebAPi.Models
{
    public partial class MyImageTable
    {
        public int ImageId { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
