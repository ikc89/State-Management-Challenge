namespace StateManagement.Business.Handlers.Base
{
    public interface ITaskStateHandler
    {
        Task MoveToNextState(int id, CancellationToken cancellationToken);

        Task MoveToPreviousState(int id, CancellationToken cancellationToken);

        Task UndoLastMove(CancellationToken cancellationToken);

        Task ReturnToPreviousState(int id, DateTime specificTime, CancellationToken cancellationToken);
    }
}
