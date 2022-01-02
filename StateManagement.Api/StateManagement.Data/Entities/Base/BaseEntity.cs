using System.Text.Json.Serialization;

namespace StateManagement.Data.Entities.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDate = DateTime.UtcNow;
        }

        public int Id { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }
        [JsonIgnore]
        public DateTime? DeleteDate { get; set; }
    }
}
