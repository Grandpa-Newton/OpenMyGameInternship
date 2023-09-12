using App.Scripts.Libs.BaseView;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.FieldCamera.ViewCamera
{
    public class ViewCamera : MonoView
    {
        [SerializeField] private Camera gameCamera;

        public Vector2 ViewSize =>
            new(gameCamera.aspect * gameCamera.orthographicSize * 2, gameCamera.orthographicSize * 2);

        public void UpdateFitSize(Vector2 size)
        {
            if (gameCamera.aspect < 1)
            {
                var camHeight = size.x / gameCamera.aspect;
                gameCamera.orthographicSize = camHeight * 0.5f;

                if (camHeight >= size.y) return;
            }

            gameCamera.orthographicSize = size.y / 2;
        }

        public Vector3 ScreenToWorld(Vector3 mousePosition)
        {
            return gameCamera.ScreenToWorldPoint(mousePosition);
        }
    }
}