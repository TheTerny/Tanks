using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    public float rotationSpeed = 5f; // Скорость вращения башни
    public float cannonMinAngle = -10f;
    public float cannonMaxAngle = 70f;
    public Transform cannon;
    public float elevationSpeed = 3f; // Скорость подъема пушки

    private float cannonRotation = 0f; // Текущий угол поворота пушки

    private void Start()
    {
    }

    private void Update()
    {
        // Вращение башни по оси Y
        // Получаем изменение положения мыши по оси X
        float mouseX = Input.GetAxis("Mouse X");
        // Применяем вращение к объекту только по оси Y
        transform.Rotate(Vector3.forward, mouseX * rotationSpeed);

        // Подъем пушки
        float verticalRotation = Input.GetAxis("Mouse Y") * elevationSpeed;
        cannonRotation = Mathf.Clamp(cannonRotation - verticalRotation, cannonMaxAngle, cannonMinAngle);
        // Устанавливаем угол поворота в виде кватерниона
        cannon.localRotation = Quaternion.Euler(cannonRotation, 0f, 0f);

    }
}
