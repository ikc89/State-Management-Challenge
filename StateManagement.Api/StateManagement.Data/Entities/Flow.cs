using StateManagement.Data.Entities.Base;
using System.Text.Json.Serialization;

namespace StateManagement.Data.Entities
{
    public class Flow : BaseEntity
    {
        public Flow()
        {
            States = new List<FlowState>();
            Tasks = new List<Task>();
        }

        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<FlowState> States { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Task> Tasks { get; set; }
    }
}
