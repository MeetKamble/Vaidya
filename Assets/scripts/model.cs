using UnityEngine;

public class Model : MonoBehaviour
{
    public Rigidbody playerRigid; // Reference to the Rigidbody component
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed; // Speed variables
    public bool walking;
    public Transform playerTrans; // Reference to the player's Transform

    void Start()
    {
        // Initialize values
        walking = false;
        w_speed = olw_speed; // Initialize walking speed

        // Lock the Rigidbody rotation to prevent falling
        playerRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        // Move Forward
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.linearVelocity = transform.forward * w_speed * Time.deltaTime; // Fixed `linearVelocity` to `velocity`
        }

        // Move Backward
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.linearVelocity = -transform.forward * w_speed * Time.deltaTime;
        }
    }

    void Update()
    {
        // Walk Forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            walking = true;
        }

        // Walk Backward
        if (Input.GetKeyDown(KeyCode.S))
        {
            walking = false;
        }

        // Run When Left Shift is Pressed
        if (walking && Input.GetKey(KeyCode.LeftShift))
        {
            w_speed += rn_speed;
        }

        // Stop Running When Left Shift is Released
        if (walking && Input.GetKeyUp(KeyCode.LeftShift))
        {
            w_speed = olw_speed;
        }
    }
}
