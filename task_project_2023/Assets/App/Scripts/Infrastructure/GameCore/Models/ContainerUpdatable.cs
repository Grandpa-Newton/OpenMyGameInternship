namespace App.Scripts.Infrastructure.GameCore.Models
{
    public class ContainerUpdatable
    {
        public bool IsUpdated { get; private set; }

        protected void NotifyUpdate()
        {
            IsUpdated = true;
        }

        public void Refresh()
        {
            IsUpdated = false;
        }
    }
}