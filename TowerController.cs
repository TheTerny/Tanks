using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    public float rotationSpeed = 5f; // �������� �������� �����
    public float cannonMinAngle = -10f;
    public float cannonMaxAngle = 70f;
    public Transform cannon;
    public float elevationSpeed = 3f; // �������� ������� �����

    private float cannonRotation = 0f; // ������� ���� �������� �����

    private void Start()
    {
    }

    private void Update()
    {
        // �������� ����� �� ��� Y
        // �������� ��������� ��������� ���� �� ��� X
        float mouseX = Input.GetAxis("Mouse X");
        // ��������� �������� � ������� ������ �� ��� Y
        transform.Rotate(Vector3.forward, mouseX * rotationSpeed);

        // ������ �����
        float verticalRotation = Input.GetAxis("Mouse Y") * elevationSpeed;
        cannonRotation = Mathf.Clamp(cannonRotation - verticalRotation, cannonMaxAngle, cannonMinAngle);
        // ������������� ���� �������� � ���� �����������
        cannon.localRotation = Quaternion.Euler(cannonRotation, 0f, 0f);

    }
}
