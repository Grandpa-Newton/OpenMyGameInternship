using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewCharInput
{
    public interface IViewCharSelector
    {
        void SetupChars(IEnumerable<char> chars);
        void Clear();

        Task AnimateAppearAsync();
        Task AnimateHideAsync();
    }
}