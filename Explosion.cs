using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public GameObject explosionEffect;
    void OnCollisionEnter(Collision collision)
    {
        // �������� �� ������������ � ������� ���������
        if (!collision.gameObject.CompareTag("Cannon"))
        {
            // �������� ������� ������
            Instantiate(explosionEffect, collision.contacts[0].point, Quaternion.identity);

            // ���������� ������� ������ �� ������� � �������
            Collider[] colliders = Physics.OverlapSphere(collision.contacts[0].point, explosionRadius);
            foreach (Collider col in colliders)
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, collision.contacts[0].point, explosionRadius);
                }
            }

            // ����������� ������� �������
            if (!collision.gameObject.CompareTag("Ground"))
            {
                Destroy(collision.gameObject);
            }
            Destroy(projectilePrefab);
        }
    }
}
