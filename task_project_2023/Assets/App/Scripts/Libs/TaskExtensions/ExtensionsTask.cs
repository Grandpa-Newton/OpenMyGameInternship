using System.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.TaskExtensions
{
    public static class ExtensionsTask
    {
        public static void Forget(this Task task)
        {
            task.ContinueWith(completedTask =>
            {
                if (completedTask.Exception is null) return;

                foreach (var exception in completedTask.Exception.InnerExceptions) Debug.LogException(exception);
            });
        }
    }
}