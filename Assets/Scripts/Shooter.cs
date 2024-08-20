using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPos;
    public Vector3 direction;
    private float countDown = 0.15f;

    private float cooldownTime = 0.15f;
    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (Input.GetMouseButton(0)  && countDown <= 0)
        {
            // shoot
            direction = InputManager.Instance.InputPosition- GameManager.instance.ship.transform.position;
            Shoot();
            countDown = cooldownTime;
        }
    }

    void Shoot()
    {
        var newBullet = Instantiate(bullet, spawnPos.position, Quaternion.identity);
        var component = newBullet.GetComponent<Bullet>();
        component.direction = direction.normalized;
        component.damage = 5;

    }
}
