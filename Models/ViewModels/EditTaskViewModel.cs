using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models.ViewModels
{
    public class EditTaskViewModel
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name cannot exeed 50 characters")]
        public string Name { get; set; }
        [MaxLength(300, ErrorMessage = "Description cannot exeed 300 characters")]
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }
}
