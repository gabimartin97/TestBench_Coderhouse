using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    
    [SerializeField] GameObject Weapon;
    [SerializeField] Transform WeaponHand;

    static  public event Action OnDead;
    static public event Action<float,float> OnHealthChange;

    private float health = 100f;
    private float maxHealth = 100f;
    public float Health { get => health; set => health = value; }

   
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            OnDead.Invoke();
            gameObject.SetActive(false);
        }
    }
    public void RecieveDamage(float damage)
    {
        health -= damage;
        OnHealthChange.Invoke(health, maxHealth);
        Debug.Log("Vida restante: " + health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(Weapon); //Destruye el arma que tiene en la mano. Mejorar
            Weapon = collision.gameObject;
            Weapon.transform.SetParent(WeaponHand);
            Weapon.transform.localPosition = Vector3.zero;
            Weapon.transform.localRotation = Quaternion.identity;
            Weapon.GetComponent<Gun>().enabled = true;
            Weapon.GetComponent<Gun>().PlayerRb = GetComponent<Rigidbody>();

        }
    }
}
