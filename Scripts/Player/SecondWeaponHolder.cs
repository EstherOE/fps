using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecondWeaponHolder : MonoBehaviour
{
   
   

    public TextMeshProUGUI secondInfoText;
    void Start()
    {
        secondInfoText.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        secondInfoText.gameObject.SetActive(true);
        RightGun objSGun = FindObjectOfType<RightGun>();
        secondInfoText.text =objSGun.currentAmmo + " / " + objSGun.magazineAmmo;
    }
}
