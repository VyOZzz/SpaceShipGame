using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private float hpEnemy = 10;
    private Vector3 targetPosition;
    public float speed =1;
    private float distanceToKeep = 20f;
    
    private void FixedUpdate()
    {
        Move(GameManager.instance.ship.transform.position);
        RotatePlayer();
    }
    private void Move(Vector3 targetPosition)
    {
        var distanceToPlayer = Vector3.Distance(transform.position, targetPosition);
        if (!(distanceToPlayer > distanceToKeep)) return;
        var posToMove = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    
        transform.position = posToMove;

    }

    private void RotatePlayer()
    {
        var diff = GameManager.instance.ship.transform.position - transform.position;
        diff.Normalize();
        var rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        var finalRotation = 90f - rotationZ;
        transform.rotation = Quaternion.Euler(0, 0, -finalRotation);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("PlayerBullet")) return;
        Destroy(other.gameObject);
        hpEnemy -= other.gameObject.GetComponent<Bullet>().damage;
        if (hpEnemy <= 0)
        {
            HandleEnemyDeath();
        }
        GameManager.instance.UpdateKills();
    }

    private void HandleEnemyDeath()
    {
        GameManager.instance.kills++;
        
        Destroy(gameObject);
    }
}
