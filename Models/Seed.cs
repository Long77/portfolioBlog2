using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
//yeaux

public static class Seed
{
    public static void Initialize(DB db)
    {
        //if(isDevEnvironment){
        db.Database.EnsureDeleted(); // delete then, ...
        db.Database.EnsureCreated(); // create the tables!!
        // db.Database.Migrate(); // ensure migrations are registered (sqlite/postgres only, won't work with in-memory db)
        
        if(db.Posts.Any())
        {
        return;
        }

       // Action createList = () => {
         //   CardList todo = new CardList { Summary="Todo items", Cards = new List<Card>() };
         List<Post>posts = new List<Post>();
            for(var i = 0; i < 10; i++)
            {
                db.Posts.Add(new Post { Title = $"Test Card {i}", Content = $"Test Content {i}" });
            }

       // for(var j = 0; j<3; j++)
            //createList();
        db.SaveChanges(); 
        Console.WriteLine("----------POSTS SEEDED-------------");
        Console.WriteLine(db.Posts.ToList().Count());
        
    }
}