namespace LibraryProject.Infrastructure.Validators.Home;

public class CreateBookRequestModelValidator : AbstractValidator<CreateBookRequestModel>
{
    public CreateBookRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kitap adı boş olamaz.")
            .MaximumLength(100).WithMessage("Kitap adı en fazla 100 karakter olmalıdır.");

        RuleFor(x => x.Writer)
            .NotEmpty().WithMessage("Yazar adı boş olamaz.")
            .MaximumLength(100).WithMessage("Yazar adı en fazla 100 karakter olmalıdır.");

        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Kitap resmi seçilmelidir.");
        
        RuleFor(x => x.ReturnDate)
            .NotEmpty().When(x => !x.IsInLibrary).WithMessage("Dönüş tarihi zorunludur.")
            .GreaterThan(DateTime.Today).When(x => !x.IsInLibrary).WithMessage("Dönüş tarihi bugünden ileri bir tarih olmalıdır.");
    }
}