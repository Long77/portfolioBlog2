using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
//yeaux
public interface IBlogRepo{
    void add(Post p); // CREATE
    IEnumerable<Post> getAll(); // READ, get all
    Post get(int Postid); // READ, get 1
    Post update(int Postid, Post p); // UPDATE
    void delete(int Postid); // DELETE
}

public class Blog
{
    public int BlogId {get; set;}
    public string Title {get; set;}
    public string Content{get; set;}



    private List<Post> posts = new List<Post>();
    public Blog(){
        posts.Add(new Post { PostId = 1, Title = "First", Content = "Check out my stuff yeaux!" });
        posts.Add(new Post { PostId = 2, Title = "Second", Content = "Foo"});
        posts.Add(new Post { PostId = 3, Title = "Third", Content = "Foo and a half" });
        posts.Add(new Post { PostId = 4, Title = "Fourth", Content = "Foo ManChu" });
        posts.Add(new Post { PostId = 5, Title = "Fifth", Content = "Le Foo" });
    }

    public void add(Post p){
        posts.Add(p);
    }
    public IEnumerable<Post> getAll(){
        return posts;
    }

    // public Post get(int Postid){
    //     return posts.First(p => p.PostId == Id);
    // }

    // public Post update(int Postid, Post p){
    //     //Post toUpdate = posts.First(x => x.PostId == Id);
    //     if(toUpdate != null){
    //         posts.Remove(toUpdate);
    //         posts.Add(p);
    //         return p;
    //     }
    //     return null;
    // }

    public void delete(int Postid){
        Post p = posts.First(x => x.PostId == Postid);
        if(p != null){
            posts.Remove(p);
        }
    }
}