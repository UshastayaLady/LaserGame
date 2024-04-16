using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Renderer renderer;

    public float rotationSpeed = 5.0f; // �������� �������� �������
    public float minYRotation = -45.0f; // ����������� ���� �������� �� ��� Y
    public float maxYRotation = 45.0f; // ������������ ���� �������� �� ��� Y 

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

            // ��������� ����� ���� �������� �� ��� Y � ������ ��������
            float newRotationY = transform.eulerAngles.y - mouseY * rotationSpeed;

            // ��������� ����������� �� ���� ��������
            newRotationY = Mathf.Clamp(newRotationY, minYRotation, maxYRotation);

            // ��������� ����� ���� �������� � �������
            transform.rotation = UnityEngine.Quaternion.Euler(transform.eulerAngles.x, newRotationY, 0);


            //// �������� ���� � ����������
            //float horizontalInput = Input.GetAxis("Horizontal");

            //// ��������� ���� ��������
            //float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

            //// ��������� ���� �������� � ������������
            //float newRotationY = Mathf.Clamp(transform.eulerAngles.y + rotationAmount, minYRotation, maxYRotation);

            //// ��������� ����� ���� �������� � �������
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
