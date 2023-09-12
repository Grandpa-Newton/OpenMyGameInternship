using System;
using System.Collections.Generic;

namespace App.Scripts.Libs.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, GameState> _states = new();
        private GameState _currentState;
        private GameState _stateToChange;

        public void AddState(GameState state)
        {
            state.StateMachine = this;
            _states[state.GetType()] = state;
        }

        public void ChangeState<T>()
        {
            var stateType = typeof(T);
            if (_states.TryGetValue(stateType, out var state)) _stateToChange = state;
        }

        public void Update()
        {
            CheckSwitchState();

            _currentState?.Update();
        }

        private void CheckSwitchState()
        {
            if (_stateToChange is null) return;

            var nextState = _stateToChange;
            _stateToChange = null;

            ProcessChangeState(nextState);
        }

        private void ProcessChangeState(GameState value)
        {
            ExitState();

            _currentState = value;
            _currentState.OnEnterState();
        }

        private void ExitState()
        {
            if (_currentState is null) return;

            _currentState.OnExitState();
        }
    }
}