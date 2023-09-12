using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Execeptions;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix
{
    public class ChessGrid
    {
        private readonly ChessUnit[][] _matrix;

        private readonly List<ChessUnit> _units = new();

        public ChessGrid(Vector2Int size)
        {
            Size = size;

            _matrix = new ChessUnit[size.y][];
            for (var i = 0; i < size.y; i++) _matrix[i] = new ChessUnit[size.x];
        }

        public Vector2Int Size { get; }
        public IEnumerable<ChessUnit> Pieces => new ReadOnlyCollection<ChessUnit>(_units);

        public void SetAt(Vector2Int pos, ChessUnit unit)
        {
            SetAt(pos.y, pos.x, unit);
        }

        public void SetAt(int i, int j, ChessUnit unit)
        {
            if (_matrix[i][j] != null) throw new ExceptionChessGrid("cell not empty");

            if (_units.Contains(unit)) throw new ExceptionChessGrid("unit already at grid");

            _matrix[i][j] = unit;
            unit.CellPosition = new Vector2Int(j, i);

            _units.Add(unit);
        }

        public void Move(Vector2Int from, Vector2Int to)
        {
            var pieceAt = Get(from);
            if (pieceAt is null) throw new ExceptionChessGrid($"cant move empty cell at {@from}");

            var piece = Get(to);

            if (piece != null) throw new ExceptionChessGrid($"cant place at busy cell {to}");

            _matrix[from.y][from.x] = null;
            _matrix[to.y][to.x] = pieceAt;
            pieceAt.CellPosition = to;
        }

        public ChessUnit Get(Vector2Int pos)
        {
            return Get(pos.y, pos.x);
        }

        public ChessUnit Get(int i, int j)
        {
            return _matrix[i][j];
        }

        public ChessUnit RemoveAt(Vector2Int pos)
        {
            return RemoveAt(pos.y, pos.x);
        }

        public ChessUnit RemoveAt(int i, int j)
        {
            var value = Get(i, j);
            _matrix[i][j] = null;

            return value;
        }
    }
}