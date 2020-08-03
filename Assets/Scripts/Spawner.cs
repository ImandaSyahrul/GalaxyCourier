﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IArea<BoxCollider>
{
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        InitCollider(boxCollider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pick a random point on collider
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public void InitCollider(BoxCollider col)
    {
        Camera camera = Camera.main;

        if (!camera.orthographic)
        {
            Debug.LogError("Camera isn't orthographic");
            return;
        }

        float aspect = (float)Screen.width / Screen.height;
        float orthoSize = camera.orthographicSize;

        float width = 2.0f * orthoSize * aspect * 2;
        float height = 2.0f * camera.orthographicSize * 2;

        col.size = new Vector3(width, height, 0f);
    }
}
