using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public PlayerController ship;
    public float HP =100;
    [FormerlySerializedAs("Kills")] public int kills=0;
    public bool isGameOver = false;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    
    private void Start()
    {
        
        
        
        kills = 0;
        UpdateHp();
        UpdateKills();
    }

    private void OnEnable()
    {
        Debug.Log("GameManager OnEnable() called");

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            Debug.Log("Player found, assigning PlayerController");
            ship = playerObject.GetComponent<PlayerController>();
            if (ship == null)
            {
                Debug.LogError("PlayerController component not found on Player object");
            }
        }
        else
        {
            Debug.LogError("Player object not found in the scene");
        }

    }

    void Update()
    {
    }

    public void UpdateHp()
    {
        UIManagerGamePlayScene.Instance.HpText.text = "HP: " + HP;
    }

    public void UpdateKills()
    {
        UIManagerGamePlayScene.Instance.KillText.text = "KILLS: " + kills;
    }
}
