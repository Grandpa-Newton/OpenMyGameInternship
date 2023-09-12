using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public interface IProviderFillwordLevel
    {
        GridFillWords LoadModel(int index);
    }
}