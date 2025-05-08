using Mirror;
using UnityEngine;

public class ShootBullet : NetworkBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform leftGunPoint; // Punto de disparo de la mano izquierda
    public Transform rightGunPoint; // Punto de disparo de la mano derecha
    public float shootForce = 10f; // Fuerza del disparo

    void Update()
    {
        // Asegúrate de que solo el jugador local pueda disparar
        if (!isLocalPlayer) return;

        if (Input.GetButtonDown("Fire1")) // Por defecto, Fire1 es el botón izquierdo del ratón
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Crear las balas desde las dos manos (sincronizar la creación de balas en la red)
        ShootFromGun(leftGunPoint);
        ShootFromGun(rightGunPoint);
    }

    void ShootFromGun(Transform gunPoint)
    {
        // Instanciar la bala en la red
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);

        // Aplicar la fuerza de disparo
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(gunPoint.forward * shootForce, ForceMode.Impulse);

        // Sincronizar la bala en la red
        NetworkServer.Spawn(bullet); // Esto hace que la bala se sincronice en todos los clientes
    }
}

