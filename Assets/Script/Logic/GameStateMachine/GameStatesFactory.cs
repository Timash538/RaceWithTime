using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesFactory : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private PlayState _playState;
    [SerializeField] private PauseState _pauseState;

    public void Init(UI ui)
    {
        _playState.Init(ui);
        _pauseState.Init(ui);
    }

    public IEnumerable<GameState> GetStates()
    {
        return new List<GameState>()
        {
            _playState,
            _pauseState
        };
    }
}
