
# Sipay&Patika.dev .NET Bootcamp Cohort Assignments

# Restful API (Representational State Transfer)

Restful API, web tabanlı uygulamalar arasında iletişimi sağlayan bir programlama arayüzüdür. Bu API'ler, HTTP protokolünü kullanarak kaynaklara (resources) erişim sağlar ve HTTP metodlarını (GET, POST, PUT, DELETE, PATCH vb.) kullanarak kaynaklar üzerinde işlemler gerçekleştirir.

Restful API'ler, REST prensiplerine dayanır. REST, internetin temel yapısal prensiplerinden biridir ve web servislerinin uyumlu, ölçeklenebilir ve genişletilebilir olmasını sağlar. RESTful API'ler, şu prensiplere uygun olarak tasarlanır:

1. Kaynak Odaklı (Resource-Oriented): Restful API'ler, kaynakları temsil eder. Kaynaklar, web uygulamasında işlem gören verileri veya hizmetleri temsil eder. Örneğin, bir e-ticaret uygulamasında "ürünler" veya "siparişler" gibi kaynaklar olabilir.

2. Uniform Interface (Birleşik Arayüz): API'nin birleşik ve tutarlı bir arayüzü olmalıdır. HTTP protokolünün sunduğu standart yöntemleri (GET, POST, PUT, DELETE vb.) kullanarak kaynaklara erişim sağlanır.

3. Stateless (Durumsuz): Sunucu, her isteği bağımsız olarak işler ve istekler arasında durum (state) tutmaz. İstekler, istemci tarafından gerekli tüm bilgileri içermelidir. Sunucu, istekleri işler ve cevapları gönderir, ancak istemciye önceki durum bilgisi vermez.

4. Client-Server (İstemci-Sunucu): İstemciler (client) ve sunucular (server) arasında net bir ayrım vardır. İstemciler, kaynaklara erişmek veya işlem yapmak için istek gönderir. Sunucular, bu istekleri işler ve istemcilere yanıtlarını döner.

5. Cacheable (Önbelleğe Alınabilir): Restful API'ler, HTTP tarafından sağlanan önbellekleme mekanizmalarını kullanarak yanıtları önbelleğe alabilir. Böylece aynı istekler için tekrar tekrar sunucuya gitmek yerine, istemciler önbelleğe alınan yanıtları kullanabilir.

Restful API'ler, verileri JSON veya XML gibi veri formatlarında taşıyabilir. Genellikle JSON tercih edilen formattır, çünkü daha hafiftir ve daha kolay okunabilir.

Restful API'ler, istemcilerin sunucudaki kaynaklara standart HTTP metodlarıyla erişmesini sağlayarak veri entegrasyonunu ve işbirliğini kolaylaştırır. Bu API'ler, farklı platformlar ve programlama dilleri arasında veri alışverişini sağlayarak uygulama entegrasyonunu destekler.

---
# HTTP durum kodları (HTTP status codes) 
Bir HTTP isteğinin veya yanıtın durumunu belirten üç haneli sayılardır. Bu durum kodları, istemcinin ve sunucunun birbirleriyle iletişim kurmasını ve anlamasını sağlar. Her durum kodu, belirli bir anlamı temsil eder ve HTTP protokolü üzerinde standartlaşmıştır.


