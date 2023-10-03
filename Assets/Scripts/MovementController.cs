using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private MoveableObj obj;

    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    private void Move()
    {
        while(obj.enabled)
        {
            obj.MoveTo(new Vector3(-3.5f, -0.5f, 0),
            onComplete: () => obj.MoveTo(new Vector3(-3.5f, 3.5f, 0),
            onComplete: () => obj.MoveTo(new Vector3(7.5f, 3.5f, 0),
            onComplete: () => obj.MoveTo(new Vector3(7.5f, -0.45f, 0)))));

        }
        
    }
}
