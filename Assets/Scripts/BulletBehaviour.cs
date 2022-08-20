using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime * (-1));
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
