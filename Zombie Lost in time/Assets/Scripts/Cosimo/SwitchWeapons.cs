using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    [SerializeField] private GameObject weapon_0;
    [SerializeField] private GameObject weapon_1;
    [SerializeField] private GameObject weapon_2;
    [SerializeField] private GameObject weapon_3;
    [SerializeField] private GameObject weapon_4;
    private ShootingBehaviour currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = GetComponent<ShootingBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        string currentWeaponName = currentWeapon.GetCurrentWeaponName();

        switch (currentWeaponName)
        {
            case "Bow":
                weapon_0.SetActive(true);
                weapon_1.SetActive(false);
                weapon_2.SetActive(false);
                weapon_3.SetActive(false);
                weapon_4.SetActive(false);
                break;

            case "Revolver":
                weapon_0.SetActive(false);
                weapon_1.SetActive(true);
                weapon_2.SetActive(false);
                weapon_3.SetActive(false);
                weapon_4.SetActive(false);
                break;

            case "Ak-47":
                weapon_0.SetActive(false);
                weapon_1.SetActive(false);
                weapon_2.SetActive(true);
                weapon_3.SetActive(false);
                weapon_4.SetActive(false);
                break;

            case "ShotgunDB":
                weapon_0.SetActive(false);
                weapon_1.SetActive(false);
                weapon_2.SetActive(false);
                weapon_3.SetActive(true);
                weapon_4.SetActive(false);
                break;

            case "Minigun":
                weapon_0.SetActive(false);
                weapon_1.SetActive(false);
                weapon_2.SetActive(false);
                weapon_3.SetActive(false);
                weapon_4.SetActive(true);
                break;
        }
    }
}
