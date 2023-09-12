using App.Scripts.Libs.StateMachine;
using App.Scripts.Libs.Systems;
using UnityEngine;

namespace App.Scripts.Infrastructure.GameCore.States
{
    public class StateProcessGame : GameState
    {
        private readonly SystemsGroup _gameSystems;

        public StateProcessGame(SystemsGroup gameSystems)
        {
            _gameSystems = gameSystems;
        }

        public override void OnEnterState()
        {
            _gameSystems.Init();
        }

        public override void Update()
        {
            _gameSystems.Update(Time.deltaTime);
        }

        public override void OnExitState()
        {
            _gameSystems.Cleanup();
        }
    }
}