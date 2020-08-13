using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     * Todo:
     * -Buat movement acceleration kalau sudah hold the same button selama 2 detik
     */

    [SerializeField] private Transform center;

    private Rigidbody rb;
    private Collider col;
    private float _speed;
    private float counter;
    private float rad = 0.4f;
    private bool isDead;
    private float timer;
    private bool isMoving;

    private float waitTime = 2f;
    private float speedMult = 5f;
    private float defaultSpeed = 50f;

    public bool IsDead { get => isDead; set => isDead = value; }


    // Awake is called when object instantiated
    void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        IsDead = false;
        isMoving = false;
        _speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            Move();
        }
    }

    private void Move()
    {
#if UNITY_EDITOR

        if (Input.GetAxis("Horizontal") != 0)
        {
            accelerate();
            transform.RotateAround(center.position, new Vector3( 0, 0, Input.GetAxis("Horizontal")), _speed * Time.deltaTime);
        }
        else if (Input.touchCount > 0)
        {
            accelerate();
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                transform.RotateAround(center.position, new Vector3(0, 0, -1), _speed * Time.deltaTime);
                Debug.Log("Left click");
            }
            else if (touch.position.x > Screen.width / 2)
            {
                transform.RotateAround(center.position, new Vector3(0, 0, 1), _speed * Time.deltaTime);
                Debug.Log("Right click");
            }
        }
        else
        {
            deaccelerate();
        }

#elif UNITY_STANDALONE_WIN

        if (Input.GetAxis("Horizontal") != 0)
        {
            accelerate();
            transform.RotateAround(center.position, new Vector3(0, 0, Input.GetAxis("Horizontal")), _speed * Time.deltaTime);
        }
        else
        {
            deaccelerate();
        }

#elif UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            accelerate();
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width/2)
            {
                transform.RotateAround(center.position, new Vector3( 0, 0, -1), _speed * Time.deltaTime);
                Debug.Log ("Left click");
            }
            else if (touch.position.x > Screen.width/2)
            {
                transform.RotateAround(center.position, new Vector3( 0, 0, 1), _speed * Time.deltaTime);
                Debug.Log ("Right click");
            }
        }
        else
        {
            deaccelerate();
        }

#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collide");
            // IsDead = true;
            //Time.timeScale = 0.0f;
        }
    }

    // Accelerate player's rotation speed
    void accelerate()
    {
        if(!isMoving)
        {
            isMoving = true;
            timer = Time.time;
        }
        if(Time.time - timer >= waitTime)
        {
            _speed = _speed * speedMult;
            timer = float.PositiveInfinity;
        }
    }

    // Deaccelerate player's rotation speed
    void deaccelerate()
    {
        isMoving = false;
        _speed = defaultSpeed;
    }

}
