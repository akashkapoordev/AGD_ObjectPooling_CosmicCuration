using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private  BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> poolBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletView,BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if(poolBullets.Count > 0)
            {
                PooledBullet pooledBullet = poolBullets.Find(item => !item.isUsed);
                pooledBullet.isUsed = true;
                return pooledBullet.bulletController;
            }
            return CreateNewPolledBullet();
        }


        private BulletController CreateNewPolledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.bulletController = new BulletController(bulletView,bulletScriptableObject);
            pooledBullet.isUsed = true;
            return pooledBullet.bulletController;
        }

        public class PooledBullet
        {
            public bool isUsed;
            public BulletController bulletController;
        }

    }
}