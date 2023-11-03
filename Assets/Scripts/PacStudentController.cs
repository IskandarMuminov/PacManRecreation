using System.Collections;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    [SerializeField] private Animator animator;

    private Vector3 inputDirection = Vector3.zero;
    private Vector3 movementDirection = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        HandleInput();
        MoveCharacter();
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        inputDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;
    }

    private void MoveCharacter()
    {
        if (inputDirection != Vector3.zero)
        {
            movementDirection = inputDirection;
        }

        Vector3 movement = movementDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
    }
}