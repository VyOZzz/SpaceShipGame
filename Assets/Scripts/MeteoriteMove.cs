using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MeteoriteMove : MonoBehaviour
{
    public float speed ;

    public Vector3 direction;
     public float distanceToDespawn = 50f;
    private void FixedUpdate()
    {
        if (GameManager.instance.isGameOver) return;
        transform.Translate(direction * (speed * Time.deltaTime));
        RotateMeteorite();
        DestroyMeteor();
    }

    private void RotateMeteorite()
    {
        float z = Random.Range(-1, 1);
        transform.Rotate(0,0, z);
    }

    private void DestroyMeteor()
    {
        var squareDistance = (GameManager.instance.ship.transform.position - transform.position).sqrMagnitude;
        if (squareDistance >= distanceToDespawn * distanceToDespawn)
        {
            Destroy(gameObject);
        }
    }
    
}
