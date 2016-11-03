using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

/// -> Blog() -> an HTML page that shows the most recent 5 posts
//{id} -> Post(id) -> an HTML page that shows a specific post


[Route("/posts")]
public class BlogController : Controller {
    private IBlogRepo blog;
    public BlogController(IBlogRepo b){
        blog = b;
    }

    [HttpGet("{PostId}")]
    public IActionResult ReadOne(int PostId){
        var post = blog.get(PostId);
        if(post == null)
            return NotFound(); //404
        
        return View(blog);
    }

    [HttpGet("{PostId}/edit")]
    public IActionResult Edit(int PostId){
        var p = blog.get(PostId);
        if(p == null)
            return Redirect("/posts");

        return View(p);
    }

    [HttpPost("{PostId}/edit")]
    
    public IActionResult Upsert([FromForm] Post post, int PostId){
        
        var p = blog.get(PostId);
        if(p != null) {
            blog.delete(PostId);
        }

        // make sure that the PostId is the same as 
        post.PostId = PostId;
        blog.add(post);
        return RedirectToAction("ReadOne");
    }

    [HttpGet("new")]
    public IActionResult Create(){
        return View();
    }

    [HttpPost("new")]
    public IActionResult HandleCreate([FromForm] Post p){
        blog.add(p);
        return View();
    }

    [HttpPost("delete/{PostId}")]
    // 
    public IActionResult Delete(int PostId){
        blog.delete(PostId);
        return RedirectToAction("ReadOne");
    }

    [HttpGet("about")]
    public IActionResult About(){
        return View();
    }
}