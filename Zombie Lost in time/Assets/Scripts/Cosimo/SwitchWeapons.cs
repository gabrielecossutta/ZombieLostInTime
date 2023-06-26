using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    [SerializeField] private GameObject weapon_0;
    [SerializeField] private GameObject weapon_1;
    [SerializeField] private GameObject weapon_2;
    [SerializeField] private GameObject weapon_3;
    private ShootingBehaviour currentWeapon;
    private string currentWeaponName;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = GetComponentInParent<ShootingBehaviour>();
        currentWeaponName = currentWeapon.GetCurrentWeaponName();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWeapon.GetCurrentWeaponName() == "Revolver")
        {
            weapon_0.SetActive(true);
            weapon_1.SetActive(false);
            weapon_2.SetActive(false);
            weapon_3.SetActive(false);
        }
        else if (currentWeapon.GetCurrentWeaponName() == "Ak-47")
        {
            weapon_0.SetActive(false);
            weapon_1.SetActive(true);
            weapon_2.SetActive(false);
            weapon_3.SetActive(false);
        }
        else if (currentWeapon.GetCurrentWeaponName() == "ShotgunDB")
        {
            weapon_0.SetActive(false);
            weapon_1.SetActive(false);
            weapon_2.SetActive(true);
            weapon_3.SetActive(false);
        }
        else if (currentWeapon.GetCurrentWeaponName() == "Minigun")
        {
            weapon_0.SetActive(false);
            weapon_1.SetActive(false);
            weapon_2.SetActive(false);
            weapon_3.SetActive(true);
        }
    }
}
