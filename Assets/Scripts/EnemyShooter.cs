using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public float damage;
    public  Vector3 direction;
    public GameObject bullet;
    public Transform gun;
    public float countDown = 2;
    public float coolDownTime = 2;
    private void FixedUpdate()
    {
        direction = GameManager.instance.ship.transform.position - gun.position; 
         countDown -= Time.deltaTime;
         if (!(countDown <= 0)) return;
         countDown = coolDownTime;
        Shoot();

    }

    private void Shoot()
    {
        if (GameManager.instance.isGameOver) return;
        var instantiate = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        var component = instantiate.GetComponent<Bullet>();
        component.direction = direction;
        component.damage = 2;
    }
}
