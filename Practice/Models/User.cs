using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Practice.Models
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80)]
        public string UserName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Password { get; set; } = null!;
    }
}
