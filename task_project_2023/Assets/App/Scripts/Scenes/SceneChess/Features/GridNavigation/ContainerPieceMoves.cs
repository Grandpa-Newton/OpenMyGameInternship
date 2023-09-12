using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation
{
    public class ContainerPieceMoves
    {
        private readonly List<MoveRequest> _requests = new();
        public IEnumerable<MoveRequest> Moves => _requests;

        public void AddMove(Vector2Int fromCell, Vector2Int toCell)
        {
            _requests.Add(new MoveRequest
            {
                From = fromCell,
                To = toCell
            });
        }

        public bool HasMoves()
        {
            return _requests.Count > 0;
        }

        public void Clear()
        {
            _requests.Clear();
        }
    }
}