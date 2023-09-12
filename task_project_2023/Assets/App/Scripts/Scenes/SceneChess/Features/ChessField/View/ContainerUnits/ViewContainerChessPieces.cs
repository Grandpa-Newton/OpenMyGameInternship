using App.Scripts.Libs.BaseView;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits
{
    public class ViewContainerChessPieces : MonoView
    {
        [SerializeField] private Transform containerChessPieces;
        private IFactory<ViewChessUnit, ChessPieceModel> _factoryViewUnit;

        private ViewGridField _viewGridField;

        public void Construct(ViewGridField viewGridField, IFactory<ViewChessUnit, ChessPieceModel> factoryViewUnit)
        {
            _viewGridField = viewGridField;
            _factoryViewUnit = factoryViewUnit;
        }

        public ViewChessUnit SpawnChessPiece(ChessPieceModel chessPieceModel, Vector2Int position)
        {
            var view = _factoryViewUnit.Create(chessPieceModel);
            view.localScale = Vector3.one;
            view.SetParent(containerChessPieces);

            view.localPosition = _viewGridField.GetCellPosition(position);
            view.UpdateSize(_viewGridField.CellSize);

            return view;
        }
    }
}