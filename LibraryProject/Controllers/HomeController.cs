using LibraryProject.Infrastructure.Mappers;

namespace LibraryProject.Controllers;

public class HomeController(IBookService bookService, IFileService fileService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await bookService.GetAllBooksAsync();

        if (books.Count is 0)
            return RedirectToAction(nameof(Create));

        return View(books);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateBookRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            Log.Warning("{@model} model doğrulanırken {modelStateErrors} hatalarıyla karşılaşıldı !", model, ModelStateErrors);
            jsonResponseModel.Title = MessageTitle.InvalidRequest;
            jsonResponseModel.Errors = ModelStateErrors;

            return Json(jsonResponseModel);
        }
        
        var book = ObjectMapper.Mapper.Map<Book>(model);
        var uploadBookPhotoResult = await fileService.UploadAsync(model.ImageFile);

        if (!uploadBookPhotoResult.Item1)
        {
            Log.Warning("Kitap fotoğrafı eklenirken hata ile karşılaşıldı!" );
            jsonResponseModel.Title = MessageTitle.AddedFailed;
            jsonResponseModel.Errors.Add(MessageText.FileAddedFailed);

            return Json(jsonResponseModel);
        }

        book.ImagePath = uploadBookPhotoResult.Item2;
        var result = await bookService.AddBook(book);

        if (!result)
        {
            Log.Warning("Kitap eklenirken hata ile karşılaşıldı!" );
            jsonResponseModel.Title = MessageTitle.AddedFailed;
            jsonResponseModel.Errors.Add(MessageText.BookAddedFailed);

            return Json(jsonResponseModel);
        }

        jsonResponseModel.Title = MessageTitle.AddedSuccess;
        jsonResponseModel.SuccessMessage = MessageText.BookAddedSuccess;
        jsonResponseModel.Url = Url.Action(nameof(Index));

        return Json(jsonResponseModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LendBook(LendBookRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            Log.Warning("{@model} model doğrulanırken {modelStateErrors} hatalarıyla karşılaşıldı !", model, ModelStateErrors);
            jsonResponseModel.Title = MessageTitle.InvalidRequest;
            jsonResponseModel.Errors = ModelStateErrors;

            return Json(jsonResponseModel);
        }
        
        var result = await bookService.LendAsync(model);
        
        if (!result)
        {
            Log.Warning("Ödünç verilirken hata ile karşılaşıldı!" );
            jsonResponseModel.Title = MessageTitle.LendFailed;
            jsonResponseModel.Errors.Add(MessageText.BookLendFailed);

            return Json(jsonResponseModel);
        }
        
        jsonResponseModel.Title = MessageTitle.LendSuccess;
        jsonResponseModel.SuccessMessage = MessageText.BookLendSuccess;

        return Json(jsonResponseModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeliverBook(int bookId)
    {
        var result = await bookService.DeliverAsync(bookId);
        if (!result)
        {
            Log.Warning("Teslim edilirken hata ile karşılaşıldı!" );
            jsonResponseModel.Title = MessageTitle.DeliverFailed;
            jsonResponseModel.Errors.Add(MessageText.BookDeliverFailed);

            return Json(jsonResponseModel);
        }

        jsonResponseModel.Title = MessageTitle.DeliverSuccess;
        jsonResponseModel.SuccessMessage = MessageText.BookDeliverSuccess;

        return Json(jsonResponseModel);
    }
}