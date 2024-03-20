namespace LibraryProject.Controllers;

/// <summary>
/// ASP.NET Core MVC Controller sınıfının işlevselliğini genişleten temel denetleyici sınıfı.
/// Ortak bir JsonResponseModel örneği sağlar ve ModelState hatalarını almak için bir özellik sunar.
/// </summary>
public class BaseController : Controller
{
    protected JsonResponseModel jsonResponseModel = new();
    private List<string> _modelStateErrors;
    
    protected List<string> ModelStateErrors
    {
        get
        {
            if (_modelStateErrors == null)
            {
                _modelStateErrors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            
            return _modelStateErrors;
        }
    }
}