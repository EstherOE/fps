using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class WeaponSwitching : MonoBehaviour
{
    InputAction switching;
    public int selectedWeapon = 0;
    public TextMeshProUGUI ammoInfoText;
    public TextMeshProUGUI secondAmmoInfoText;

    void Start()
    {
         switching = new InputAction("Switch", binding: "<Mouse>/scroll");
        switching.AddBinding("<Gamepad>/Dpad");
        switching.Enable();
        SelectWeapon();
        secondAmmoInfoText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



        Gun objGun = FindObjectOfType<Gun>();
        RightGun rightGun = FindObjectOfType<RightGun>();

        ammoInfoText.text = objGun.currentAmmo + " / " + objGun.magazineAmmo;
        secondAmmoInfoText.text = rightGun.currentAmmo + " / " + rightGun.magazineAmmo;
        float scrollValue =switching.ReadValue<Vector2>().y;
        int previousSelected = selectedWeapon;

        if (scrollValue > 0)
        {
            selectedWeapon--;
            if (selectedWeapon == 3)
            {
                selectedWeapon = 0;
            }
           
        } else if (scrollValue < 0)
        {
            selectedWeapon--;
            if (selectedWeapon == -1)
                selectedWeapon = 2;
        }

        if (selectedWeapon == 0)
        {
           secondAmmoInfoText.gameObject.SetActive(true);

        }
        else if(selectedWeapon==1)
        {
            secondAmmoInfoText.gameObject.SetActive(false);

        }
        if (previousSelected != selectedWeapon)
        {
            SelectWeapon();
        }

       
    }

    private void SelectWeapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedWeapon).gameObject.SetActive(true);
    }
}
