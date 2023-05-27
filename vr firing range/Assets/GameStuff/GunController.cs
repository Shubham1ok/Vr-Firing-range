using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GunController : MonoBehaviour
{
    // Reference to the Oculus Quest controller
    public OVRInput.Controller controller;
    public float FireDelay;
    public bool bCanShoot=true;
    public GameObject Bullet;
    public float speed;
    private bool triggerPressed = false;
    public Transform ShootPoint;
    public GameObject MuzzelFlash;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootGun();
        }
        // Check if the trigger button is pressed
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            // Check if the trigger was just pressed down
            if (!triggerPressed)
            {
                triggerPressed = true;

                // Check if the hand holding the gun is pressing the trigger
                if (IsTriggerHand())
                {
                    // Call the function to shoot the gun
                    ShootGun();
                }
            }
        }
        else
        {
            triggerPressed = false;
        }
    }

    private bool IsTriggerHand()
    {
        // Get the OVRInput controller mask for the hand holding the gun
        OVRInput.Controller handControllerMask = OVRInput.GetActiveController() & (OVRInput.Controller.LTouch | OVRInput.Controller.RTouch);

        // Check if the hand holding the gun matches the controller mask
        return (controller & handControllerMask) != 0;
    }

    private void ShootGun()
    {
        // Add your gun shooting logic here
        Debug.Log("Gun fired!");
        if (bCanShoot)
        {
            bCanShoot = false;
            StartCoroutine(Shoot());
            GameObject b = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            b.GetComponent<BulletScript>().BulletForce(speed);
            GetComponent<RevolverController>().HammerStrike();
            MuzzelFlash.SetActive(true);
        }
        // Example: Instantiate a bullet or perform shooting animation
        // Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(FireDelay);
        bCanShoot = true;
    }
}
