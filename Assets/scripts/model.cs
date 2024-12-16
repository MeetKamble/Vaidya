using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class model : MonoBehaviour
{
    public Animator modelAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, run_speed, ro_speed;
    public bool walking;
    public Transform palyerTrans;
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W){
            playerRigid.angularVelocity = transform.forward * w_speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.S){
            playerRigid.angularVelocity = -transform.forward * w_speed * Time.deltaTime;

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            modelAnim.setTrigeer("walk");
            modelAnim.ResetTrigger("idle");
            walking = true;
        //steps1.setActive(true);
      }
        if (Input.GetKeyDown(KeyCode.W))
        {
            modelAnim.SetTrigger("walk");
            modelAnim.ResetTrigger("idle");
            walking = false;
            //steps1.setActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            modelAnim.SetTrigger("walkback");
            modelAnim.ResetTrigger("idle");
            //steps1.setActive(false);
        }
    }
}
