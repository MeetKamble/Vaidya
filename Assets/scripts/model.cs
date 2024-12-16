using UnityEngine;
using System.Collections;

public class Model : MonoBehaviour
{
    public Animator modelAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
    public bool walking;
    public Transform playerTrans;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.linearVelocity = transform.forward * w_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.linearVelocity = -transform.forward * w_speed * Time.deltaTime;
        }
    }

    // Start is called before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walking = false;
        w_speed = olw_speed; // Initialize walking speed
    }

    // Update is called once per frame
    void Update()
    {
        // Walk Forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            modelAnim.SetTrigger("walk");
            modelAnim.ResetTrigger("idle");
            walking = true;
        }

        // Walk Backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            modelAnim.SetTrigger("walkback");
            modelAnim.ResetTrigger("idle");
            walking = false;
        }

        // Run When Left Shift is Pressed
        if (walking && Input.GetKey(KeyCode.LeftShift))
        {
            w_speed += rn_speed;
            modelAnim.SetTrigger("run");
            modelAnim.ResetTrigger("walk");
        }

        // Stop Running When Left Shift is Released
        if (walking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            w_speed = olw_speed;
            modelAnim.SetTrigger("walk");
            modelAnim.ResetTrigger("run");
        }
    }
}


