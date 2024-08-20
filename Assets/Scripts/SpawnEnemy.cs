using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnEnemy : MonoBehaviour
{
     
    public float halfWidth;
    public float halfHeight;
    [FormerlySerializedAs("meteorPefab")] public GameObject enemyPrefab;
    public Vector3 spawnPos;
    public Transform cameraPos;

    public float coolDownTime = 2f;

    public float countDown = 2;
    void Awake()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        SpawnPrefab();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.isGameOver) return;
        countDown -= Time.deltaTime;
        if (!(countDown <= 0)) return;
        SpawnPrefab();
        countDown = coolDownTime;

    }
    void SpawnPrefab()
    {
        if (Random.value > 0.5f)
        {
            // spawn tại vị trí bên trái || phải camera
            spawnPos = new Vector3(Random.value >0.5f ? -(2*halfWidth )  : 2 * halfWidth,
                Random.Range(-2*halfHeight, 2*halfHeight)
                ) + cameraPos.position;
        }
        else
        {
            // spawn tại vị trí tren || duoi  camera

            spawnPos = new Vector3(Random.Range(-2 * halfWidth, 2 * halfWidth),
                Random.value < 0.5f ? -(2 * halfHeight) : 2 * halfHeight) + cameraPos.position;
        }
        spawnPos.z = 0;
        var newPrefab = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemyPrefab.SetActive(true);
    }
}
