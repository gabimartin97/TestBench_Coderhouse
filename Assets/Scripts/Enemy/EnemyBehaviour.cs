using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float health = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.score++;
            Debug.Log(GameManager.score);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Bullet")
        {
            health -= collidedWith.GetComponent<BulletBehaviour>().GetDamage();
            collidedWith.GetComponent<BulletBehaviour>().Destroy();

        }
    }
}
