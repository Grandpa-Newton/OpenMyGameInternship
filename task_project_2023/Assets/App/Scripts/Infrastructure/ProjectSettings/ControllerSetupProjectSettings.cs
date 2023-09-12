using App.Scripts.Infrastructure.ProjectSettings.Config;
using App.Scripts.Libs.Installer;
using UnityEngine;

namespace App.Scripts.Infrastructure.ProjectSettings
{
    public class ControllerSetupProjectSettings : IInitializable
    {
        private readonly ConfigProjectSettings _configProjectSettings;

        public ControllerSetupProjectSettings(ConfigProjectSettings configProjectSettings)
        {
            _configProjectSettings = configProjectSettings;
        }

        public void Init()
        {
            Application.targetFrameRate = _configProjectSettings.TargetFps;
        }
    }
}