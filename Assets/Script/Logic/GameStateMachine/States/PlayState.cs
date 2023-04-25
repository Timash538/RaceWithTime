public class PlayState : GameState
{
    private UI _ui;
    public void Init(UI uI)
    {
        _ui = uI;
    }

    public override void Enter()
    {
        _ui.ShowPlayInterface();
    }


    public override void Exit()
    {
        _ui.HidePlayInterface();
    }

    public override bool CanTransit(GameState state)
    {
        if (state is PauseState)
            return true;

        return false;
    }
}
