using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/home")]
public class HomeController : Controller{
    private IBlogRepo blog;
    public HomeController(IBlogRepo b){
        blog = b;
    }

    [HttpGet]
    public IActionResult ReadAll(){
        return View(blog);
    }

    [HttpGet("home/About")]
    public IActionResult Index(string username = "you")
    {
        ViewData["Message"] = "Some extra info can be sent to the view";
        ViewData["Username"] = "username";
        return View(); 
        // View(new Student) method takes an optional object as a "model", typically called a ViewModel
    }
    // [HttpGet("sql/cards")] // ?sql=....
    // public IActionResult SqlCards([FromQuery]string sql) => Ok(cards.FromSql(sql));

    // [HttpGet("sql/lists")] // ?sql=....
    // public IActionResult SqlLists([FromQuery]string sql) => Ok(lists.FromSql(sql));

    // [HttpGet("sql/boards")] // ?sql=....
    // public IActionResult SqlBoards([FromQuery]string sql) => Ok(boards.FromSql(sql));
}