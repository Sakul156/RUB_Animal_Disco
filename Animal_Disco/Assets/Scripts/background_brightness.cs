using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_brightness : MonoBehaviour
{
    private cheatCodes cc;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.O))
        {
            Color color = sr.color;
            color.r = Mathf.Clamp(color.r - 0.001f, 0, 1);
            color.g = Mathf.Clamp(color.g - 0.001f, 0, 1);
            color.b = Mathf.Clamp(color.b - 0.001f, 0, 1);
            sr.color = color;
        }

        if (Input.GetKey(KeyCode.P))
        {
            Color color = sr.color;

            color.r = Mathf.Clamp(color.r + 0.001f, 0, 1);
            color.g = Mathf.Clamp(color.g + 0.001f, 0, 1);
            color.b = Mathf.Clamp(color.b + 0.001f, 0, 1);
            sr.color = color;
        }
    }

}
