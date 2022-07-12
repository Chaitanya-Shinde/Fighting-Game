using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;
    [SerializeField]
    private float gravity = 9.81f;
    [SerializeField]
    private float jumpSpeed = 3f;
    [SerializeField]
    private float doubleJumpMultiplier = 0.5f;

    private CharacterController con;

    [SerializeField]
    private CharacterController enemyCon;
    private float defaultMoveSpeed;
    private  float directionY;
    [SerializeField]
    public float hopBackTimer = 0.5f, defaultHopBackTimer;
    private bool canDoubleJump = false;
    private Animator animator;
    public bool isGrounded = true;
    public bool isJumping;
    public bool isFalling;
    public bool isAttacking = false;
    public bool canMove;
    public bool jumpingBack = false;
    private CharacterAnimation char_Anim;
    public LayerMask groundLayer;

    [SerializeField]
    private Transform enemyTarget;

    private Transform cachedTransform;
    private Vector3 targetDirection;
    public float jumpingBackSpeed;
    public Vector3 direction;
    RaycastHit hitJumpBack;
    // Start is called before the first frame update

    void Awake()
    {
        cachedTransform = transform;
    }
    void Start()
    {
        con = GetComponent<CharacterController>();
        
        char_Anim = GetComponent<CharacterAnimation>();
        animator = GetComponent<Animator>();
        enemyTarget = GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).transform;

        defaultMoveSpeed = moveSpeed;
        defaultHopBackTimer = hopBackTimer;
    }

    void FixedUpdate()
    {
        //AnimatePlayerJump();
        if(isGrounded)
        {
            RotatePlayer();
            AnimatePlayerWalk();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        direction = new Vector3(0,0,horizontalInput);
        MovePlayer();
        JumpBack();

       


        //jumping
        //if(IsGrounded() == true)
        if(con.isGrounded == true)
        {
            
            //canDoubleJump = true;
            moveSpeed = defaultMoveSpeed;
            directionY= -0.2f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isFalling", false);
            isFalling = false;


            if(Input.GetButtonDown("Jump"))
            {
                //normal jumping
                //directionY = jumpSpeed;

                

                directionY = jumpSpeed;
                //ySpeed = jumpSpeed;
                animator.SetBool("isJumping", true);
                //con.height = 1.4f;
                isJumping = true;
                
                char_Anim.Jump();
                
            }  
        }
        else
        {
            
            animator.SetBool("isGrounded", false);
            isGrounded = false;
            //con.height = 2.0f;
            if((isJumping && directionY < -0.5f) || directionY < -2.0f)
            {
                
                animator.SetBool("isFalling", true);
                isFalling = true;
                animator.SetBool("isJumping", false);
            }

            //double jumping
            // if(Input.GetButtonDown("Jump") && canDoubleJump)
            // {
            //     directionY = jumpSpeed * doubleJumpMultiplier;
            //     canDoubleJump = false;
            // }
        }

        
    }

    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) !=0 )
        {            
            char_Anim.Walk(true);
            animator.SetLayerWeight(1,0.5f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 && Input.GetButton("Jump"))
        {
            char_Anim.Walk(true);
            animator.SetLayerWeight(1,0);
        }
        else
        {
            char_Anim.Walk(false);
            animator.SetLayerWeight(1,0);
        }
    }

    public void JumpBack()
    {
            //raycast to detect enemy and jump back to attack.
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            if(Physics.Raycast(ray, out hitJumpBack, 2.8f) && hopBackTimer>=0)
            {
                
                //Debug.Log("jumpBack");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* hitJumpBack.distance, Color.red);
                jumpingBack = true;
                
                animator.SetLayerWeight(2,1);
                char_Anim.JumpBack();
                animator.SetLayerWeight(1,0);
                char_Anim.Walk(false);
                
                if (hopBackTimer > 0) 
                {
                    con.Move(-transform.forward * Time.deltaTime * jumpingBackSpeed);
                    hopBackTimer -= Time.deltaTime;
                    
                } 
            }
            else
            {
                jumpingBack = false;    
                animator.SetLayerWeight(2,0);
                //Debug.Log("dont jumpBack");
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* 10, Color.green);
            }
    }

    public void ResetJumpBackTimer()
    {
        
        hopBackTimer = defaultHopBackTimer;
        Debug.Log("c");
        
    }
   

    void RotatePlayer()
    {
        // targetDirection = new Vector3(enemyTarget.position.x, transform.position.y, enemyTarget.position.z);
        // targetDirection.y = 0.0f;
        // targetDirection.x = 0.0f;
        // if(isGrounded)
        // {
        //     transform.LookAt(targetDirection.normalized);
        // }

        if(enemyTarget == null) { return; }

        Vector3 direction = (enemyTarget.position - cachedTransform.position).normalized;
        direction.y = 0f;
        cachedTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void MovePlayer()
    {
        directionY -= gravity * Time.deltaTime;
        direction.y= directionY;
        con.Move(direction * moveSpeed * Time.deltaTime);
        
    }

    // public bool IsGrounded()
    // {
    //     Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down)*1.0f, Color.red);
    //     return Physics.Raycast(transform.position, Vector3.down, 1.0f);
        

    // }

    // void AnimatePlayerJump()
    // {
    //     if(con.isGrounded)
    //     {
    //         directionY= -0.2f;
    //         animator.SetBool("isGrounded", true);
    //         isGrounded = true;
    //         animator.SetBool("isJumping", false);
    //         isJumping = false;
    //         animator.SetBool("isFalling", false);


    //         if(Input.GetKeyDown(KeyCode.Space))
    //         {
    //             directionY = jumpSpeed;
    //             //ySpeed = jumpSpeed;
    //             animator.SetBool("isJumping", true);
    //             isJumping = true;
    //             char_Anim.Jump();
    //         }
            
    //     }
    //     else
    //     {
    //         animator.SetBool("isGrounded", false);
    //         isGrounded = false;

          
    //         if((isJumping && directionY < -0.2f))
    //         {
    //             animator.SetBool("isFalling", true);
    //             animator.SetBool("isJumping", false);
    //         }
    //     }
    // }
}
