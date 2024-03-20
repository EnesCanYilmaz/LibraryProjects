namespace LibraryProject.Controllers;

/// <summary>
/// Hata denetleyicisi sınıfı, ASP.NET Core MVC Controller sınıfından türetilir.
/// ErrorPage ve ErrorPage404 adında iki aksiyon metodu bulunur, her ikisi de bir görünüm döndürür.
/// </summary>
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