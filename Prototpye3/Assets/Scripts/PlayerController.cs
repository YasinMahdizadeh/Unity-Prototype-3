﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce = 10f;
    public float gravityModifier = 2;
    public bool isOnGround = true;
    public bool isGameOver = false;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerRB.AddForce(Vector3.up * 1000);
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce ,ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if ( collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            Debug.Log("Oveeer:(");
        }
    }
}
