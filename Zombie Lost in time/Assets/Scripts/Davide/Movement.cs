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

    void Start()
    {
        animator = GetComponent<Status>().animator;
        animator.SetInteger("WeaponType_int", 2);
        Rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

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
            animator.SetFloat("Body_Vertical_f", 0.3f);
            animator.SetFloat("Body_Horizontal_f", 0.6f);
        }
        else
        {
            Rb.velocity = Vector3.zero;
            animator.SetFloat("Speed_f", 0);
            animator.SetFloat("Body_Vertical_f", 0f);
            animator.SetFloat("Body_Horizontal_f", 0.6f);
            animator.SetFloat("Head_Horizontal_f", -0.6f);
        }
    }
}
