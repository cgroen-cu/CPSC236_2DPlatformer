using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed = 25f;
    public bool hasJumpPotion = false;
    public bool hasSpeedPotion = false;
    public int potionModAmount = 0;

    private float potionTimeMax = 10f;
    private float potionTimeCur = 0f;

    float horizontalMove = 0f;
    bool jumpFlag = false;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (jumpFlag)
        {
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    public void OnLanding()
    {
        jump = false;
    }

    void FixedUpdate()
    {
        if (hasJumpPotion && potionTimeCur < potionTimeMax)
        {
            controller.m_JumpForceMod = potionModAmount;
            potionTimeCur += Time.fixedDeltaTime;
        } else
        {
            potionTimeCur = 0f;
            controller.m_JumpForceMod = 0;
            hasJumpPotion = false;
        }
        if (hasSpeedPotion && potionTimeCur < potionTimeMax)
        {
            controller.m_SpeedForceMod = potionModAmount;
            potionTimeCur += Time.fixedDeltaTime;
        }
        else
        {
            potionTimeCur = 0f;
            controller.m_SpeedForceMod = 0;
            hasSpeedPotion = false;
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = true;
        }
    }
}
