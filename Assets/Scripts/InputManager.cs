using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = System.Numerics.Vector3;

public class InputManager : MonoBehaviour
{
    
    public static InputManager Instance { get; private set; }
    [FormerlySerializedAs("inputPosition")] public UnityEngine.Vector3 InputPosition;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        InputPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        InputPosition.z = 0;
    }
}
