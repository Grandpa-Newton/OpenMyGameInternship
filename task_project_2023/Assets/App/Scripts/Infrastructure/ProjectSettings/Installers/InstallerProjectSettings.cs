using App.Scripts.Infrastructure.ProjectSettings.Config;
using App.Scripts.Libs.Installer;
using App.Scripts.Libs.ServiceLocator;
using UnityEngine;

namespace App.Scripts.Infrastructure.ProjectSettings.Installers
{
    public class InstallerProjectSettings : MonoInstaller
    {
        [SerializeField] private ConfigProjectSettings configProjectSettings;

        public override void InstallBindings(ServiceContainer serviceContainer)
        {
            var controller = new ControllerSetupProjectSettings(configProjectSettings);

            serviceContainer.SetService<IInitializable, ControllerSetupProjectSettings>(controller);
        }
    }
}