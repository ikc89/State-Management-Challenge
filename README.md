# State Management Uygulaması

State management uygulaması bir state yönetimi uygulamasıdır ve;

- Task, State ve Flow yaratma
- Task durumunu güncelleme ve görüntüleme
- Task'ı **t** anındaki durumuna geri alma

işlemlerini yapmaktadır.

## Hikaye

Diyelim ki 4 adet `State` (`StateA`, `StateB`, `StateC` ve `StateD`) ve
`StateA` durumunda olan bir adet `Task` yaratıyoruz (`Task1`).

Sonra bir `Task`'ın izleyeceği yolu belirlemek için bir `Flow` yaratıyoruz
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
> `StateB`'ye _geçemez_.
> 

---

| StateA | StateB        | StateC | StateD |
| ------ | ------------- | ------ | ------ |
|        | <-- Task1 --> |        |        |

`Task1` bulunduğu durumdan _bir önceki_ ya da  _bir sonraki_ duruma geçebilir.
Yani `Task1`, `StateB`'den `StateC`'ye ya da `StateA`'ya geçebilir ancak
`StateD`'ye geçemez.

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

Uygulamayı yalnızca API Backend olarak yazabilirsiniz. Opsiyonel olarak
kullanıcı arayüzü de geliştirebilirsiniz.

#### Backend

Uygulama üzerindeki `Task`, `State`, `Flow` nesneleri `CREATE`, `READ`,
`UPDATE`, `DELETE` ve diğer işlemleri için API çağrıları kullanılacaktır.

[Restful Methods](https://restfulapi.net/http-methods/)

#### Frontend

- `/`: Kullanıcı `/flows` adresine yönlendirilir
- `/flows`: Oluşturulmuş tüm akışlar listelenir, tıklandığında `/flows/{id}`
  adresine yönlendirilir
- `/flows/{id}`: İlgili `Flow` altındaki `State`'ler gösterilir. Her birinin
  altındaki `Task`'lar gösterilir ve `Task`'ların akışa uygun şekilde durumlar
  arasında gezdirilmesi sağlanır.

Dilerseniz diğer işlemler için de önyüz hazırlayabilirsiniz, size bırakıyoruz.

### Teknik gereksinimler

#### Teknolojiler

- Platform: .NET Core 2 ve üstü
- IoC Kütüphanesi: Herhangi bir IoC container kullanılabilir.
- ORM Kütüphanesi: Herhangi bir kütüphane kullanılabilir.
- Database: Herhangi bir database.
- API (ve kullanılan diğer toollar) docker üzerinde run edilebilir.
- UI için [Vue.js](https://vuejs.org/) ya da `React`(https://reactjs.org/)
  kullanılabilir.

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

