using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed;
    public Vector3 direction = Vector3.up;
    private float distanceToDespawn ;
    public float damage;
    // enemy speed bullt = 2;
    
    public float maxBoundary  =55;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed *Time.deltaTime);
        distanceToDespawn = Vector3.Distance(transform.position, GameManager.instance.ship.transform.position);
        if ( distanceToDespawn > maxBoundary )
        {
            Destroy(gameObject);
        }
        
    }

    
}
