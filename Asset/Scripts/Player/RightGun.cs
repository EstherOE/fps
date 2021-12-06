using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class RightGun : MonoBehaviour
{

    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 40;
    public int damageAmount = 20;

    public int fireRate = 10;
    private float nextTimeToFire = 0;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineAmmo = 30;

    public float reloadTime = 2f;
    public bool isReloading;
    InputAction shoot;

    void Start()
    {
        shoot = new InputAction("Gun", binding: "<Gamepad>/x");
        shoot.AddBinding(" <keyboard>/C");

        shoot.Enable();

        currentAmmo = maxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
        //  animator.SetBool("isReloading", false);
    }
    bool isShooting;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Fire();
        }
    }

    void Fire()
    {

        RaycastHit hit;
        muzzleFlash.Play();
        currentAmmo--;

        if (Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            Instantiate(impactEffect, hit.point, impactRotation);

            Destroy(impactEffect, 2);
        }

    }
}