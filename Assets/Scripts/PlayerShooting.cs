using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
   [SerializeField] GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject weapon = GameObject.Find("Weapon");
            Vector3 weaponPosition = weapon.transform.position;
            Quaternion rotation = weapon.transform.rotation;
            Instantiate(bullet, weaponPosition, rotation);

            
        }
    }
}
