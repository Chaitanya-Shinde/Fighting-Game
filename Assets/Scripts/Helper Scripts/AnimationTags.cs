using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTags
{
    public const string MOVEMENT = "Movement";
    public const string PUNCH_1_TRIGGER = "Punch";
    public const string PUNCH_2_TRIGGER = "Hook";
    public const string PUNCH_3_TRIGGER = "CrossPunch";

    public const string KICK_1_TRIGGER = "Kick1";
    public const string KICK_2_TRIGGER = "Kick2";
    public const string LEG_SWEEP_TRIGGER = "LegSweep";
    public const string SWEEP_FALL = "SweepFall";

    public const string SPELL_1_TRIGGER = "Spell1";

    public const string IDLE_ANIMATION = "Idle";

    public const string JUMP_ANIMATION = "Jumping";
    
    public const string KNOCK_DOWN_TRIGGER = "KnockDown";
    //public const string KNOCK_DOWN_BOOL = "KnockDown1";
    public const string STAND_UP_TRIGGER = "StandUp";
    public const string HIT_TRIGGER = "Hit";
    public const string DEATH_TRIGGER = "Death";

    public const string JUMP_BACK_TRIGGER = "JumpBack";

}

public class Axis
{
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";
}

public class Tags
{
    public const string GROUND_TAG = "Ground";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

    public const string LEFT_ARM_TAG = "LeftArm";
    public const string LEFT_LEG_TAG = "LeftLeg";
    public const string RIGHT_ARM_TAG = "RightArm";
    public const string RIGHT_LEG_TAG = "RightLeg";
    public const string UNTAGGED_TAG = "Untagged";
    public const string MAIN_CAMERA_TAG = "MainCamera";
    public const string HEALTH_UI = "HealthUI";
}
