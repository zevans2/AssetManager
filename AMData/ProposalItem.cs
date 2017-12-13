using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AMData
{
    public class ProposalItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Project Name Cannot be Empty.")]
        [Display(Description="Product Name")]
        [StringLength(150, MinimumLength = 4, ErrorMessage="Project Name must be greater than {2} characters and less than {1} characters.")]
        public string ProjectName { get; set; }

        public string SubmitDateTime { get; set; }

        [Range(typeof(DateTime),"01/01/2017","01/01/2025", ErrorMessage = "Expiration Date must be later than submission date.")]
        [Display(Description = "Expiration Date")]
        public string ExpDateTime { get; set; }
        
        public string Cost { get; set; }

        [Required(ErrorMessage = "Project must have a project description.")]
        public string Description { get; set; }
    }
    
}
