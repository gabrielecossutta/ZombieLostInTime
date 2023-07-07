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
    private int currentWeaponIndex;
    private void Start()
    {
        animator = GetComponent<Status>().animator;
        animator.SetInteger("WeaponType_int", 11);
        Rb = GetComponent<Rigidbody>();
        currentWeapon = GetComponent<ShootingBehaviour>();
        currentWeaponIndex = currentWeapon.currentWeaponIndex;
    }

    private void Update()
    {
        SetAnimatorWeaponParameter();
        SetAnimatorBodyPositionParameter();
    }

    private void FixedUpdate()
    {
        MovementInput();
    }

    void SetAnimatorBodyPositionParameter()
    {
        string weaponName = currentWeapon.GetCurrentWeaponName();

        switch (weaponName)
        {
            case "Revolver":
                if (animator.GetFloat("Speed_f") != 0)
                {
                    animator.SetFloat("Body_Vertical_f", 0.3f);
                    animator.SetFloat("Body_Horizontal_f", 0f);
                    animator.SetFloat("Head_Horizontal_f", -0.1f);
                }
                else
                {
                    animator.SetFloat("Body_Vertical_f", 0f);
                    animator.SetFloat("Body_Horizontal_f", 0f);
                    animator.SetFloat("Head_Horizontal_f", -0.1f);
                }
                break;

            case "Bow":
            case "Ak-47":
            case "ShotgunDB":
            case "Minigun":
                if (animator.GetFloat("Speed_f") != 0)
                {
                    animator.SetFloat("Body_Vertical_f", 0.3f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                    animator.SetFloat("Head_Horizontal_f", -0.6f);
                }
                else
                {
                    animator.SetFloat("Body_Vertical_f", 0f);
                    animator.SetFloat("Body_Horizontal_f", 0.6f);
                    animator.SetFloat("Head_Horizontal_f", -0.6f);
                }
                break;
        }
    }

    void MovementInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(x, 0, z).normalized; //vettore direzione a cui vogliamo andare
            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue);
            animator.SetFloat("Speed_f", 1);
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);
        }

        if (Mathf.Abs(Input.GetAxis("HorizontalGamepad")) > 0.1f || Mathf.Abs(Input.GetAxis("VerticalGamepad")) > 0.1f)
        {
            x = Input.GetAxis("HorizontalGamepad");
            z = Input.GetAxis("VerticalGamepad");

            direction = new Vector3(x, 0, z).normalized;
            Quaternion toRotate = Quaternion.LookRotation(direction);
            transform.rotation = toRotate;

            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue);
            animator.SetFloat("Speed_f", 1);

            if (direction == Vector3.zero)
            {
                Rb.velocity = Vector3.zero;
                animator.SetFloat("Speed_f", 0);
            }
        }

        if (direction != Vector3.zero)
        {
            Quaternion ToRotate = Quaternion.LookRotation(direction);
            transform.rotation = ToRotate; //rotazione del player in base a dove stiamo andando
        }
    }

    void ControllerInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
        {
            direction = new Vector3(x, 0, z);
            if (direction.magnitude > 1f)
            {
                direction.Normalize();
            }

            Quaternion toRotate = Quaternion.LookRotation(direction);
            transform.rotation = toRotate;

            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue);
            animator.SetFloat("Speed_f", 1);
            SetAnimatorBodyPositionParameter();
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);
            SetAnimatorBodyPositionParameter();
        }
    }

    void KeyboardInuput()
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
            SetAnimatorBodyPositionParameter();
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);
            SetAnimatorBodyPositionParameter();
        }
    }

    void SetAnimatorWeaponParameter()
    {
        if (currentWeaponIndex != currentWeapon.currentWeaponIndex)
        {
            currentWeaponIndex = currentWeapon.currentWeaponIndex;
            if (currentWeapon.GetCurrentWeaponName() == "Bow")
            {
                animator.SetInteger("WeaponType_int", 11);
            }
            else if (currentWeapon.GetCurrentWeaponName() == "Revolver")
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
    }
}
