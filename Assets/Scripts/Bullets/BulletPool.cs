using System.Collections;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private  BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;

        public BulletPool(BulletView bulletView,BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public class PooledBullet
        {
            public bool isUsed;
            public BulletController bulletController;
        }

    }
}