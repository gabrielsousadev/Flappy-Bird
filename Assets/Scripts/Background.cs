using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        Vector3 scaleTemp = GetComponentInChildren<Transform>().transform.localScale;

        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;

        float heightWorld = Camera.main.orthographicSize * 2.0f; // Altura
        float widhtWorld = heightWorld / Screen.height * Screen.width;

        scaleTemp.x = widhtWorld / width;
        scaleTemp.y = heightWorld / height;

        transform.localScale = scaleTemp;
    }
}
