using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TiltWindowX : MonoBehaviour
{
    public Quaternion mStart;
    public Vector2 mRot;
    public float halfWidth;

    public float halfHeight;
    public Vector2 range= new Vector2(5f, 1f);
    public float speedRot = 5f;
    // Start is called before the first frame update
    void Start()
    {
        halfWidth = Screen.width * 0.5f;
        halfHeight = Screen.height * 0.5f;
        mStart = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        
        float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth, -1f, 1f);
        float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight, -1f, 1f);
        mRot = Vector2.Lerp(mRot, new Vector2(x, y), Time.deltaTime * speedRot);
        Debug.Log(mRot);
        transform.localRotation = mStart * Quaternion.Euler( mRot.x * range.x,-mRot.y * range.y, 0f);
        Debug.Log(transform.position);
    }
}
