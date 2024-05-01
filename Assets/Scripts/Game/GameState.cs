using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class GameState
    {
        public State CurrentGameState { get; private set; } = State.Menu;

        public event Action<State> GameStateChanged;

        public void ChangeGameState(State state)
        {
            CurrentGameState = state;
            GameStateChanged?.Invoke(state);
        }
    }
}