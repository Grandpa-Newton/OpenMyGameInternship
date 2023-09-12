using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Piece;
using App.Scripts.Scenes.SceneChess.Features.SpriteProvider;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.ChessField.View.ContainerUnits
{
    public class FactoryViewChessUnit : IFactory<ViewChessUnit, ChessPieceModel>
    {
        private readonly ViewChessUnit _prefabUnit;
        private readonly IProviderChessSprite _providerChessSprite;

        public FactoryViewChessUnit(ViewChessUnit prefabUnit, IProviderChessSprite providerChessSprite)
        {
            _prefabUnit = prefabUnit;
            _providerChessSprite = providerChessSprite;
        }

        public ViewChessUnit Create(ChessPieceModel value)
        {
            var view = Object.Instantiate(_prefabUnit);

            var sprite = _providerChessSprite.GetSprite(value);
            view.SetupModel(value);
            view.SetupSprite(sprite);

            return view;
        }
    }
}