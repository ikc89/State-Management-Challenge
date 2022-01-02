using StateManagement.Data.Entities;
using Task = StateManagement.Data.Entities.Task;

namespace StateManagement.Business.ViewModels
{
    public class FlowStateTaskViewModel
    {
        public int Id { get; set; }
        public State State { get; set; }
        public int Order { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
