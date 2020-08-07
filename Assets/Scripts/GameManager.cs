using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) Pause();
    }

    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;

        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
        }
    }
}
