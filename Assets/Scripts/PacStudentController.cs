using System.Collections;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private LevelGenerator levelMap; 

    private Vector3 targetPosition;
    private Vector3 currentInput;
    private Vector3 lastInput;
    private bool isMoving = false;

    private void Start()
    {
        targetPosition = transform.position;
        lastInput = Vector3.zero;
    }

    private void Update()
    {
        HandleInput();
        MovePacStudent();
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        currentInput = new Vector3(horizontalInput, verticalInput, 0).normalized;

        if (currentInput != Vector3.zero)
        {
            lastInput = currentInput;
        }
    }

    private void MovePacStudent()
    {
        if (!isMoving)
        {
            if (currentInput != Vector3.zero && IsWalkable(transform.position + currentInput))
            {
                targetPosition = transform.position + currentInput;
                isMoving = true;
            }
            else if (IsWalkable(transform.position + lastInput))
            {
                targetPosition = transform.position + lastInput;
                isMoving = true;
            }
        }

        if (isMoving)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    private bool IsWalkable(Vector3 position)
    {
        
        Vector3Int gridPosition = levelMap.WorldToGridPosition(position);

        if (IsInBounds(gridPosition))
        {
            int cellValue = levelMap.mapData[gridPosition.y, gridPosition.x];
            return cellValue != 1 && cellValue != 2 && cellValue != 3 && cellValue != 4 && cellValue != 7;
        }

        return false;
    }

    private bool IsInBounds(Vector3Int gridPosition)
    {
        int maxY = levelMap.mapData.GetLength(0);
        int maxX = levelMap.mapData.GetLength(1);

        return gridPosition.y >= 0 && gridPosition.y < maxY &&
               gridPosition.x >= 0 && gridPosition.x < maxX;
    }
}