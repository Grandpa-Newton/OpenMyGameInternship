namespace App.Scripts.Libs.StateMachine
{
    public abstract class GameState
    {
        public GameStateMachine StateMachine { get; set; }

        public virtual void OnExitState()
        {
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void Update()
        {
        }
    }
}