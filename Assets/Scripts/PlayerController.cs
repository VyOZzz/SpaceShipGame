using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPosition;
    private InputManager mouseManager;
    public new float speed = 20;
    public Rigidbody2D player;
    public Animator shipAnim;
    private static readonly int IsHurt = Animator.StringToHash("isHurt");
    private Coroutine hurtCoroutine;
    private void Start()
    {
        mouseManager = InputManager.Instance;
    }
    private void Update()
    {
        targetPosition = mouseManager.InputPosition;
    }

    private void FixedUpdate()
    {
        Move();
        RotatePlayer(targetPosition);
        if (GameManager.instance.HP <= 0)
        {
            
            GameManager.instance.HP = 0;
            GameManager.instance.isGameOver = true;
        }
        
    }

    private new void Move()
    {
        if (GameManager.instance.isGameOver) return;
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var movement = new Vector2(horizontalInput * speed, verticalInput * speed);
        player.velocity = movement;

    }
    private void RotatePlayer(Vector3 tgPosition)
    {
        if (GameManager.instance.isGameOver) return;
        var diff = tgPosition - transform.position;
        diff.Normalize();
        var rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        var finalRotation = 90f - rotationZ;
        transform.rotation = Quaternion.Euler(0, 0, -finalRotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyBullet"))
        {
            if (GameManager.instance.HP - other.gameObject.GetComponent<Bullet>().damage >= 0)
                GameManager.instance.HP -= other.gameObject.GetComponent<Bullet>().damage;
            else GameManager.instance.HP = 0;
            
            GameManager.instance.UpdateHp();
            Destroy(other.gameObject);
            shipAnim.SetBool(IsHurt, true);
            if (hurtCoroutine != null)
            {
                StopCoroutine(ResetIsHurt());
            }

            hurtCoroutine = StartCoroutine(ResetIsHurt());
            
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.instance.HP - 2 >= 0)
                GameManager.instance.HP -= 2;
            else GameManager.instance.HP = 0;
            GameManager.instance.UpdateHp();
            shipAnim.SetBool(IsHurt, true);
            if (hurtCoroutine != null)
            {
                StopCoroutine(ResetIsHurt());
            }

            hurtCoroutine = StartCoroutine(ResetIsHurt());
        }

        if (other.gameObject.CompareTag("Meteor"))
        {
            Destroy(other.gameObject);
            if (GameManager.instance.HP - 20 >= 0)
                GameManager.instance.HP -= 20;
            else GameManager.instance.HP = 0;
            GameManager.instance.UpdateHp();
            shipAnim.SetBool(IsHurt, true);
            if (hurtCoroutine != null)
            {
                StopCoroutine(ResetIsHurt());
            }

            hurtCoroutine = StartCoroutine(ResetIsHurt());
        }
    }

    private IEnumerator ResetIsHurt()
    {
        yield return new WaitForSeconds(2f);
        shipAnim.SetBool(IsHurt, false);
        hurtCoroutine = null;
    }

    
    
}