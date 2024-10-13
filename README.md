# CleanArch.Core

## Proje Amacı
Bu proje, Clean Architecture prensiplerine uygun bir şekilde genel bir altyapı katmanı sunar. Farklı domain ve iş kurallarından bağımsızdır, bu yüzden restoran otomasyonu veya araç galerisi gibi farklı projelere kolayca entegre edilebilir.

## Katmanlar

### 1. **Core.Application**
- **Common**: Genel kullanım için yardımcı sınıflar ve uzantılar.
  - `DateTimeHelper.cs`, `ValidationHelper.cs` gibi sınıfları içerir.
- **Middlewares**: Hata yönetimi middleware sınıfı.
  - `ExceptionHandlingMiddleware.cs`
- **Exceptions**: Uygulama genelinde kullanılan özel hata sınıfları.
  - `NotFoundException.cs`, `ValidationException.cs` vb.
  
### 2. **Core.Infrastructure**
- **Caching**: Cache işlemleri için kullanılan yönetici sınıflar.
  - `MemoryCacheManager.cs`: Bellek tabanlı cache yönetimi.
  - `RedisCacheManager.cs`: Redis tabanlı cache yönetimi.
- **Data**: Sayfalama ve veri yönetimi işlemleri.
  - `Paginate.cs`, `BasePageableModel.cs` vb.
- **Repositories**: Genel repository yapıları ve entity tanımları.
  - `EfRepositoryBase.cs`: Entity Framework tabanlı genel repository.
- **Services**: E-posta gönderim gibi genel servisler.
  - `SmtpEmailSender.cs`

## Bağımlılıklar
- **Entity Framework Core**
- **StackExchange.Redis**
