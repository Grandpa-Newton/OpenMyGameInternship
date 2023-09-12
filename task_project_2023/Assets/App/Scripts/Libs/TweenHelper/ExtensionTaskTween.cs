using System.Threading.Tasks;
using DG.Tweening;

namespace App.Scripts.Libs.TweenHelper
{
    public static class ExtensionTaskTween
    {
        public static Task Await(this Tween animation)
        {
            if (animation is null || animation.IsComplete()) return Task.CompletedTask;

            var tsk = new TaskCompletionSource<bool>();
            animation.OnComplete(() => { tsk.TrySetResult(true); });

            return tsk.Task;
        }
    }
}