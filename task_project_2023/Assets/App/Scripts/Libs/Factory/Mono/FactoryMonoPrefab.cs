using UnityEngine;

namespace App.Scripts.Libs.Factory.Mono
{
    public class FactoryMonoPrefab<T> : IFactory<T> where T : Object
    {
        private readonly T _prefab;

        public FactoryMonoPrefab(T prefab)
        {
            _prefab = prefab;
        }

        public T Create()
        {
            var view = Object.Instantiate(_prefab);
            return view;
        }
    }
}