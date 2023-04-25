using UnityEngine;

public class PauseState : GameState
{
    private UI _ui;
    public void Init(UI uI)
    {
        _ui = uI;
    }

    public override void Enter()
    {
        _ui.ShowPauseInterface();
        Time.timeScale = 0.0f;
    }


    public override void Exit()
    {
        _ui.HidePauseInterface();
        Time.timeScale = 1.0f;
    }

    public override bool CanTransit(GameState state)
    {
        if (state is PlayState)
            return true;

        return false;
    }
}