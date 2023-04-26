using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateMachine
{
    private GameState _currentState;
    private readonly IEnumerable<GameState> _states;

    public GameStateMachine(IEnumerable<GameState> states)
    {
        _states = states;
        _currentState = FindState<PlayState>();
        _currentState.Enter();
    }

    public void TrySwitchState<T>()
    {
        GameState nextState = FindState<T>();
        if (_currentState.CanTransit(nextState))
        {
            SwitchState(nextState);
            Debug.Log(nextState);
        }
    }

    private void SwitchState(GameState state)
    {
        _currentState.Exit();
        //_currentState.Transit(state);
        _currentState = state;
        _currentState.Enter();
    }

    private GameState FindState<T>()
        => _states.First(x => x is T);
}