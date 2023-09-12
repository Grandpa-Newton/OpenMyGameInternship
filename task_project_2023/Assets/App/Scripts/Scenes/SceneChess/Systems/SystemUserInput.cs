using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;
using App.Scripts.Scenes.SceneChess.Features.FieldCamera.ViewCamera;
using App.Scripts.Scenes.SceneChess.Features.GridInput;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Systems
{
    public class SystemUserInput : ISystem
    {
        private readonly ContainerFieldInput _containerFieldInput;
        private readonly ViewCamera _viewCamera;
        private readonly ViewGridField _viewGridField;

        public SystemUserInput(ViewGridField viewGridField, ViewCamera viewCamera,
            ContainerFieldInput containerFieldInput)
        {
            _viewGridField = viewGridField;
            _viewCamera = viewCamera;
            _containerFieldInput = containerFieldInput;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            ClearInput();

            if (!Input.GetMouseButtonUp(0)) return;

            var worldPosition = _viewCamera.ScreenToWorld(Input.mousePosition);

            if (TryGetClickCell(worldPosition, out var clickedCell)) _containerFieldInput.AddClickCell(clickedCell);
        }

        public void Cleanup()
        {
            ClearInput();
        }

        private bool TryGetClickCell(Vector3 worldPosition, out Vector2Int cellPosition)
        {
            cellPosition = _viewGridField.PositionToCell(worldPosition);

            return _viewGridField.IsValid(cellPosition);
        }

        private void ClearInput()
        {
            _containerFieldInput.Refresh();
        }
    }
}