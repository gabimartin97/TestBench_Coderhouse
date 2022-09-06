using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{
    //bullet 
    [SerializeField] GameObject bullet;
    //bullet force
    [SerializeField] float shootForce = 40f; 
    
    //Gun stats
    [SerializeField] float timeBetweenShooting = 0.1f; 
    [SerializeField] float reloadTime = 2f;
    [SerializeField] float timeBetweenShots=0.1f;
    [SerializeField] float spread = 0.1f;
    [SerializeField] int magazineSize = 24;
    [SerializeField] int bulletsPerTap = 1;
    [SerializeField] bool allowButtonHold = true;
    
    int bulletsLeft, bulletsShot;

    //Reference
    private Transform attackPoint;

    //Recoil
     private Rigidbody playerRb;
    [SerializeField] float recoilForce = 40f;

    //Graphics
    public GameObject muzzleFlash;
    private TextMeshProUGUI ammunitionDisplay;
    //bools
    bool shooting, readyToShoot, reloading;
    //bug fixing :D
    public bool allowInvoke = true;

    public Rigidbody PlayerRb { get => playerRb; set => playerRb = value; }

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Start()
    {
        ammunitionDisplay = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        attackPoint = transform.Find("Nozzle");
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        //Set ammo display, if it exists :D
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;



        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = attackPoint.TransformDirection(Vector3.forward);

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction
        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        //currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (muzzleFlash != null)
           Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            //Add recoil to player (should only be called once)
            PlayerRb.AddForce(-directionWithSpread.normalized * recoilForce, ForceMode.Impulse);
        }
        //if more than one bulletsPerTap make sure to repeat shoot function
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
