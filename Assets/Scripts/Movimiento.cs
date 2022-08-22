using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField]  float speed = 5;
   
    
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
       
       // transform.Translate(direccion.normalized * Time.deltaTime * speed);
        transform.position += direccion * Time.deltaTime * speed;

              
        
    }

    public void RotatePlayer()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, 0, Screen.height / 2);
        Vector3 cameraPosition = GameObject.Find("Superior Camera").transform.position;
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3 playerDefasaje = playerPosition - cameraPosition;

        playerDefasaje = new Vector3(playerDefasaje.x, 0, playerDefasaje.z);

        Vector3 mousePosition = new Vector3(Input.mousePosition.x , 0, Input.mousePosition.y );
        
         Vector3 direccion =   mousePosition - screenCenter - playerDefasaje;
        //Vector3 direccion = mousePosition - cameraPosition;
        transform.LookAt(direccion);
        //Debug.Log("Mouse: " + mousePosition);
        //Debug.Log("Centro: " + screenCenter);
        //Debug.Log("Direccion: " + direccion);
        //Debug.Log("Defasaje: " + playerDefasaje);
        //Debug.Log("Direccion: " + direccion);

    }
}
