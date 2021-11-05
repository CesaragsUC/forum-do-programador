using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class SectionDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Section name is required")]
        public string Name { get;  set; }


        [Required(ErrorMessage = "Please cheack if section will be active.")]
        public bool IsActive { get;  set; }

        public DateTime CreationDate { get; set; }
    }
}
