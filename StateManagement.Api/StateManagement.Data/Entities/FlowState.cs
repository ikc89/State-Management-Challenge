using StateManagement.Data.Entities.Base;
using System.Text.Json.Serialization;

namespace StateManagement.Data.Entities
{
    public class FlowState : BaseEntity
    {
        public int FlowId { get; set; }
        public int StateId { get; set; }
        public int Order { get; set; }
        
        [JsonIgnore]
        public virtual Flow Flow {  get; set; }
        public virtual State State { get; set; }
    }
}
