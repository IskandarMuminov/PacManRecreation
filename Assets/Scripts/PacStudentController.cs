using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private LevelGenerator levelMap;
    [SerializeField] private Animator animator;
    private Input lastInput;
    private Input currentInput;
   

    private void Start()
    {
        levelMap = FindObjectOfType<LevelGenerator>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }
}

