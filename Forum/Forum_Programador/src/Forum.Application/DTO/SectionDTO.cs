using System;
using System.Collections;
using System.Collections.Generic;
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

        public int TotalTopics { get; set; }

        public int TotalPosts { get; set; }

        [Required(ErrorMessage = "Please cheack if section will be active.")]
        public bool IsActive { get;  set; }

        public DateTime? CreationDate { get; set; }


        public AreaDTO Area { get; set; }

   

    }
}
