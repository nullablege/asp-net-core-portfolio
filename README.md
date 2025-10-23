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
7. Admin Paneli bilgileri admin/admin12345 | /Admin/Register bağlantısından admin hesabı oluşturmak mümkün.

Uygulama içi görseller : 
<img width="3439" height="1219" alt="image" src="https://github.com/user-attachments/assets/cbc7935d-7780-4ef3-ace4-d0d02f399435" />
<img width="3419" height="1244" alt="image" src="https://github.com/user-attachments/assets/bbc21d53-d686-4d52-a540-c6d2d3f14131" />
<img width="3420" height="1219" alt="image" src="https://github.com/user-attachments/assets/7eaae712-8940-4af9-8efc-2bcce6ec7d71" />
<img width="3424" height="1222" alt="image" src="https://github.com/user-attachments/assets/e0352e56-5353-4088-a141-3c928dacfd19" />
<img width="3434" height="1223" alt="image" src="https://github.com/user-attachments/assets/07cb4e3b-f083-4605-9fc7-4adb949d5e86" />
<img width="3429" height="1216" alt="image" src="https://github.com/user-attachments/assets/1052c273-ab6d-4a45-889c-f80cc49ab4f2" />
<img width="3439" height="1222" alt="image" src="https://github.com/user-attachments/assets/f98c3249-31ef-40ee-972d-08928183ac1b" />
<img width="3439" height="1224" alt="image" src="https://github.com/user-attachments/assets/e2b2787d-381c-4916-8c54-f93b7cd63e4f" />
<img width="3413" height="1221" alt="image" src="https://github.com/user-attachments/assets/e9c56d57-ae6d-451c-af0d-50b9a164b766" />
<img width="3422" height="1219" alt="image" src="https://github.com/user-attachments/assets/2d81ba8b-5615-410e-ac3f-c81f751e89ef" />
<img width="3421" height="1222" alt="image" src="https://github.com/user-attachments/assets/1a614bcd-76b4-4c3e-8978-562331647197" />
<img width="3412" height="1217" alt="image" src="https://github.com/user-attachments/assets/0b62d94c-3a7a-495a-868e-8b5ffa1ce572" />
<img width="3410" height="1223" alt="image" src="https://github.com/user-attachments/assets/6cb83f8f-e95a-41f3-adf6-74fd2411a974" />
<img width="3418" height="1221" alt="image" src="https://github.com/user-attachments/assets/432af253-7204-44fc-93b9-104f3d004421" />
<img width="3421" height="1221" alt="image" src="https://github.com/user-attachments/assets/e1762694-0cef-4454-96e4-f1db1108cd1e" />
<img width="3417" height="1222" alt="image" src="https://github.com/user-attachments/assets/2a801aac-ceee-400b-9ed2-2082c80e6a6c" />
<img width="3412" height="1217" alt="image" src="https://github.com/user-attachments/assets/09a7c9b3-bdb0-4450-9d49-134cc576ddc0" /># PortfolioTask1 - Dinamik Portfolyo Projesi
