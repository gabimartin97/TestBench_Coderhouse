using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField]  float speed = 5;
    [SerializeField] float rotationSpeed = 50;
    float cameraAxisX = 0f;
    float cameraAxisZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        Vector3 direccion = Vector3.zero;
       
        if (Input.GetKey(KeyCode.W))
        {
            direccion += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direccion += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direccion += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direccion += Vector3.back;
        }
       
        transform.Translate(direccion.normalized * Time.deltaTime * speed);
        

              
        
    }

    public void RotatePlayer()
    {
        float anguloRotacion = 0f;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, );
        Vector3 direccion = screenCenter - mousePosition;

        Debug.Log("Mouse: " + mousePosition);
        Debug.Log("Centro: " + screenCenter);
        Debug.Log("Direccion: " + direccion);

        /*
        Obtengo el valor del input del cursor (Que en Mouse X va de -1(izquierda) a 1(derecha))
        en función de que tan a la izquierda o derecha se mueve el mouse.
        */

        //cameraAxisX += Input.GetAxis("Horizontal");
        //cameraAxisZ += Input.GetAxis("Vertical");
        // Forma para rotar "inmediatamente" hacia una nueva rotación creada con el método Euler (a partir de los ejes x,y,z)
        //transform.rotation = Quaternion.Euler(0,cameraAxisX * 0.1f, 0);
        // Forma para rotar "gradualmente" hacia una nueva rotación con Lerp.
        
        //Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }
}
