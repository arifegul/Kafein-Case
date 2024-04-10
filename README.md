**Proje Tanımı**

Bu proje, bir e-ticaret projesinin belirli bir kısmına odaklanmıştır. .NET Core 8.0 kullanılarak geliştirilmiş olup, onion mimarisi ve SOLID prensiplerine uygun olarak tasarlanmıştır. Proje, Entity Framework Code-First yapısını kullanarak veritabanı işlemlerini gerçekleştirirken, RabbitMQ aracılığıyla mail gönderimi sağlamaktadır. MSSQL ise kullanılan veritabanıdır ve başlangıç için mock verilerle hazırlanmıştır. CRUD işlemleri de projeye dahil edilmiştir.

**Kapsam ve Amaç**

Bu projenin temel amacı, sistem yoğunluğu fazla olan uygulamalar için en uygun yöntemi sunarak kullanıcıya sipariş faturalarının gönderilmesini sağlamaktır.

**Teknik Detaylar**

- **Onion Mimarisi:** Katmanlar arası bağımlılıkları minimize eder ve kodun daha düzenli ve anlaşılır olmasını sağlar.
- **SOLID Prensipleri:** Yazılımın okunabilirliğini, esnekliğini ve bakımını kolaylaştırır.
- **.NET Core 8.0:** Yeni özellikler ve performans iyileştirmeleriyle güçlendirilmiş bir platform.
- **Entity Framework Code-First:** Veritabanı modellemesi kodlar üzerinden yapılarak, veritabanı işlemleri Entity Framework ile gerçekleştirilir.
- **RabbitMQ:** Asenkron mesajlaşma için kullanılır ve mail gönderimi gibi yoğun işlemleri işlemek için idealdir.
- **MSSQL:** İlişkisel veritabanı olarak kullanılmış ve Entity Framework ile entegre edilmiştir.
- **Data:** Geliştirme aşamalarında kolaylık sağlamak için mock veriler kullanılmıştır. Ancak isteğe bağlı olarak yeni veri eklemek mümkündür.

**Sonuç**

Bu belge, .NET Core 8.0 kullanılarak geliştirilen bir e-ticaret projesinin temel adımlarını ve teknolojik bileşenlerini açıklamaktadır. Projede kullanılan teknolojiler ve mimari yaklaşımlar sayesinde güçlü, esnek ve performanslı bir proje geliştirilmiştir. RabbitMQ kullanılarak asenkron mail gönderimi gibi kritik işlemler de başarılı bir şekilde gerçekleştirilmektedir.


