using System.Collections.Generic;
using App.Scripts.Libs.SceneManagement.Config;
using UnityEngine.SceneManagement;

namespace App.Scripts.Libs.SceneManagement
{
    public class SceneNavigatorLoader : ISceneNavigator
    {
        private readonly ConfigScenes _configScenes;

        public SceneNavigatorLoader(ConfigScenes configScenes)
        {
            _configScenes = configScenes;
        }

        public void LoadScene(string sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }

        public List<SceneInfo> GetAvailableSwitchScenes()
        {
            var currentSceneName = SceneManager.GetActiveScene().name;

            var result = new List<SceneInfo>();

            foreach (var sceneInfo in _configScenes.AvailableScenes)
                if (sceneInfo.SceneKey != currentSceneName)
                    result.Add(sceneInfo);

            return result;
        }
    }
}