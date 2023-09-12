using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts.Libs.ServiceLocator
{
    public class ServiceContainer
    {
        private readonly Dictionary<Type, IServiceContainer> _containers = new();

        public void SetServiceSelf<TService>(TService value)
        {
            SetService<TService, TService>(value);
        }

        public void SetService<TBind, TService>(TService value) where TService : TBind
        {
            var container = FindContainer<TBind>();

            container.Add(value);
        }

        public TBind Get<TBind>()
        {
            var container = FindContainer<TBind>();

            return container.GetService();
        }

        public IEnumerable<TBind> GetServices<TBind>()
        {
            var container = FindContainer<TBind>();

            return container.GetServices();
        }

        private Container<T> FindContainer<T>()
        {
            var typeBind = typeof(T);
            if (_containers.TryGetValue(typeBind, out var container)) return container as Container<T>;

            var bindContainer = new Container<T>();
            _containers[typeBind] = bindContainer;

            return bindContainer;
        }

        private interface IServiceContainer
        {
        }

        private class Container<TBind> : IServiceContainer
        {
            private readonly List<TBind> _values = new();

            public void Add(TBind value)
            {
                _values.Add(value);
            }

            public TBind GetService()
            {
                return _values.FirstOrDefault();
            }

            public IEnumerable<TBind> GetServices()
            {
                return _values;
            }
        }
    }
}