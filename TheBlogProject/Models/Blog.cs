﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace TheBlogProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 5)]
        public string Description { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }
        
        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }
        
        [Display(Name = "Image Type")]
        public string ContentType { get; set; }
        
        [NotMapped]
        public IFormFile Image { get; set; }


        // Navigation Properties
        public virtual BlogUser Author { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();


    }
}
