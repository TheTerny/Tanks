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
        // —охран€ем начальный угол поворота пушки
        initialRotationX = cannonTransform.eulerAngles.x;
    }

    void Update()
    {
        // ѕолучаем текущее положение мыши по оси Y
        float mouseY = Input.GetAxis("Mouse Y");

        // ¬ычисл€ем новый угол поворота пушки относительно начального положени€
        float newAngle = initialRotationX - mouseY;

        // ќграничиваем угол в заданных пределах
        newAngle = Mathf.Clamp(newAngle, initialRotationX + minAngle, initialRotationX + maxAngle);

        // ѕримен€ем новый угол поворота к пушке
        cannonTransform.eulerAngles = new Vector3(newAngle, 0f, 0f);
    }
}