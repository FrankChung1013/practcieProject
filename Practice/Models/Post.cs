using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Practice.Models
{
    public partial class Post
    {
        [Key]
        public int PostId { get; set; }
        [StringLength(200)]
        public string? Title { get; set; }
        [Column(TypeName = "ntext")]
        public string? Content { get; set; }
        public int BlogId { get; set; }

        [ForeignKey("BlogId")]
        [InverseProperty("Posts")]
        public virtual Blog Blog { get; set; } = null!;
    }
}
