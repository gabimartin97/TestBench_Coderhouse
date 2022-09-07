using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] protected float health = 100f;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float damageCooldown = 0.5f;
    // Start is called before the first frame update
    protected bool damageInCooldown = false;

    protected float damageCooldownTimer = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Attack();
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Score++;

        }


    }

    private void OnCollisionStay(Collision collision)
    {
     if(collision.gameObject.CompareTag("Player"))
        {
            if(!damageInCooldown)
            {
                collision.gameObject.GetComponent<PlayerBehaviour>().RecieveDamage(damage);
                damageInCooldown = true;
            }
            
        }
    }

    public virtual void RecieveDamage(float damage)
    {
        health -= damage;
    }

    protected  void Attack()
    {
        if (damageInCooldown)
        {
            damageCooldownTimer += Time.deltaTime;
            if (damageCooldownTimer >= damageCooldown)
            {
                damageInCooldown = false;
                damageCooldownTimer = 0f;
            }
        }
    }
}
