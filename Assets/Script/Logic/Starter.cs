using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    [SerializeField] private ControllableVehicle _player;
    [SerializeField] private GameStatesFactory _gameStatesFactory;
    [SerializeField] private UI _ui;

    private GameStateMachine _stateMachine;
    private void Awake()
    {
        InitGameStateMachine();
    }

    private void InitGameStateMachine()
    {
        _gameStatesFactory.Init(_ui);
        _stateMachine = new GameStateMachine(_gameStatesFactory.GetStates());
        _ui.ResumeButtonClicked.AddListener(_stateMachine.TrySwitchState<PlayState>);
        _ui.PauseButtonClicked.AddListener(_stateMachine.TrySwitchState<PauseState>);
    }
}
