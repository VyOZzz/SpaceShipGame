using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorCollided : MonoBehaviour
{
    public Animator explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            explosion.SetBool("isDead", true);
            Destroy(other.gameObject);
        }
        
    }
    // event
    private void destroyMeteor()
    {
        Destroy(gameObject);
    }
}
