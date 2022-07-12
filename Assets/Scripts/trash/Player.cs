using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float walkSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 9.81f;
    public float ySpeed;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;
    public Vector3 velocity;
    public bool isGrounded = true;
    public bool isJumping;
    public bool isAttacking = false;
    private CharacterAnimation char_Anim;
    public LayerMask groundLayer;
    private CapsuleCollider col;

    public float directionY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        char_Anim = GetComponent<CharacterAnimation>();
        animator = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
    }
    void Update() 
    {
        AnimatePlayerWalk();
        directionY -= gravity * Time.deltaTime;
        velocity.y = directionY;
        //ySpeed += Physics.gravity.y * Time.deltaTime;
        
    }

    void FixedUpdate()
    {
       DetectMovement();
       AnimatePlayerJump();
    }

    public void DetectMovement()
    {
        rb.velocity = velocity;
        velocity = 
        new Vector3(rb.velocity.x,
        rb.velocity.y,
        Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * walkSpeed);

        //velocity.y = ySpeed;
        //characterController.Move(moveDirection * Time.deltaTime);
    }

    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) !=0 )
        {            
            char_Anim.Walk(true);
            animator.SetLayerWeight(1,0.5f);
        }
        else
        {
            char_Anim.Walk(false);
            animator.SetLayerWeight(1,0);
        }
    }

    void AnimatePlayerJump()
    {
        if(IsGrounded())
        {
            //ySpeed = -0.5f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);


            if(Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpSpeed;
                //ySpeed = jumpSpeed;
                animator.SetBool("isJumping", true);
                isJumping = true;
                char_Anim.Jump();
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
            
        }
        else
        {
            animator.SetBool("isGrounded", false);
            isGrounded = false;

          
            if((isJumping && ySpeed < -0.5f) || ySpeed <-2)
            {
                animator.SetBool("isFalling", true);
                animator.SetBool("isJumping", false);
            }
        }
    }



    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center,
        new Vector3(col.bounds.center.x, col.bounds.center.y, col.bounds.center.z),
        col.radius * 50f, groundLayer);
    }

}     
