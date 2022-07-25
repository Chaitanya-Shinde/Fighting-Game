using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterController con;
    private CharacterAnimation enemyAnim;
    public float speed = 5f, speedCache;
    [SerializeField]
    private Vector3 velocity;
    private Vector3 targetDirection;
    public Vector3 forwardVector;
    private Quaternion targetRotation;

    [SerializeField]
    private Transform playerTarget;
    private Transform cachedTransform;
    private Vector3 movementOffset;
    public float attackDistance = 2.8f;
    public float chasePlayerAfterAttack;
    private float currentAttackTime;
    private float defaultAttackTime = 2f;
    [SerializeField]
    private bool followPlayer, attackPlayer, canMove;
    private Animator animator;
    RaycastHit hitDistance;
    RaycastHit moveDistance;

    void Awake()
    {
        cachedTransform = transform;
        speedCache = speed;
        enemyAnim = GetComponent<CharacterAnimation>();
        con = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        velocity = con.velocity;

    }

    void Start() 
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
            
    }

    void Update()
    {
        Attack();
        LookAtPlayer();

        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if(Physics.Raycast(ray, out hitDistance, 2.8f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* hitDistance.distance, Color.red);
            followPlayer = false;            
        }
        else
        {
            followPlayer = true;
        }

        forwardVector = transform.forward;
        forwardVector.Normalize();
        
    }

    void FixedUpdate() 
    {
        FollowTarget();   
        //LookAtPlayer();
        
    }

    void FollowTarget()
    {
        if(!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            if(transform.position.x != playerTarget.position.x)
            {
                movementOffset.x = (playerTarget.position.x - transform.position.x) * 0.05f;
            }
            con.Move(movementOffset);
            canMove = true;
            Move();
            
            //velocity = transform.forward * speed;

            
        }
        else if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            canMove = false;
            //Debug.Log("walkstop");
            velocity = Vector3.zero; 
            enemyAnim.Walk(false);
            animator.SetLayerWeight(1,0);
            followPlayer = false;
            attackPlayer = true;
        }
    }

    void Attack()
    {
        if(!attackPlayer)
            return;

        currentAttackTime += Time.deltaTime;

        if(currentAttackTime > defaultAttackTime)
        {
            animator.SetLayerWeight(1,0);
            enemyAnim.EnemyAttack(Random.Range(0,5));
            velocity = Vector3.zero;
            currentAttackTime = 0f;
        }

        if(Vector3.Distance(transform.position , playerTarget.position) > 
        attackDistance + chasePlayerAfterAttack)
        {
            
            attackPlayer = false;
            followPlayer = true;
        }
    }

    void LookAtPlayer()
    {
        if(playerTarget == null) { return; }

        Vector3 direction = (playerTarget.position - cachedTransform.position).normalized;
        direction.y = 0f;
        cachedTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    void Move()
    {
        if(!followPlayer)
            return;
        
        if(followPlayer)
        {
            
            Ray moveRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

            if(Physics.Raycast(moveRay, out moveDistance, 3.8f))
            {
                speed = 0.0f;
                Debug.Log("b");
                animator.SetLayerWeight(1,0f);
                enemyAnim.Walk(false);
                
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* moveDistance.distance, Color.red);
                
                //canMove = false;
                
                followPlayer = false;            
            }
            else
            {
                speed = speedCache;
                con.Move(transform.forward * speed * Time.deltaTime);
                //Debug.Log("a");
                enemyAnim.Walk(true);
                animator.SetLayerWeight(1,0.5f);
            }
            

            // if(transform.forward.magnitude != 0)
            // {
                
                
                
            // }
            // else if(transform.forward.magnitude == 0)
            // {
                
                
            // }
        }
    }

    // private void OnCollisionEnter(Collision other) 
    // {
    //     if(other.gameObject.tag=="Player")
    //     {
    //         Debug.Log("walkstop");
    //         velocity = Vector3.zero;
    //     }
            
    // }

    
}
