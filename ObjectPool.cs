using System;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase.ObjectPool
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private T prefab;
        private Transform poolContainer;
        private bool autoExpand;

        private List<T> pool = new();

        public ObjectPool(T prefab, Transform container, int poolSize, bool autoExpand)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            this.prefab = prefab;

            if (container == null)
                throw new NullReferenceException(nameof(container));

            poolContainer = container;

            this.autoExpand = autoExpand;

            InitPool(poolSize);
        }

        private void InitPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
                CreateNewObject(false);
        }

        private T CreateNewObject(bool isActiveByDefault)
        {
            T newObject = GameObject.Instantiate(prefab, poolContainer);
            
            newObject.gameObject.SetActive(isActiveByDefault);
            
            pool.Add(newObject);

            return newObject;
        }
        
        public void ReturnToPool(T target)
        {
            if (target != null)
            {
                target.gameObject.SetActive(false);
                target.transform.position = poolContainer.position;
            }
        }

        public bool TryGetFree(out T element)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    element = pool[i];
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void DisableAll()
        {
            foreach (var gameObject in pool)
                gameObject.gameObject.SetActive(false);
        }

        public T GetFree()
        {
            if (TryGetFree(out T element))
            {
                element.gameObject.SetActive(true);
                return element;
            }

            if (autoExpand)
                return CreateNewObject(true);

            throw new Exception("There is no free element in pool");
        }
    }
}
