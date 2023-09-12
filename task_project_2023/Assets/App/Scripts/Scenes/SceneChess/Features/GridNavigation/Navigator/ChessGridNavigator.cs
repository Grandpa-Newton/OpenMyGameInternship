using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class ChessGridNavigator : IChessGridNavigator
    {
        private Vector2Int gridSize;

        private List<List<Node>> nodeList; // двумерный список для инициализации клеток
        public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
        {
            Queue<Node> queue = new Queue<Node>();
            
            List<Node> exploredList = new List<Node>(); // список рассмотренных клеток

            nodeList = new List<List<Node>>();

            gridSize = grid.Size;

            for (int i = 0; i < grid.Size.y; i++)
            {
                nodeList.Add(new List<Node>());
                for (int j = 0; j < grid.Size.x; j++)
                {
                    nodeList[i].Add(new Node(j, i));
                    nodeList[i][j].CameFromNode = null;
                    if (grid.Get(i, j) != null)
                    {
                        nodeList[i][j].SetAvailability(false);
                    }
                }
            }

            Node startNode = nodeList[from.y][from.x];

            Node goalNode = nodeList[to.y][to.x];

            queue.Enqueue(startNode);

            exploredList.Add(startNode);

            Node currentNode;

            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();

                if (currentNode == goalNode)
                {
                    return GetPath(currentNode, startNode);
                }

                List<Node> neighbors = new List<Node>();

                switch (unit)
                {
                    case ChessUnitType.Pon:
                        neighbors = GetBlackPawnNeighbors(currentNode);
                        neighbors.AddRange(GetWhitePawnNeighbors(currentNode));
                        break;

                    case ChessUnitType.King:
                        neighbors = GetKingNeighbors(currentNode);
                        break;

                    case ChessUnitType.Queen:
                        neighbors = GetRookNeighbors(currentNode);
                        neighbors.AddRange(GetBishopNeighbors(currentNode));
                        break;

                    case ChessUnitType.Rook:
                        neighbors = GetRookNeighbors(currentNode);
                        break;

                    case ChessUnitType.Knight:
                        neighbors = GetKnightNeighbors(currentNode);
                        break;

                    case ChessUnitType.Bishop:
                        neighbors = GetBishopNeighbors(currentNode);
                        break;
                }

                foreach (var neighbor in neighbors)
                {
                    if (exploredList.Contains(neighbor))
                    {
                        continue;
                    }

                    exploredList.Add(neighbor);

                    neighbor.CameFromNode = currentNode;

                    queue.Enqueue(neighbor);
                }
            }

            return null;
        }

        private List<Vector2Int> GetPath(Node goalNode, Node startNode)
        {
            Node currentNode = goalNode;

            List<Vector2Int> path = new List<Vector2Int>();

            path.Add(currentNode.Position);

            while (currentNode.CameFromNode != startNode)
            {
                path.Add(currentNode.CameFromNode.Position);
                currentNode = currentNode.CameFromNode;
            }

            path.Reverse();

            return path;
        }

        private List<Node> GetBlackPawnNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            if (currentNode.Position.y - 1 >= 0 && nodeList[currentNode.Position.y - 1][currentNode.Position.x].GetAvailability())
            {
                neighbors.Add(nodeList[currentNode.Position.y - 1][currentNode.Position.x]);
            }

            return neighbors;
        }
        private List<Node> GetWhitePawnNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            if (currentNode.Position.y + 1 < gridSize.y && nodeList[currentNode.Position.y + 1][currentNode.Position.x].GetAvailability())
            {
                neighbors.Add(nodeList[currentNode.Position.y + 1][currentNode.Position.x]);
            }

            return neighbors;
        }
        private List<Node> GetKnightNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            List<int> directionX = new(8) { 1, 2, 2, 1, -1, -2, -2, -1 }; // смещение координаты x
            List<int> directionY = new(8) { 2, 1, -1, -2, -2, -1, 1, 2 }; // смещение координаты y

            for (int i = 0; i < directionX.Count; i++)
            {
                Vector2Int nextPosition = new Vector2Int(currentNode.Position.x + directionX[i], currentNode.Position.y + directionY[i]);

                if (nextPosition.x >= 0 && nextPosition.x < gridSize.x && nextPosition.y >= 0 && nextPosition.y < gridSize.y &&
                    nodeList[nextPosition.y][nextPosition.x].GetAvailability())
                {
                    neighbors.Add(nodeList[nextPosition.y][nextPosition.x]);
                }
            }

            return neighbors;
        }

        private List<Node> GetKingNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            List<int> directionX = new(8) { 0, 1, 1, 1, 0, -1, -1, -1 };
            List<int> directionY = new(8) { 1, 1, 0, -1, -1, -1, 0, 1 };

            for (int i = 0; i < directionX.Count; i++)
            {
                Vector2Int nextPosition = new Vector2Int(currentNode.Position.x + directionX[i], currentNode.Position.y + directionY[i]);

                if(nextPosition.x >= 0 && nextPosition.x < gridSize.x && nextPosition.y >= 0 && nextPosition.y < gridSize.y &&
                    nodeList[nextPosition.y][nextPosition.x].GetAvailability())
                {
                    neighbors.Add(nodeList[nextPosition.y][nextPosition.x]);
                }
            }

            return neighbors;
        }

        private List<Node> GetRookNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            for (int i = currentNode.Position.y + 1; i < gridSize.y; i++) // вверх
            {
                if (nodeList[i][currentNode.Position.x].GetAvailability())
                {
                    neighbors.Add(nodeList[i][currentNode.Position.x]);
                }
                else
                    break;
            }

            for (int i = currentNode.Position.y - 1; i >= 0; i--) // вниз
            {
                if (nodeList[i][currentNode.Position.x].GetAvailability())
                {
                    neighbors.Add(nodeList[i][currentNode.Position.x]);
                }
                else
                    break;
            }

            for (int i = currentNode.Position.x + 1; i < gridSize.x; i++) // вправо
            {
                if (nodeList[currentNode.Position.y][i].GetAvailability())
                {
                    neighbors.Add(nodeList[currentNode.Position.y][i]);
                }
                else
                    break;
            }

            for (int i = currentNode.Position.x - 1; i >= 0; i--) // влево
            {
                if (nodeList[currentNode.Position.y][i].GetAvailability())
                {
                    neighbors.Add(nodeList[currentNode.Position.y][i]);
                }
                else
                    break;
            }

            return neighbors;
        }

        private List<Node> GetBishopNeighbors(Node currentNode)
        {
            List<Node> neighbors = new List<Node>();

            for (int i = currentNode.Position.x + 1, j = currentNode.Position.y + 1; i < gridSize.x && j < gridSize.y; i++, j++) // вправо вверх
            {
                if (nodeList[j][i].GetAvailability())
                {
                    neighbors.Add(nodeList[j][i]);
                }
                else
                    break;
            }
            for (int i = currentNode.Position.x - 1, j = currentNode.Position.y - 1; i >= 0 && j >= 0; i--, j--) // влево вниз
            {
                if (nodeList[j][i].GetAvailability())
                {
                    neighbors.Add(nodeList[j][i]);
                }
                else
                    break;
            }

            for (int i = currentNode.Position.x + 1, j = currentNode.Position.y - 1; i < gridSize.x && j >= 0; i++, j--) // влево вверх
            {
                if (nodeList[j][i].GetAvailability())
                {
                    neighbors.Add(nodeList[j][i]);
                }
                else
                    break;
            }

            for (int i = currentNode.Position.x - 1, j = currentNode.Position.y + 1; i >= 0 && j < gridSize.y; i--, j++) // вправо вниз
            {
                if (nodeList[j][i].GetAvailability())
                {
                    neighbors.Add(nodeList[j][i]);
                }
                else
                    break;
            }

            return neighbors;
        }

        private class Node
        {
            private bool _isAvailable = true; // доступна ли клетка (не занята ли другой фигурой)

            public Node CameFromNode; // из какой клетки пришла фигура
            public Vector2Int Position { get; private set; }

            public Node(int positionX, int positionY)
            {
                Position = new Vector2Int(positionX, positionY);
            }

            public bool GetAvailability()
            {
                return _isAvailable;
            }

            public void SetAvailability(bool isAvailable)
            {
                _isAvailable = isAvailable;
            }
        }
    }
}