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
    [SerializeField] private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
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
        SetAnimatorWeaponParameter();
    }

    private void FixedUpdate()
    {
        MovementInput();
    }

    void SetAnimatorParameter()
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

    void ControllerInput()
    {
        float x = UserInput.instance.MoveInput.x;
        float z = UserInput.instance.MoveInput.y;

        //float x = Input.GetAxisRaw("Horizontal");
        //float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //Quaternion toRotate = Quaternion.LookRotation(direction);
            //transform.rotation = toRotate;

            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue)/* * Time.deltaTime*/;
            animator.SetFloat("Speed_f", 1);

            SetAnimatorParameter();
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);

            SetAnimatorParameter();
        }
    }

    void KeyboardInuput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            direction = new Vector3(x, 0, z);
            if (direction.magnitude > 1f)
            {
                direction.Normalize();
            }

            Quaternion toRotate = Quaternion.LookRotation(direction);
            transform.rotation = toRotate;

            Rb.velocity = direction * (speed + Status.Instance.speedUpgradedValue);
            animator.SetFloat("Speed_f", 1,10, Time.deltaTime);
            SetAnimatorParameter();
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0, 10, Time.deltaTime);
            SetAnimatorParameter();
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
            SetAnimatorParameter();
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);
            SetAnimatorParameter();
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
            SetAnimatorParameter();

            if (direction == Vector3.zero)
            {
                Rb.velocity = Vector3.zero;
                animator.SetFloat("Speed_f", 0);
                SetAnimatorParameter();
            }
        }

        if (direction != Vector3.zero)
        {
            Quaternion ToRotate = Quaternion.LookRotation(direction);
            transform.rotation = ToRotate; //rotazione del player in base a dove stiamo andando
        }
    }

    void SetAnimatorWeaponParameter()

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
}
