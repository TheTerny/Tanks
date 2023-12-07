using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public Transform turretTransform;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public GameObject explosionEffect; // Замените на ваш реальный префаб эффекта взрыва
    public float shootingForce = 10f;
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public GameObject explosionPrefab;
    public Transform explosionPoint;
    public Transform destroyShell;
    private GameObject projectile;

    void Update()
    {
        // Обработка ввода и выстрел
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // Создание снаряда
        projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretTransform.rotation);

        Instantiate(explosionPrefab, explosionPoint.position, Quaternion.identity);

        // Нанесение силы выстрела на танк
        Rigidbody tankRigidbody = GetComponent<Rigidbody>();
        if (tankRigidbody != null)
        {
            tankRigidbody.AddForce(-turretTransform.forward * shootingForce, ForceMode.Impulse);
        }

        // Нанесение силы выстрела на снаряд
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        if (projectileRigidbody != null)
        {
            projectileRigidbody.AddForce(turretTransform.up * -shootingForce, ForceMode.Impulse);
        }
     
        Invoke("PlayExplosionEffect", 1f);
    }

    void PlayExplosionEffect()
    {

        // Воспроизведение эффекта взрыва в позиции снаряда перед его уничтожением
        Instantiate(explosionEffect, projectile.transform.position, Quaternion.identity);
        // Уничтожение снаряда через некоторое время (может потребоваться настроить в зависимости от проекта)
        Destroy(projectile);
       
    }

}
