namespace LibraryProject.Infrastructure.Validators.Home;

public class LendBookRequestModelValidator : AbstractValidator<LendBookRequestModel>
{
    public LendBookRequestModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Kitap ID'si boş olamaz.")
            .GreaterThan(0).WithMessage("Geçersiz kitap ID'si.");

        RuleFor(x => x.ReturnDate)
            .NotEmpty().WithMessage("Dönüş tarihi boş olamaz.")
            .GreaterThan(DateTime.Today).WithMessage("Dönüş tarihi bugünden ileri bir tarih olmalıdır.");

        RuleFor(x => x.Borrower)
            .NotEmpty().WithMessage("Ödünç alan kişinin adı boş olamaz.")
            .MaximumLength(100).WithMessage("Ödünç alan kişinin adı en fazla 100 karakter olmalıdır.");
    }
}