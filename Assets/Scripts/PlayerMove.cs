using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim; 

    [SerializeField]Transform groundCheck;
    [SerializeField] LayerMask ground;
    
    [SerializeField] float mSpeed = 6f;
    [SerializeField] float jForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        // player movement
        rb.velocity = new Vector3(moveH * mSpeed, rb.velocity.y, moveV * mSpeed);
        if (rb.velocity !=Vector3.zero)
        {  
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        //Jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        { rb.velocity = new Vector3(rb.velocity.x, jForce, rb.velocity.z); }

        // exit game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
       
    }

  
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

   
}
