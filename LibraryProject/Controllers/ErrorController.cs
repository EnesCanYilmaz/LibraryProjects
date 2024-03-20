namespace LibraryProject.Controllers;

public class ErrorController : Controller
{
    [HttpGet]
    public IActionResult ErrorPage()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult ErrorPage404()
    {
        return View();
    }
}