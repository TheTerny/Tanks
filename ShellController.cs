using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{
    public Transform turretTransform;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public GameObject explosionEffect; // �������� �� ��� �������� ������ ������� ������
    public float shootingForce = 10f;
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public GameObject explosionPrefab;
    public Transform explosionPoint;
    public Transform destroyShell;
    private GameObject projectile;

    void Update()
    {
        // ��������� ����� � �������
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // �������� �������
        projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, turretTransform.rotation);

        Instantiate(explosionPrefab, explosionPoint.position, Quaternion.identity);

        // ��������� ���� �������� �� ����
        Rigidbody tankRigidbody = GetComponent<Rigidbody>();
        if (tankRigidbody != null)
        {
            tankRigidbody.AddForce(-turretTransform.forward * shootingForce, ForceMode.Impulse);
        }

        // ��������� ���� �������� �� ������
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        if (projectileRigidbody != null)
        {
            projectileRigidbody.AddForce(turretTransform.up * -shootingForce, ForceMode.Impulse);
        }
     
        Invoke("PlayExplosionEffect", 1f);
    }

    void PlayExplosionEffect()
    {

        // ��������������� ������� ������ � ������� ������� ����� ��� ������������
        Instantiate(explosionEffect, projectile.transform.position, Quaternion.identity);
        // ����������� ������� ����� ��������� ����� (����� ������������� ��������� � ����������� �� �������)
        Destroy(projectile);
       
    }

}
