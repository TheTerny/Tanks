using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float minAngle = -5f;
    public float maxAngle = 70f;
    public Transform cannonTransform;

    private float initialRotationX;

    void Start()
    {
        // ��������� ��������� ���� �������� �����
        initialRotationX = cannonTransform.eulerAngles.x;
    }

    void Update()
    {
        // �������� ������� ��������� ���� �� ��� Y
        float mouseY = Input.GetAxis("Mouse Y");

        // ��������� ����� ���� �������� ����� ������������ ���������� ���������
        float newAngle = initialRotationX - mouseY;

        // ������������ ���� � �������� ��������
        newAngle = Mathf.Clamp(newAngle, initialRotationX + minAngle, initialRotationX + maxAngle);

        // ��������� ����� ���� �������� � �����
        cannonTransform.eulerAngles = new Vector3(newAngle, 0f, 0f);
    }
}