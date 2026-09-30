using UnityEngine;

public class ShooterBullet : Shooter
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    public override void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null && GameManager.someGameManager != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);    
        }
        else
        {
            //OOAC (replace debug log call w/custom GUI status message center or box etc.)
            Debug.Log("[STATUS] Out of AMMO or CHARGE!");
        }
    }
}
