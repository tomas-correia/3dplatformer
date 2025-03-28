using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float bulletSpeed = 100f;
    [SerializeField]
    private float bulletLifetime = 2f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        bulletRigidbody.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

        Destroy(bullet, bulletLifetime);
    }
}
