using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private MoveableObj obj;
    Vector2 movement;
    Animator animator;
   
    void Start()
    {
        Move();
    }

    private void Update()
    {
        movement.x = obj.transform.position.x;
        movement.y = obj.transform.position.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        
    }

    public void Move()
    {
        obj.MoveTo(new Vector3(-3.5f, -0.5f, 0), () =>
        {
            obj.MoveTo(new Vector3(-3.5f, 3.5f, 0), () =>
            {
              
                obj.MoveTo(new Vector3(7.5f, 3.5f, 0), () =>
                {

                    obj.MoveTo(new Vector3(7.5f, -0.45f, 0), Move);
                });
            });
        });
    }
}
