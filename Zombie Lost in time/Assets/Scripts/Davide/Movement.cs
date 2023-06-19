using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    private Rigidbody Rb;
    private Animator animator;
    private ShootingBehaviour currentWeapon;
    private string currentWeaponName;

    private void Start()
    {
        animator = GetComponent<Status>().animator;
        animator.SetInteger("WeaponType_int", 1);
        Rb = GetComponent<Rigidbody>();
        currentWeapon = GetComponent<ShootingBehaviour>();
        currentWeaponName = currentWeapon.GetCurrentWeaponName();
    }

    private void Update()
    {
        if (currentWeapon.GetCurrentWeaponName() == "Revolver")
        {
            animator.SetInteger("WeaponType_int", 1);
        }
        else if (currentWeapon.GetCurrentWeaponName() == "Ak-47")
        {
            animator.SetInteger("WeaponType_int", 2);
        }
        else if (currentWeapon.GetCurrentWeaponName() == "ShotgunDB")
        {
            animator.SetInteger("WeaponType_int", 4);
        }
        else if (currentWeapon.GetCurrentWeaponName() == "Minigun")
        {
            animator.SetInteger("WeaponType_int", 9);
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (direction != Vector3.zero)
        {
            Quaternion ToRotate = Quaternion.LookRotation(direction);
            transform.rotation = ToRotate; //rotazione del player in base a dove stiamo andando
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(x, 0, z); //vettore direzione a cui vogliamo andare
            if (direction.magnitude > 1f)
            {
                direction.Normalize();
            }

            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue);
            animator.SetFloat("Speed_f", 1);
            SetAnimationParameter();
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);
            SetAnimationParameter();
        }
    }

    void SetAnimationParameter()
    {
        if (currentWeapon.GetCurrentWeaponName() == "Revolver")
        {
            if (animator.GetFloat("Speed_f") == 1)
            {
                animator.SetFloat("Body_Vertical_f", 0.3f);
                animator.SetFloat("Body_Horizontal_f", 0f);
            }
            else
            {
                animator.SetFloat("Body_Vertical_f", 0f);
                animator.SetFloat("Body_Horizontal_f", 0f);
                animator.SetFloat("Head_Horizontal_f", -0.1f);
            }
        }
        else if (currentWeapon.GetCurrentWeaponName() == "Ak-47")
            {
                if (animator.GetFloat("Speed_f") == 1)
                {
                    animator.SetFloat("Body_Vertical_f", 0.3f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                }
                else
                {
                    animator.SetFloat("Body_Vertical_f", 0f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                    animator.SetFloat("Head_Horizontal_f", -0.6f);
                }
            }
        else if (currentWeapon.GetCurrentWeaponName() == "ShotgunDB")
            {
                if (animator.GetFloat("Speed_f") == 1)
                {
                    animator.SetFloat("Body_Vertical_f", 0.3f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                }
                else
                {
                    animator.SetFloat("Body_Vertical_f", 0f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                    animator.SetFloat("Head_Horizontal_f", -0.6f);
                }
            }
        else if (currentWeapon.GetCurrentWeaponName() == "Minigun")
            {
                if (animator.GetFloat("Speed_f") == 1)
                {
                    animator.SetFloat("Body_Vertical_f", 0.3f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                }
                else
                {
                    animator.SetFloat("Body_Vertical_f", 0f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                    animator.SetFloat("Head_Horizontal_f", -0.6f);
                }
            }
    }
}
