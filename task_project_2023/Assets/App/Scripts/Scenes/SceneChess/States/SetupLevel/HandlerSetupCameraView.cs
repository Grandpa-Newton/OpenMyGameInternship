using System;
using System.Threading.Tasks;
using App.Scripts.Infrastructure.GameCore.States.SetupState;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;
using App.Scripts.Scenes.SceneChess.Features.FieldCamera.ViewCamera;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.States.SetupLevel
{
    public class HandlerSetupCameraView : IHandlerSetupLevel
    {
        private readonly Config _configHandler;
        private readonly ViewCamera _viewCamera;
        private readonly ViewGridField _viewGridField;

        public HandlerSetupCameraView(ViewCamera viewCamera, ViewGridField viewGridField, Config configHandler)
        {
            _viewCamera = viewCamera;
            _viewGridField = viewGridField;
            _configHandler = configHandler;
        }

        public Task Process()
        {
            UpdateCameraView();

            return Task.CompletedTask;
        }

        private void UpdateCameraView()
        {
            var fieldSize = CalculateFieldSize();

            var topOffset = _configHandler.TopOffset;

            fieldSize.y += topOffset;

            _viewCamera.UpdateFitSize(fieldSize);

            var positionCamera = _viewGridField.localPosition;

            _viewCamera.localPosition = new Vector3(
                positionCamera.x + fieldSize.x * 0.5f,
                positionCamera.y + fieldSize.y * 0.5f,
                _viewCamera.localPosition.z);
        }

        private Vector2 CalculateFieldSize()
        {
            return _viewGridField.GridSize;
        }

        [Serializable]
        public class Config
        {
            public float TopOffset = 1f;
        }
    }
}