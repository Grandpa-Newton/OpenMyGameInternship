using System.Collections.Generic;
using App.Scripts.Libs.Systems;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ViewField;
using App.Scripts.Scenes.SceneChess.Features.GridNavigation;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Systems
{
    public class SystemAnimatePieceMove : ISystem
    {
        private readonly ContainerPieceMoves _containerPieceMoves;
        private readonly ViewGridField _gridField;

        public SystemAnimatePieceMove(ContainerPieceMoves containerPieceMoves, ViewGridField gridField)
        {
            _containerPieceMoves = containerPieceMoves;
            _gridField = gridField;
        }

        public void Init()
        {
        }

        public void Update(float dt)
        {
            if (!_containerPieceMoves.HasMoves()) return;

            foreach (var move in _containerPieceMoves.Moves) AnimateMove(move);

            _containerPieceMoves.Clear();
        }

        public void Cleanup()
        {
        }

        private void AnimateMove(MoveRequest move)
        {
            move.ChessUnit.View.AnimateMove(GetAnimationPath(move.Path));
        }

        private List<Vector3> GetAnimationPath(List<Vector2Int> movePath)
        {
            var path = new List<Vector3>();

            foreach (var cell in movePath)
            {
                Vector3 point = _gridField.GetCellPosition(cell);
                path.Add(point);
            }

            return path;
        }
    }
}