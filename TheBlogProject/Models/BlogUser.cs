using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace TheBlogProject.Models
{
    public class BlogUser : IdentityUser
    {

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Image")]
        public byte[] ImageData { get; set; }

        [Display(Name = "Image Type")]
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public string FacebookUrl { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public string TwitterUrl { get; set; }
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public string GithubUrl { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";


        // Navigation Properties
        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}