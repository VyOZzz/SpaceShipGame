using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManagerGamePlayScene : MonoBehaviour
{
    public static UIManagerGamePlayScene Instance;
    public Text HpText;

    public Text KillText;

    public GameObject gameOverObject;
    // Start is called before the first frame update
    void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        gameOverObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            gameOverObject.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
