using System.Collections.Generic;
using App.Scripts.Libs.BaseView;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits.Animator;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits
{
    public class ViewChessUnit : MonoView
    {
        [SerializeField] private SpriteRenderer viewPiece;
        [SerializeField] private Transform transformView;

        [SerializeField] private AnimatorViewChessUnit animator;
        private bool _isSelected;

        public ChessPieceModel ChessPieceModel { get; private set; }
        public bool IsAnimating => animator.IsAnimating;

        public void SetupModel(ChessPieceModel chessPieceModel)
        {
            ChessPieceModel = chessPieceModel;
        }

        public void SetupSprite(Sprite sprite)
        {
            viewPiece.sprite = sprite;
        }

        public void UpdateSize(Vector2 cellSize)
        {
            var spriteSize = viewPiece.size;
            transformView.localScale = new Vector3(cellSize.x / spriteSize.x, cellSize.y / spriteSize.y);
        }

        public void AnimateUnselect()
        {
            if (!_isSelected) return;

            _isSelected = false;
            animator.AnimateUnselect();
        }

        public void AnimateSelect()
        {
            if (_isSelected) return;

            _isSelected = true;
            animator.AnimateSelect();
        }

        public void AnimateMove(List<Vector3> movePath)
        {
            animator.AnimatePath(movePath);
        }
    }
}