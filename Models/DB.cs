using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
//yeaux
public partial class DB : DbContext {

    public DB(): base(){}

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseInMemoryDatabase();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Post>().ToTable("Post");
    }
    public DbSet<Post> Posts { get; set; }
}