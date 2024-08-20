using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
public class SpawnMeteorite : MonoBehaviour
{
    
    public float halfWidth;
    public float halfHeight;
    [FormerlySerializedAs("meteorPefab")] public GameObject meteorPrefab;
    
    public Vector3 spawnPos;

    public Transform cameraPos;

    private float coolDownTime = 5f;

    private float countDown = 5;
    void Awake()
    {
        if (Camera.main != null) halfHeight = Camera.main.orthographicSize;
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
        var randomX = Random.Range(-halfWidth - 10, halfWidth + 10);
        var randomY = 2 * halfHeight + 10;
        
        spawnPos = new Vector3(randomX, randomY, 0) + cameraPos.position;
        spawnPos.z = 0;
        var newPrefab = Instantiate(meteorPrefab, spawnPos, quaternion.identity);
        meteorPrefab.SetActive(true);
        // var dir = cameraPos.position - spawnPos;
        // dir.z = 0;
        // dir.Normalize();
        //newPrefab.GetComponent<MeteoriteMove>().direction = dir;
    }
}
