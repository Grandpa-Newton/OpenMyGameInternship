using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord
{
    public class FactoryViewWord : IFactory<ViewWord>
    {
        private readonly IFactory<ViewLetterButton, char> _factoryChars;
        private readonly ViewWord _prefabWord;

        public FactoryViewWord(ViewWord prefabWord, IFactory<ViewLetterButton, char> factoryChars)
        {
            _prefabWord = prefabWord;
            _factoryChars = factoryChars;
        }

        public ViewWord Create()
        {
            var view = Object.Instantiate(_prefabWord);

            view.Construct(_factoryChars);

            return view;
        }
    }
}