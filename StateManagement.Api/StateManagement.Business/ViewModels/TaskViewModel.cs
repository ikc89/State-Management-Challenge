namespace StateManagement.Business.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FlowId { get; set; }
        public int StateId { get; set; }
    }
}
