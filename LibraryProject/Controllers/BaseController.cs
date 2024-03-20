namespace LibraryProject.Controllers;

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