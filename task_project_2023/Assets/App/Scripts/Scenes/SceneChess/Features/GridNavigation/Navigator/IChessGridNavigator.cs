using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public interface IChessGridNavigator
    {
        List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int @from, Vector2Int to, ChessGrid grid);
    }
}