![statuscodes](https://github.com/BuseBeker/sipay-net-bootcamp-cohort-assignments/assets/72763515/ef46ecfd-4be4-4430-89d7-d354a8568866)

İşte bazı yaygın HTTP durum kodları ve anlamları:

- 1xx İnformational (Bilgilendirme): İsteğin alındığı ve işlendiği, ancak yanıtın tamamlanmadığı durumları ifade eder.

- 2xx Success (Başarı): İsteğin başarıyla gerçekleştiği durumları ifade eder. En yaygın kullanılan durum kodları şunlardır:
  - 200 OK: İstek başarılı bir şekilde tamamlandı.
  - 201 Created: İstek nesnesi başarıyla oluşturuldu.
  - 204 No Content: İstek başarılı bir şekilde tamamlandı, ancak yanıtta içerik yok.

- 3xx Redirection (Yönlendirme): İstemcinin ek eylemler yapması gereken durumları ifade eder. En yaygın kullanılan durum kodları şunlardır:
  - 301 Moved Permanently: Kaynak kalıcı olarak yeni bir yerde bulunuyor ve gelecekte istemcinin yeni yeri kullanması gerekiyor.
  - 302 Found: Kaynak geçici olarak başka bir yerde bulunuyor ve istemcinin oraya yönlendirilmesi gerekiyor.

- 4xx Client Error (İstemci Hatası): İstemcinin yanlış bir şekilde istek gönderdiği durumları ifade eder. En yaygın kullanılan durum kodları şunlardır:
  - 400 Bad Request: İstek doğru bir şekilde işlenemedi veya geçersiz veri içeriyor.
  - 401 Unauthorized: İstemcinin kimlik doğrulaması gerekiyor.
  - 404 Not Found: İstenen kaynak bulunamadı.

- 5xx Server Error (Sunucu Hatası): Sunucunun isteği işleyemediği durumları ifade eder. En yaygın kullanılan durum kodları şunlardır:
  - 500 Internal Server Error: Sunucu tarafında bir hata oluştu.
  - 503 Service Unavailable: Sunucu geçici olarak hizmet veremiyor.

---

# Error handler
Bir uygulamanın hata durumlarını ele almak için kullanılan bir mekanizmadır. Bir istek sırasında ortaya çıkan hataları yakalar ve uygun bir şekilde yanıt verir. Error handler'lar, istemciye daha anlamlı hata mesajları sunarak hata ayıklamayı kolaylaştırır ve kullanıcı deneyimini iyileştirir.

Bir RESTful API'de, error handler, istemciden gelen istekleri işlerken ortaya çıkabilecek hataları yakalar ve uygun HTTP durum kodlarıyla yanıtlar. Örneğin, bir istemci hatalı bir istek gönderdiğinde, error handler bu durumu yakalar ve 400 Bad Request durum kodunu yanıt olarak gönderir. Benzer şekilde, sunucu taraflı hatalarda ise error handler, 500 Internal Server Error gibi uygun bir durum koduyla yanıt verir.

Error handler'lar, hataları loglama, hata mesajlarını kaydetme, istatistikleri toplama gibi ek işlemleri de gerçekleştirebilir. Bu sayede uygulamanın sağlığı ve sorun giderme süreçleri için önemli bir rol oynar.

---
# Routing (Yönlendirme)
Web uygulamalarında gelen isteklerin belirli bir URL yapısına göre doğru işleyicilere yönlendirilmesini sağlayan bir mekanizmadır. Yani, bir istemci tarafından yapılan HTTP isteği, doğru işleyiciye veya kontrolcüye yönlendirilir ve bu işleyici isteği işler.

Routing, web uygulamasında URL'leri (Uniform Resource Locator) belirli işlemlere veya kaynaklara bağlar. İstemcilerin belirli bir URL ile istek göndermesi durumunda, bu istek belirli bir işleyici veya işlemi tetikler.

ASP.NET ve diğer web framework'leri, routing mekanizmaları sunarak bu işlevselliği sağlar. Routing, genellikle URL pattern'leri ve HTTP metotlarına dayalı olarak çalışır. URL pattern'leri, belirli bir URL yapısını ve parametreleri tanımlamak için kullanılır.

Örneğin, bir RESTful API'nin routing yapısı aşağıdaki gibi olabilir:






    [Route("api/[controller]")]
    public class ProductsController : ControllerBase

    {
      [HttpGet]
      public IActionResult Get()
    
      {
    
          // Ürünleri listeleme işlemi
    
      }
    
      [HttpGet("{id}")]
      public IActionResult Get(int id)
      {
          // Belirli bir ürünü getirme işlemi
      }

      [HttpPost]
      public IActionResult Post([FromBody] Product product)
      {
          // Yeni bir ürün oluşturma işlemi
      }

      [HttpPut("{id}")]
      public IActionResult Put(int id, [FromBody] Product product)
      {
          // Belirli bir ürünü güncelleme işlemi
      }

      [HttpDelete("{id}")]
      public IActionResult Delete(int id)
      {
          // Belirli bir ürünü silme işlemi
      }}



Yukarıdaki örnekte, `ProductsController` sınıfı `api/products` yoluna (`Route` özniteliğiyle belirtilmiştir) sahiptir. Bu yol altında, `HttpGet`, `HttpPost`, `HttpPut` ve `HttpDelete` gibi HTTP metotlarına göre işleyiciler tanımlanmıştır. Örneğin, `HttpGet("{id}")` metodu, `api/products/{id}` yolunu hedefler ve belirli bir ürünü getirme işlemini gerçekleştirir.

Routing, istemcilerin doğru URL'leri kullanarak isteklerini yönlendirmesini ve sunucunun bu istekleri doğru işleyicilere ileterek işlemesini sağlar. Bu sayede, web uygulamalarında modüler yapılar oluşturulabilir ve belirli işlevlere sahip olan kaynaklar veya işlemler kolayca hedeflenebilir.

---
# Model binding İşlemleri Body'den ve Query'den Yapılması 

Bir Restful API'nin istemciden gelen verileri alırken hem HTTP isteğinin body kısmından (genellikle JSON veya XML formatında) hem de query parametrelerinden (URL üzerindeki parametrelerden) veri alma yeteneğini ifade eder.

Örneğin, bir kitap kaydetmek için POST isteği göndermek isteyen bir istemci, kitap verilerini hem isteğin body kısmına gömebilir (JSON formatında) hem de query parametreleri olarak URL'ye ekleyebilir. Bu durumda, API'nin model binding işlemi, hem body'den gelen verileri hem de query parametrelerini alacak şekilde yapılandırılmalıdır.

Aşağıda, C# ve ASP.NET Web API kullanarak model binding işlemlerini hem body'den hem de query'den yapmanın bir örneği verilmiştir:


 
    [HttpPost("books")]
    public IActionResult AddBook([FromBody] Book book, [FromQuery] string category)
 
    {
      
      // HTTP isteği gövdesinden (body) gelen JSON verisi "Book" modeline model binding ile bağlanır.
      // URL'deki query parametresi "category" değişkenine model binding ile bağlanır.
    
      // Verileri işleme ve kaydetme işlemleri burada gerçekleştirilir.
    
      return Ok(); 
     }


Yukarıdaki örnekte, `AddBook` isimli bir POST metoduna sahip bir Web API kontrolcüsü yer almaktadır. Metodun parametreleri arasında `[FromBody] Book book` ve `[FromQuery] string category` bulunmaktadır.

`[FromBody] Book book` ifadesi, HTTP isteğinin body kısmından gelen verilerin "Book" modeline model binding ile bağlanacağını belirtir.

`[FromQuery] string category` ifadesi ise URL'deki query parametrelerinden "category" adlı parametrenin "string" tipine model binding ile bağlanacağını belirtir.

Bu sayede, istemci hem isteğin body kısmında kitap verilerini gönderebilir hem de URL'deki query parametrelerini kullanarak kategori bilgisini iletebilir. API, her iki veri kaynağını da model binding ile alır ve bu verilere erişebilir.

Umarım bu açıklama, model binding işlemlerinin hem body'den hem de query'den nasıl yapılacağını anlamanıza yardımcı olmuştur.
