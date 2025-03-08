using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        public List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();


        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
                if (item != null)
                {
                    item.isUsed = true;
                    return item.item;
                }
            }
            return CreateNewPooledItem();
        }


        private T CreateNewPooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.item = CreateItem();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.item;
        }


        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Object pool is not implemented");
        }



        public class PooledItem<T>
        {
            public T item;
            public bool isUsed;
        }
    }
}