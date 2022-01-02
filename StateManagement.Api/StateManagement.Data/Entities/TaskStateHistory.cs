using StateManagement.Data.Entities.Base;

namespace StateManagement.Data.Entities
{
    public class TaskStateHistory : BaseEntity
    {
        public int TaskId { get; set; }
        public int StateId { get; set; }

        public virtual Task Task { get; set; }
        public virtual State State { get; set; }
    }
}
