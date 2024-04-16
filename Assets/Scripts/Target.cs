using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Renderer renderer;

    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }




    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
        if (Input.GetMouseButton(0))
        {
           
            transform.Rotate(0,0,1);
            
        }
        if (Input.GetMouseButton(0))
        {

            transform.Rotate(0, 0, -1);

        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
