using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO
{
    public class SectionDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Area ID is required")]
        public Guid AreaId { get; set; }

        [Required(ErrorMessage ="Section name is required")]
        public string Name { get;  set; }


        [Required(ErrorMessage = "Please cheack if section will be active.")]
        public bool IsActive { get;  set; }

        public DateTime? CreationDate { get; set; }


        public AreaDTO Area { get; set; }
        
    }
}
