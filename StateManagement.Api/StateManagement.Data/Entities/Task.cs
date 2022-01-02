using StateManagement.Data.Entities.Base;
using System.Text.Json.Serialization;

namespace StateManagement.Data.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public int FlowId { get; set; }
        public int StateId { get; set; }
        [JsonIgnore]
        public virtual Flow CurrentFlow { get; set; }
        [JsonIgnore]
        public virtual FlowState CurrentFlowState
        {
            get
            {
                return CurrentFlow.States.FirstOrDefault(x => x.StateId == StateId);
            }
        }
    }
}
