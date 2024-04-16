using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Renderer renderer;

    public float rotationSpeed = 5.0f; // Скорость вращения объекта
    public float minYRotation = -45.0f; // Минимальный угол вращения по оси Y
    public float maxYRotation = 45.0f; // Максимальный угол вращения по оси Y 

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {


            float mouseY = Input.GetAxis("Mouse Y");

            // Вычисляем новый угол вращения по оси Y с учетом скорости
            float newRotationY = transform.eulerAngles.y - mouseY * rotationSpeed;

            // Применяем ограничения по углу вращения
            newRotationY = Mathf.Clamp(newRotationY, minYRotation, maxYRotation);

            // Применяем новый угол вращения к объекту
            transform.rotation = UnityEngine.Quaternion.Euler(transform.eulerAngles.x, newRotationY, 0);


            //// Получаем ввод с клавиатуры
            //float horizontalInput = Input.GetAxis("Horizontal");

            //// Вычисляем угол вращения
            //float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

            //// Применяем угол вращения с ограничением
            //float newRotationY = Mathf.Clamp(transform.eulerAngles.y + rotationAmount, minYRotation, maxYRotation);

            //// Применяем новый угол вращения к объекту
            //transform.rotation = UnityEngine.Quaternion.Euler(transform.eulerAngles.x, newRotationY, 0);



        }

    }


    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;        
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
