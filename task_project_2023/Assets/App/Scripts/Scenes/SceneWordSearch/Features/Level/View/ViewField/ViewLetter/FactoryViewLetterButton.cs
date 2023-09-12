using App.Scripts.Libs.Factory;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewLetter
{
    public class FactoryViewLetterButton : IFactory<ViewLetterButton, char>
    {
        private readonly ViewLetterButton _prefabButton;

        public FactoryViewLetterButton(ViewLetterButton prefabButton)
        {
            _prefabButton = prefabButton;
        }

        public ViewLetterButton Create(char c)
        {
            var viewLetter = Object.Instantiate(_prefabButton);
            viewLetter.UpdateLetter(c);
            return viewLetter;
        }
    }
}