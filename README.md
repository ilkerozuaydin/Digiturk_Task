
# Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?
- Singleton => Mapster implementasyonu için static bir extension yazıldı.
- Abstract Factory - Factory => Uygulamada değişiklik yaparken en az dokunuş ile client'ı yormadan yapabilmek için, kodun okunabilirliğini artırmak için ve solid prensiplerine uyabilmek için bu pattern uygulandı.
- Repository => CRUD işlemlerini tek bir interface ile belirleyip tüm entity nesnelerimin bundan miras alarak işlemlerin standart ve test edilebilir olmasını sağladım.
- Adapter => Teknoloji bağımlılığını ortadan kaldırmak için kullanıldı. (EntityFramework,SeriLog,Mapster vb kütüphaneleri bir interface ile soyut hale getirildi.)
# Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?
- Autofac => Daha önce kendim için uğraştığım ufak bir projede kullandım.
- Entity Framework Core => Şirket projesinde ve kendi projelerimde kullanıyorum.
- Jwt => Daha önce kendim için uğraştığım ufak bir projede kullandım.
- Mapster => Konfigürasyon yapmamak için bunu kullandım daha önce AutoMapper kullanmıştım.
- Microsoft Memory Cache => Daha önce ufak bir Redis cache denemesi yapmıştım daha hızlı teslim için bunu kullandım.
- Serilog => Daha önce kullanmadım.
# Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?
- Jwt tarafında claimler ekleyerek role göre authorization yapmak isterdim.
- Microsoft Memory Cache yerine Redis ile daha güçlü bir yapıda cache yapmak isterdim.
- Serilog işlemini ElasticSearch'e atıp doğru bir veritabanıyla loglama sistemi kurmak isterdim.
- Entity mappinglerini yapılan iş özelinde daha doğru yapmak isterdim.
- Article nesnesi için araştırma yapıp daha kapsamlı bir yapı kurmak isterdim.
- Comment nesnesi içinde bir hiyerarşi oluşturup iç içe bir yapı kurmak isterdim.
- API katmanında Middleware tarafında loglama yapmak isterdim. 
- IEntity nesnesiyle soft delete pattern uygulamak isterdim.
# Eklemek istediğiniz bir yorumunuz var mı?
- Connection string : "Server=localhost;Database=Blog_Db;User Id=sa;Password=1234;" bu şekildedir appsettings.json dosyasından değiştirmeniz gerekebilir.
- Swagger login olduktan sonra gelen tokenla ile sağ üst kısımdan Authentication'ı başına 'Bearer + [Boşluk] + [Token]' yazarak sağlayabilirsiniz.
