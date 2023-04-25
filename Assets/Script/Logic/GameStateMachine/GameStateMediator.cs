public class GameStateMediator<T>
{
    private readonly GameStateMachine _stateMachine;
    public GameStateMediator(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void SetState() => _stateMachine.TrySwitchState<T>();
}