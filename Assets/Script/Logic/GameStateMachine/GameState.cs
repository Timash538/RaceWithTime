using UnityEditor;
using UnityEngine;

public abstract class GameState : MonoBehaviour
{
    public abstract void Enter();

    public abstract void Exit();

    public abstract bool CanTransit(GameState state);
}