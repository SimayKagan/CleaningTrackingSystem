#Cleaning Tracking System Management API / Temizlik Takip Sistemi Yönetim API'si

[Türkçe]

Bu proje, bir kurumun binalarındaki temizlik süreçlerinin, katların, tuvalet alanlarının ve bu alanlara tanımlı QR kodlarının yönetimini sağlayan admin taraflı bir ASP.NET Core Web API projesidir.

Kullanılan Teknolojiler;
* Framework : .NET 9 /ASP.NET CORE Web API
* ORM: Entity Framework Core(Code First)
* Veritabanı : MySQL
* Dökümantasyon ve Test : Swagger / OpenAPI
* Kütüphaneler: QRCoder (QR Kod üretimi için)

Projedeki Ana Varlıklar (Entities) ve İlişkileri;
* Building (Bina): Sistemdeki binaları temsil eder. Bir binanın birden fazla katı olabilir (1 - N).
* Floor (Kat): Binalara bağlı katları temsil eder. Bir katta birden fazla tuvalet olabilir (1 - N).
* Restroom (Tuvalet): Temizlik takibi yapılacak tuvalet alanlarını tutar.
* QRCode (Qr Kod): Tuvaletlere özgü benzersiz QR kodlar vardır her tuvaletteki QR kod birbirinden farklıdır (1 - 1).

Öne Çıkan Özellikler;

* Her tuvalet için sistemde yalnızca 1 aktif QR kod tanımlanabilir. İkinci bir kayıt eklenmek istenirse sistem hata döndürür.
* QR kod oluşturulduğunda sistem otomatik olarak benzersiz bir metin üretir ve `wwwroot/qrcodes` dizinine `.png` formatında kaydeder.
* Silme ve güncelleme işlemlerinde veri bütünlüğü Foreign Key kurallarıyla korunur.

API Testleri ve Kullanımı;

Proje çalıştırıldığında Swagger arayüzü üzerinden aşağıdaki HTTP istekleri test edilebilir;

Bina (Buildings) İşlemleri

* `POST /api/Buildings` -> Yeni Bina Ekler.
* `GET /api/Buildings` -> Tüm Binaları Listeler.
* `GET /api/Buildings/{id}` -> ID'ye Göre Bina Detaylarını Getirir.
* `PUT /api/Buildings/{id}` -> Bina Bilgisini Günceller.
* `DELETE /api/Buildings/{id}` -> Binayı Sistemden Siler.

Kat (Floors) İşlemleri
* `POST /api/Floors` -> Binaya Bağlı Kat Ekler.
* `GET /api/Floors` -> Tüm Katları Listeler.
* `GET /api/Floors/{id}` -> ID'ye Göre Kat Detaylarını Getirir.
* `PUT /api/Floors/{id}` -> Kat Bilgisini Günceller.
* `DELETE /api/Floors/{id}` -> Katı Sistemden Siler.

Tuvalet (Restrooms) İşlemleri
* `POST /api/Restrooms` -> Kata Bağlı Tuvalet Ekler.
* `GET /api/Restrooms` -> Tüm Tuvaletleri Listeler.
* `GET /api/Restrooms/{id}` -> ID'ye Göre Tuvalet Detaylarını Getirir.
* `PUT /api/Restrooms/{id}` -> Tuvalet Bilgisini Günceller.
* `DELETE /api/Restrooms/{id}` -> Tuvaleti Sistemden Siler.

QR Kod (QRCodes) İşlemleri
* `POST /api/QRCodes` -> Tuvalete Bağlı Benzersiz Bir QR Kod Oluşturur.
* `GET /api/QRCodes` -> Tüm QR Kod Kayıtlarını Listeler.
* `GET /api/QRCodes/{id}` -> ID'ye Göre QR Kod Detayını Getirir.
* `GET /api/QRCodes/Restroom/{restroomId}` -> Tuvalete Ait QR Kod Detayını Sorgular.
* `DELETE /api/QRCodes/{id}` -> QR Kod Kaydını ve Sistemdeki İlişkisini Siler.

#NOT: Projenin çalışabilmesi için appsettings.json dosyasında username ve password olarak belirtilen yerlere kendi MySQL kullanıcı adı ve şifrenizi yazmalısınız.

[English]

This project is an ASP.NET Core Web API designed to manage cleaning processes, buildings, floors, restrooms and unique qr codes assigned to each restroom areas in institutions and buildings.

Tech Stack;
* Framework : .NET 9 /ASP.NET CORE Web API
* ORM: Entity Framework Core(Code First)
* Database : MySQL
* Documentation and Test : Swagger / OpenAPI
* Libraries: QRCoder (For QR Code Generation)

Data Architecture and Relationships in the Project;
* Building: Represents the buildings in the system (1 - N Floor Relationship).
* Floor: Represents floors linked to buildings  (1 - N restroom relationship).
* Restroom: Stores restroom locations for cleaning tracking.
* QRCode: Stores unique QR code data and '.png' image paths generated for restrooms (1 - 1 Relationship).

Key Features;

* For each restroom only 1 active QR code can be assigned.
* When a QR code created is generated, the system automatically produces an unique text and saves it in `wwwroot/qrcodes` directory in `.png` format.
* Data integrity during deletion and update is maintained by using Foreign Key constraints.

API Tests;

When the project is run, the following HTTP requests can be tested via the Swagger interface.

Building Operations

* `POST /api/Buildings` -> Adds New Building.
* `GET /api/Buildings` -> Lists All Of The Buildings.
* `GET /api/Buildings/{id}` -> Gets The Building Details By ID.
* `PUT /api/Buildings/{id}` -> Updates The Building Information.
* `DELETE /api/Buildings/{id}` -> Deletes The Building From The System.

Floor Operations
* `POST /api/Floors` -> Adds new Floor Tied To The Building.
* `GET /api/Floors` -> Lists All Of The Floors.
* `GET /api/Floors/{id}` -> Gets The Floor Details By ID
* `PUT /api/Floors/{id}` -> Updates The Floor Information.
* `DELETE /api/Floors/{id}` -> Deletes The Floor From The System.

Restroom Operations
* `POST /api/Restrooms` -> Adds new Restroom Tied To The Floor.
* `GET /api/Restrooms` -> Lists All Of The Restrooms.
* `GET /api/Restrooms/{id}` -> Gets The Restroom Details By ID
* `PUT /api/Restrooms/{id}` -> Updates The Restroom Information.
* `DELETE /api/Restrooms/{id}` -> Deletes The Restroom From The System.

QR Code Operations
* `POST /api/QRCodes` -> Generates A Unique QR Code and Image.
* `GET /api/QRCodes` -> Lists All The QR Codes.
* `GET /api/QRCodes/{id}` -> Gets The QR Code Details By ID
* `GET /api/QRCodes/Restroom/{restroomId}` -> Gets The QR Code Details By Restroom ID
* `DELETE /api/QRCodes/{id}` -> Deletes The QR Code From The System.

#NOTE: You need to write your own MySQL username and password to the spesified locations in appsetting.json for this project to run.


