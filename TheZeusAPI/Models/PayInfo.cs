using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheZeusAPI.Models
{
    public class PayInfo
    {
        [Key]
        public int PayStubId { get; set; }

        public int EmployeeID { get; set; }

        public decimal Pay { get; set; }
        [Required]

        public string Month { get; set; }
    }
}
