using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TankController : MonoBehaviour
{
    public float accelerationForce = 10f;
    public float maxSpeed = 5f;
    public float brakingForce = 5f;
    public float tiltSpeed = 2f;
    public float rotationSpeed = 200f; // Параметр для управления скоростью поворота

    private Rigidbody tankRigidbody;

    void Start()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Проверка направления движения
        float moveInput = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * rotationSpeed * Time.deltaTime, 0);

        // Применение силы для ускорения или торможения
        if (Mathf.Abs(tankRigidbody.velocity.magnitude) < maxSpeed)
        {
            if (moveInput > 0)
            {
                // Ускорение вперед
                tankRigidbody.AddRelativeForce(Vector3.forward * accelerationForce * moveInput);
                if (moveInput < 3 || moveInput > 0)
                {
                    tankRigidbody.AddRelativeForce(Vector3.forward * brakingForce * moveInput);
                }
            }
            else if (moveInput < 0)
            {
                // Торможение
                tankRigidbody.AddRelativeForce(Vector3.forward * brakingForce * moveInput);
            }
        }

        // Наклон танка в зависимости от направления движения
        float targetTiltAngle = moveInput * -5f;
        float currentTiltAngle = Mathf.LerpAngle(transform.localEulerAngles.x, targetTiltAngle, Time.deltaTime * tiltSpeed);
        transform.localRotation = Quaternion.Euler(currentTiltAngle, transform.rotation.eulerAngles.y, 0);

    }
}

