using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public PlayerController player;

    private Rigidbody rb;
    private float _speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -9.2f) Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = new Vector3(0, 0, -1.0f);
        if(!player.IsDead)
            rb.MovePosition(transform.position +  dir * Time.deltaTime *_speed);
    }
}
