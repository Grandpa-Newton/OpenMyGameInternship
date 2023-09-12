using App.Scripts.Libs.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField
{
    public class FactoryViewCells : IFactory<ViewGridCell>
    {
        private readonly ViewGridCell _viewGridCell;

        public FactoryViewCells(ViewGridCell viewGridCell)
        {
            _viewGridCell = viewGridCell;
        }

        public ViewGridCell Create()
        {
            var view = Object.Instantiate(_viewGridCell);
            return view;
        }
    }
}