using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.SceneManagement.Config
{
    [CreateAssetMenu(fileName = "configScenes", menuName = "app/scenes/config scenes")]
    public class ConfigScenes : ScriptableObject
    {
        public List<SceneInfo> AvailableScenes = new();
    }
}