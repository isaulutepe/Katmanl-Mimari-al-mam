# Katmanlı Mimari Çalışmam

 Online Kurs Yönetim Sistemi - Katmanlı Mimari ve Web API

Bu proje, katmanlı mimariyi kullanarak geliştirilen bir online kurs yönetim sistemidir. Platform, öğrencilerin kurslara kaydolabileceği, kurs detaylarını görebileceği ve kurs satın alma işlemlerini yürütebileceği bir yapı sunar.

##  Proje Yapısı

Proje, aşağıdaki temel katmanlardan oluşmaktadır:

* **Entity Katmanı**: Veri modelleri (Student, Course, Enrollment).
* **Data Access Katmanı**: Veritabanı işlemleri (CRUD).
* **Business Katmanı**: İş kuralları ve mantıksal kontrol işlemleri.
* **API Katmanı**: RESTful API endpoint'leri.

##  Temel İşlevler

### ‍ Öğrenci İşlemleri

* 🟢 Öğrenci ekleyebilme, listeleyebilme, güncelleyebilme ve silebilme.
* 🟢 Ad, soyad ve e-posta adresi bilgileri.
* 🟢 ID üzerinden tekil erişim.

###  Kurs İşlemleri

* 🟠 Kurs ekleyebilme, listeleyebilme, güncelleyebilme ve silebilme.
* 🟠 Ad, açıklama, fiyat, başlangıç ve bitiş tarihi bilgileri.
* 🟠 ID üzerinden tekil erişim.

###  Kayıt İşlemleri

* Öğrenciler kurslara kayıt olabilir.
* Aynı öğrenci aynı kursa birden fazla kez kaydolamaz.
* Öğrencinin bakiyesi kurs ücretinden düşükse kayıt yapılamaz.

##  API Endpoint'leri

| İşlem               | HTTP Metodu | Endpoint                                     |
| :------------------ | :---------- | :--------------------                        |
| Öğrenci Listele     | `GET`       | `/api/ogrenci`                               |
| Tekil Öğrenci Getir | `GET`       | `/api/ogrenci/{id}`                          |
| Öğrenci Ekle        | `POST`      | `/api/ogrenci`                               |
| Öğrenci Güncelle    | `PUT`       | `/api/ogrenci/{id}`                          |
| Öğrenci Sil         | `DELETE`    | `/api/ogrenci/{id}`                          |
| Kurs Listele        | `GET`       | `/api/kurs`                                  |
| Tekil Kurs Getir    | `GET`       | `/api/kurs/{id}`                             |
| Kurs Ekle           | `POST`      | `/api/kurs`                                  |  
| Kurs Güncelle       | `PUT`       | `/api/kurs/{id}`                             |
| Kurs Sil            | `DELETE`    | `/api/kurs/{id}`                             |
| Kayıt Ekle          | `POST`      | `/api/kayit?ogrenciId={id}&kursId={id}`      |
| Kayıt Sil           | `DELETE`    | `/api/kayit/{id}`                            |
| Kurs Güncelle       | `PUT`       | `/api/kayit/{id}`                            |
| Kurs Listele        | `GET`       | `/api/kayit`                                 |
| Tekil Kurs Getir    | `GET`       | `/api/kayit/{id}`                            |
