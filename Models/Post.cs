using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
//yeaux
public class Post
{
    [Required]
    public int PostId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [StringLength(250, MinimumLength = 10)]
    public string Content { get; set; }
    [Required]
    public DateTime createdAt {get; set;} = DateTime.Now;
    [Required]
    public Post(){
        Post = new Random().NextInt();
    }

}
