using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            BulletPool bulletPool = new BulletPool(bulletPrefab, bulletScriptableObject);
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject,bulletPool);
        }

        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();
        
    } 
}