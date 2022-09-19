using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float health = 100f;
    [SerializeField] GameObject Weapon;
    [SerializeField] Transform WeaponHand;
    [SerializeField] List<GameObject> weaponList;




    public float Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {
        weaponList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            GameManager.IsGameOver = true;
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            disableAllWeapon();
            weaponToHand();
            foreach (GameObject Weapon in weaponList)
            {
                weaponList[0].SetActive(true);
            }
        }
         if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            disableAllWeapon();
            weaponToHand();
            foreach (GameObject Weapon in weaponList)
            {
                weaponList[1].SetActive(true);
            }
        }

    }
    public void RecieveDamage(float damage)
    {
        health -= damage;
        Debug.Log("Vida restante: " + health);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Weapon = collision.gameObject;
            Weapon.SetActive(false);
            weaponList.Add(Weapon);

        }

    }
    private void weaponToHand()
    {
        Weapon.transform.SetParent(WeaponHand);
        Weapon.transform.localPosition = Vector3.zero;
        Weapon.transform.localRotation = Quaternion.identity;
        Weapon.GetComponent<Gun>().enabled = true;
        Weapon.GetComponent<Gun>().PlayerRb = GetComponent<Rigidbody>();

    }
    private void disableAllWeapon()
    {
        foreach (GameObject Weapon in weaponList)
        {
            Weapon.SetActive(false);
        }
    }



}
