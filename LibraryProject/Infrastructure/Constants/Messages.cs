namespace LibraryProject.Infrastructure.Constants;

internal record struct MessageTitle
{
    internal const string CacheClearSuccess = "Veri Temizleme Başarılı";
    internal const string EditSuccess = "Güncelleme Başarılı";
    internal const string NotFound = "Bulunamadı";
    internal const string ActiveOrDeactiveSuccess = "Durum Başarılı";
    internal const string DeleteSuccess = "Silme Başarılı";
    internal const string AddedSuccess = "Ekleme Başarılı";
    internal const string PasswordResetSuccess = "Şifre Sıfırlama Başarılı";
    internal const string LendFailed = "Ödünç Verme Başarısız";
    internal const string AddedFailed = "Ekleme Başarısız";
    internal const string LendSuccess = "Ödünç Verme Başarılı";
    internal const string DeliverFailed = "Teslim Etme Başarısız";
    internal const string DeliverSuccess = "Teslim Etme Başarılı";
    internal const string InvalidRequest = "Doğrulama Hatası";
    
}

internal record struct MessageText
{
    internal const string BookAddedFailed = "Kitap eklenirken bir hata meydana geldi!";
    internal const string FileAddedFailed = "Fotoğraf eklenirken bir hata meydana geldi!";
    internal const string BookAddedSuccess = "Kitap başarıyla eklendi!";
    internal const string BookLendFailed = "Kitap ödünç verilirken bir hata oluştu!";
    internal const string BookLendSuccess = "Kitap başarıyla ödünç verildi!";
    internal const string BookDeliverFailed = "Kitap teslim edilirken bir hata oluştu!";
    internal const string BookDeliverSuccess = "Kitap başarıyla teslim edildi!";
    


}