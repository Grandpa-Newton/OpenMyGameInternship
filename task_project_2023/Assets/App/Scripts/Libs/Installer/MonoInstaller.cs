using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Libs.Installer
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        public abstract void InstallBindings(ServiceContainer serviceContainer);
    }
}