using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 25f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformVector(Vector3.forward) * -1000f, ForceMode.Impulse);
            collision.gameObject.GetComponent<EnemyBehaviour>().RecieveDamage(damage);
        }
        
        Destroy();
    }
}
