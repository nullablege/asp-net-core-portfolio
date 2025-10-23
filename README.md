# PortfolioTask1 - Dinamik Portfolyo Projesi

Bu proje, M&Y Akademi Full Stack Bootcamp kapsamında geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Proje, "Clark" adlı bir web şablonunu dinamik hale getirerek, tüm içeriğin bir yönetici paneli üzerinden veritabanı aracılığıyla yönetilmesini sağlayan bir kişisel portfolyo sitesidir.

## Proje Hakkında

Projenin temel amacı, statik bir HTML portfolyo temasını, ASP.NET Core MVC mimarisi ve Entity Framework Core kullanarak tam donanımlı, veritabanı destekli bir web uygulamasına dönüştürmektir. Proje iki ana bölümden oluşmaktadır:

1.  **Public Portfolyo Arayüzü (Home):** Ziyaretçilerin portfolyo sahibinin bilgilerini, yeteneklerini, projelerini ve özgeçmişini görüntüleyebildiği, ayrıca iletişim formu gönderebildiği dinamik ön yüz.
2.  **Yönetim Paneli (Admin):** Portfolyo sitesinde görüntülenen tüm dinamik içeriği yönetmek (Ekle, Sil, Güncelle), istatistikleri görmek ve gelen iletişim formu mesajlarını okumak için kullanılan, kimlik doğrulaması ile korunan güvenli bir arka uç.

## Temel Teknolojiler

* **Framework:** .NET 8.0
* **Mimari:** ASP.NET Core MVC (`AddControllersWithViews`)
* **Veritabanı:** SQL Server (`UseSqlServer`)
* **ORM:** Entity Framework Core
* **Kimlik Doğrulama:** ASP.NET Core Identity (Cookie tabanlı)
* **Ön Yüz:** "Clark" Bootstrap 4 Teması (HTML/CSS/JS)

## Özellikler

Proje, hem ziyaretçi hem de yönetici için zengin bir özellik seti sunar.

### 1. Public Portfolyo Sitesi (`HomeController`)

* **Dinamik Veri Gösterimi:** Ana sayfa, veritabanından çekilen verilerle `HomeViewModel` aracılığıyla beslenir.
* **Dinamik Bölümler:**
    * **Slider:** Ana sayfadaki slider görselleri ve metinleri veritabanından gelir (`Sliders`).
    * **Hakkımda:** "Hakkımda" bölümünün içeriği veritabanından yönetilir (`AboutMe`).
    * **Özgeçmiş:** Eğitim ve deneyim gibi özgeçmiş bilgileri dinamik olarak listelenir (`Ozgecmisler`).
    * **Yetenekler:** Yetenekler ve bu yeteneklerin seviyeleri (progress bar) veritabanından yüklenir (`Yetenekler`).
    * **Projeler:** Tamamlanan projeler bir galeri yapısında sergilenir (`Projeler`).
    * **Sayaçlar ve İletişim Bilgileri:** Proje sayısı, mutlu müşteri sayısı gibi sayaçlar ve altbilgi/iletişim bilgileri `GenelBilgiler` tablosundan dinamik olarak gelir.
* **İletişim Formu:** Ziyaretçilerin mesaj gönderebileceği bir iletişim formu (`iletisimEkle` action) bulunmaktadır. Gönderilen mesajlar doğrudan veritabanına kaydedilir.
* **Statik Bölüm:** "Hizmetlerim" bölümü, diğer bölümlerden farklı olarak `Index.cshtml` içerisinde statik (hard-coded) olarak yer almaktadır.

### 2. Yönetim Paneli (`AdminController`)

* **Güvenlik:** Tüm admin sayfaları `[Authorize]` attribute'u ile korunmaktadır. Yetkisiz erişimler `/Admin/Login` sayfasına yönlendirilir.
* **Kimlik Yönetimi (Identity):**
    * **Register:** Yeni bir admin kullanıcısı oluşturmak için `[AllowAnonymous]` olarak ayarlanmış bir kayıt sayfası mevcuttur.
    * **Login:** Güvenli giriş (`PasswordSignInAsync`) ve çıkış (`SignOutAsync`) işlemleri.
* **Admin Dashboard:**
    * Giriş yapıldığında admini bir özet paneli (`AdminDashboardViewModel`) karşılar.
    * Panelde toplam proje sayısı (`projeSayisi`), yetenek sayısı (`yetenekSayisi`), okunmamış mesaj sayısı (`okunmamisMesajSayisi`) ve slider görseli sayısı (`sliderSayisi`) gibi istatistikler yer alır.
    * Ayrıca son gelen mesajlar (`sonMesajlar`) ve son eklenen projeler (`sonProjeler`) listelenir.
* **İçerik Yönetimi (CRUD):**
    * Sitedeki *tüm* dinamik içerikler için tam Ekleme, Silme, Görüntüleme ve Güncelleme (CRUD) işlemleri mevcuttur.
    * **Yönetilen Modüller:**
        * Genel Ayarlar (`Genel`)
        * Hakkımda (`Hakkimda`)
        * Özgeçmiş (`Ozgecmis`, `OzgecmisEkle`, `OzgecmisDuzenle`, `OzgecmisSil`)
        * Projeler (`Projeler`, `ProjeEkle`, `ProjeDuzenle`, `ProjeSil`)
        * Yetenekler (`Yetenekler`, `YetenekEkle`, `YetenekDuzenle`, `YetenekSil`)
        * Slider (`Slider`, `SliderEkle`, `SliderDuzenle`, `SliderSİl`)
* **Mesaj Yönetimi (İletişim):**
    * Ziyaretçilerden gelen iletişim formu mesajları (`Iletisim`) listelenir.
    * Mesajlar "Okundu" / "Okunmadı" olarak işaretlenebilir (`IletisimMesajGoruldu`).
    * Mesajlar sistemden silinebilir (`IletisimMesajSil`).

## Veritabanı Yapısı (`Context.cs`)

Entity Framework Core, aşağıdaki `DbSet` özellikleri aracılığıyla veritabanı tablolarını yönetir:

* `Genels` (Sitenin genel bilgileri ve sayaçları)
* `Hakkimdas` (Hakkımda sayfası içeriği)
* `ıletisimForms` (Gelen iletişim mesajları)
* `Ozgecmiss` (Özgeçmiş kalemleri - eğitim/deneyim)
* `Projelerims` (Portfolyo projeleri)
* `Yeteneklerims` (Yetenek listesi ve seviyeleri)
* `Sliders` (Ana sayfa slider içerikleri)

Proje ayrıca `IdentityDbContext<AppUser>` sınıfından miras alarak ASP.NET Core Identity tablolarını (Kullanıcılar, Roller vb.) aynı veritabanında yönetir.

## Kurulum ve Çalıştırma

1.  Proje dosyalarını klonlayın.
2.  `PortfolioTask1/appsettings.json` dosyası içerisindeki `DefaultConnection` adlı connection string'i kendi SQL Server yapılandırmanıza göre güncelleyin.
3.  Package Manager Console (PMC) üzerinden `Update-Database` komutunu çalıştırarak veritabanı tablolarının (hem içerik hem de Identity tabloları) oluşturulmasını sağlayın.
4.  Uygulamayı çalıştırın (`dotnet run` veya Visual Studio üzerinden IIS Express).
5.  İlk yönetici kullanıcısını oluşturmak için `/Admin/Register` adresine gidin ve kayıt olun.
6.  Kayıt olduktan sonra `/Admin/Login` adresinden giriş yaparak yönetim panelini kullanmaya başlayabilirsiniz.
