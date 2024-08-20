using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public float z;
    public  float speed ;
    private PlayerController shipPos;

    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        shipPos = GameManager.instance.ship;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = shipPos.transform.position;
        targetPosition.z = z;
    }

    private void FixedUpdate()
    {
        Move(targetPosition);
    }

    private void Move(Vector3 targetPosition)
    {
        var posToMove = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = posToMove;
        
    }
}
