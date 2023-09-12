using System.Collections.Generic;
using App.Scripts.Libs.SceneManagement.Config;

namespace App.Scripts.Libs.SceneManagement
{
    public interface ISceneNavigator
    {
        void LoadScene(string sceneId);

        public List<SceneInfo> GetAvailableSwitchScenes();
    }
}