using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float health = 100f;

    public float Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            GameManager.IsGameOver = true;
            gameObject.SetActive(false);
        }
    }
    public void RecieveDamage(float damage)
    {
        health -= damage;
        Debug.Log("Vida restante: " + health);
    }

}
