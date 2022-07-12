using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;
    private bool activateTimerToReset;
    private float defaultComboTimer = 0.3f;
    private float currentComboTimer;
    private Animator animator;  
    private ComboState currentComboState;
    public bool isAttacking = false;

    
    void Awake() 
    {
        playerAnim = GetComponent<CharacterAnimation>();
        animator = GetComponent<Animator>();


    }
    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE;
        
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentComboState == ComboState.PUNCH_3 ||
            currentComboState == ComboState.KICK_1||
            currentComboState == ComboState.KICK_2)
                return;

            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if(currentComboState == ComboState.PUNCH_1)
            {
                playerAnim.Punch_1();
            }
            if(currentComboState == ComboState.PUNCH_2)
            {
                playerAnim.Punch_2();
            }
            if(currentComboState == ComboState.PUNCH_3)
            {
                playerAnim.Punch_3();
            }
        }    

        if(Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetLayerWeight(1,0);

            if(currentComboState == ComboState.KICK_2 ||
            currentComboState == ComboState.PUNCH_3)
                return;
            
            if(currentComboState == ComboState.NONE ||
            currentComboState == ComboState.PUNCH_1||
            currentComboState == ComboState.PUNCH_2)
            {
                currentComboState = ComboState.KICK_1;
            }
            else if(currentComboState == ComboState.KICK_1)
            {
                currentComboState++;
            }

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.KICK_1)
            {
                playerAnim.Kick_1();
            }
            if(currentComboState == ComboState.KICK_2)
            {
                playerAnim.Kick_2();
            }
        }

        
    }

    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if(currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
