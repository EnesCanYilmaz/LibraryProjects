
## Library Project

- Bu uygulama, bir kütüphanenin kitaplarını yönetmek için tasarlanmıştır. Kullanıcılar, mevcut kitapları görüntüleyebilir, ödünç alabilir ve iade edebilirler. Ayrıca, yeni kitaplar ekleyebilirler.

- .Net 8 kullanılarak geliştirilmiştir.

## Proje Yapısı

* `LibraryProject`  : Uygulamada yapılan tüm işlemler burada yer almaktadır.

## Proje İhtiyaçları

- .Net 8 SDK
- Uyumlu bir IDE


## Kullanılan Teknolojiler:

.NET Core MVC (Web uygulama çatısı)
MSSQL (Veri tabanı)
Entity Framework Core (Veri tabanı işlemleri için ORM)
HTML5, Bootstrap ve jQuery (Arayüz tasarımı ve etkileşimi)

## Kurulum 

.NET Core 8 SDK'nın yüklü olduğundan emin olun.
Bağlantı bilgilerini appsettings.json dosyasında ayarlayın veya kendinize göre entegre edebilirsiniz.
Entity Framework CLI aracını kullanarak veri tabanını oluşturun: dotnet ef database update.
Projeyi çalıştırın.

## Kullanımı

Ana Sayfa:

Ana sayfada mevcut kitaplar listelenir.
Her bir kitabın adı, yazarı, resmi ve mevcut durumu (kütüphanede mi yoksa dışarıda mı) görüntülenir.
Eğer bir kitap dışarıda ise ödünç alan kişinin adı ve geri getirme tarihi gösterilir.
Kitap ödünç almak için "Ödünç Ver" düğmesine basılabilir.
Kitap Ödünç Alma:

Bir kitabı ödünç almak için "Ödünç Ver" düğmesine tıklanır.
Açılan formda ödünç alan kişinin adı ve kitabın ne zaman geri getirileceği sorulur.
Bilgiler girildikten sonra "Kaydet" düğmesine basılarak kitap ödünç alınabilir.

Teslim Et:
Kitap teslim etmek için teslim et butonuna tıklanır.
Sorulan soruya evet denilir.

Yeni Kitap Ekleme:
Yeni bir kitap eklemek için "Kitap Ekle" linkine tıklanır.
Açılan formda kitabın adı, yazarı, resmi ve durumu (kütüphanede mi yoksa dışarıda mı) girilir.
Bilgiler girildikten sonra "Ekle" düğmesine basılarak yeni kitap eklenir.

## Çözümü: 
Veri Tabanı Tasarımı:

MSSQL kullanarak bir veri tabanı oluşturulmuştur. Bu veri tabanında "Books" ve "LogEvent" adında bir tablo bulunmaktadır. 
Uygulama Geliştirme:

.NET Core MVC kullanılarak bir web uygulaması geliştirilmiştir. 
Entity Framework Core kullanılarak veri tabanı işlemleri Repository Design ile gerçekleştirilmiştir.
Bazı durumlarda MVC bazı durumlarda Ajax kullanılmıştır.
FluentValidation, Serilog ve AutoMapper ile uygulama desteklenmiştir.

Arayüz Tasarımı:
HTML5, Bootstrap ve jQuery gibi önyüz araçları kullanılarak kullanıcı dostu bir arayüz tasarlanmıştır.
Arayüzde kullanıcıların kolaylıkla gezinebileceği, işlemleri hızlıca gerçekleştirebileceği ve bütün hata mesajlarını alabileceği bir yapı oluşturulmuştur.

Güvenlik ve Hata Kontrolleri:

Uygulama içerisinde hata ve istisnaların takibi için loglama yapılmıştır.
AntiXss ve AntiForgeryToken ile güvenlik arttırılmıştır.
