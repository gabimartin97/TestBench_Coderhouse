using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float damage = 25f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * (-1));
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public float GetDamage()
    {
        return damage;
    }
}
