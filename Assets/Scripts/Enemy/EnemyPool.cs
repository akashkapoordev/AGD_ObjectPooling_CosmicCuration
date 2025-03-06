using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyData enemyData;
        public List<PoolEnemy> poolEnemies = new List<PoolEnemy>();


        public EnemyPool(EnemyView enemyView , EnemyData enemyData)
        {
            this.enemyView = enemyView;
            this.enemyData = enemyData;
        }


        public EnemyController GetEnemy()
        {
            if(poolEnemies.Count > 0)
            {
                PoolEnemy poolEnemy = poolEnemies.Find(enemy => !enemy.isUsed);
                if(poolEnemy != null)
                {
                    poolEnemy.isUsed = true;
                    return poolEnemy.Enemy;
                }
            }
            return CreateEnemyPool();
        }


        private EnemyController CreateEnemyPool()
        {
            PoolEnemy enemyPool = new PoolEnemy();
            enemyPool.Enemy = new EnemyController(enemyView, enemyData);
            enemyPool.isUsed = true;
            poolEnemies.Add(enemyPool);
            return enemyPool.Enemy;
        }


        public void ReturnedToPool(EnemyController returnedEnemy)
        {
            PoolEnemy enemyPool = poolEnemies.Find(enemy => enemy.Enemy.Equals(returnedEnemy));
            enemyPool.isUsed = false;
        }


        public class PoolEnemy
        {
            public EnemyController Enemy;
            public bool isUsed;
        }

  
    }
}