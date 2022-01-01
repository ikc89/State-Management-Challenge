# State Management Uygulaması

State management uygulaması bir state yönetimi API uygulamasıdır ve;

- Task, State ve Flow yaratma
- Task durumunu güncelleme ve görüntüleme
- Task'ı **t** anındaki durumuna geri alma

işlemlerini yapmaktadır.

## Hikaye

Diyelim ki 4 adet `State` (`StateA`, `StateB`, `StateC` ve `StateD`) ve
`StateA` durumunda olan bir adet `Task` yaratıyoruz (`Task1`).

Sonra bir `Task`ın izleyeceği yolu belirlemek için bir `Flow` yaratıyoruz
(`FLowX`), bu sayede `StateA` <--> `StateB` <--> `StateC` <--> `StateD` akışı
mümkün oluyor.

| StateA | StateB | StateC | StateD |
| ------ | ------ | ------ | ------ |
| Task1  |        |        |        |

Bu `Flow` gereği `Task1`, `StateA`'dan `StateB`'ye geçebilir ancak `StateC`'ye
_geçemez_. 

> 
> Ama flow'u bu şekilde de düzenleyebilirdik;
> 
> | StateA | StateC | StateB | StateD |
> | ------ | ------ | ------ | ------ |
> | Task1  |        |        |        |
> 
> `Task1` artık `StateA`'dan `StateC`'ye geçebilir ancak `StateA`'dan
> `StateB`ye _geçemez_.
> 

---

| StateA | StateB        | StateC | StateD |
| ------ | ------------- | ------ | ------ |
|        | <-- Task1 --> |        |        |

`Task1` bulunduğu durumdan _bir önceki_ duruma dönebilir ve _bir sonraki_
duruma geçebilir. Yani `Task1`, `StateB`'den `StateC`'ye ya da `StateA`'ya
geçebilir ancak `StateD`'ye geçemez.

---

Farklı bir `Flow` yaratıp onun içerisinde de farklı tasklar yürütebilirim.

| StateA | StateC | StateD | StateB |
| ------ | ------ | ------ | ------ |
| Task1  |        |        |        |
| Task2  |        |        |        |

| StateX | StateY | StateZ | StateQ |
| ------ | ------ | ------ | ------ |
| Task3  |        |        |        |
| Task4  |        |        |        |

---

Bir `Task` herhangi bir **t** anındaki durumuna geri döndürülebilir olmalıdır.

---

### Teknik Açıklama

Uygulama üzerindeki `Task`, `State`, `Flow` nesneleri `CREATE`, `READ`,
`UPDATE`, `DELETE` ve diğer işlemleri için API çağrıları kullanılacaktır.

[Restful Methods](https://restfulapi.net/http-methods/)

### Teknik gereksinimler

#### Teknolojiler

- Platform: .NET Core 2 ve üstü
- IoC Kütüphanesi: Herhangi bir IoC container kullanılabilir.
- ORM Kütüphanesi: Herhangi bir kütüphane kullanılabilir.
- Database: Herhangi bir database.
- API (ve kullanılan diğer toollar) docker üzerinde run edilebilir.

#### Dependency Injection

- ApiController sınıfları da dahil olmak üzere tüm sınıflar Dependency
  Injenction ile sağlanmalıdır.

#### Repository Pattern

- Servis katmanı ile veri erişim katmanı ayrıştırılmalıdır.

### İpucu

- Clean code güzel hazırlanmış bir pazar kahvaltısı gibidir.
- Unit test yazmak hava biraz kapalı olsa bile yanına şemsiyesini alan bir
  insanın tutumu gibidir.
- Bir entitynin durumuna event-centric yaklaşmak güzel bir bakış açısıdır.
- Swagger yararlı bir API doc tooludur.
- Her commit projeye yapılan anlamlı bir eklemedir.

### Teslim

- Bu repository'i fork edip, kendi Github hesabınız üzerinden geliştirmeyi
  yapınız. 
- İlk commitinizi `initial commit` mesajıyla gönderiniz ve tüm projeyi max 4
  gün içinde bitirmeniz beklenmektedir.
- Projeyi tamamladığınızda sizinle iletişim kuran kişiye e-posta olarak dönüş
  yapınız.

