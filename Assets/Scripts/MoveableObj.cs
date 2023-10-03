using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObj : MonoBehaviour
{
    [SerializeField] private float speedMeterPerSecond = 5f;

    private Vector3 destination;
    private Vector3 startPos;
    private float totalLerpDuration;
    private float elapsedLerpDuration;
    private Action onCompleteCallback;
   
    
    void Update()
    {
        if (elapsedLerpDuration >= totalLerpDuration && totalLerpDuration > 0)
            return;

        elapsedLerpDuration += Time.deltaTime;
        float percent = elapsedLerpDuration / totalLerpDuration;

        transform.position = Vector3.Lerp(startPos, destination, percent);

        if (elapsedLerpDuration >= totalLerpDuration )
        {
            onCompleteCallback.Invoke();
        }
        
    }

    public void MoveTo(Vector3 destionation, Action onComplete = null) { 
        var distanceToNextWaypoint = Vector3.Distance(transform.position, destionation);
        totalLerpDuration = distanceToNextWaypoint / speedMeterPerSecond;

        startPos = transform.position;
        destination = destionation;
        elapsedLerpDuration = 0f;
        onCompleteCallback = onComplete;
    }
}
