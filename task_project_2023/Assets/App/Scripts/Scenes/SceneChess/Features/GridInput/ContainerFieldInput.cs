using App.Scripts.Infrastructure.GameCore.Models;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridInput
{
    public class ContainerFieldInput : ContainerUpdatable
    {
        public Vector2Int ClickCell { get; private set; }

        public void AddClickCell(Vector2Int clickedCell)
        {
            ClickCell = clickedCell;
            NotifyUpdate();
        }
    }
}