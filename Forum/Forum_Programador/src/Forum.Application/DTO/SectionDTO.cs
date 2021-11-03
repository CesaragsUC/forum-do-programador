using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class SectionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
    }
}
