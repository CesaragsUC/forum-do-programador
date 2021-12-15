using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class UpdateUserEmailDTO
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }


        [Required(ErrorMessage = "Invalid Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
