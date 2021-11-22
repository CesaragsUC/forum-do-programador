using System;
using System.Collections.Generic;

namespace Forum.Application.DTO
{
    public class AreaDTO
    {
        public Guid Id { get; set; }
        public string Name  { get; set; }

        public ICollection<SectionDTO> Sections { get; set; }
    }
}
