using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRootAutoMoveController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    GameObject gameMaster;
    bool stopGame;

    AudioSource audioSource;
    

    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        stopGame = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!stopGame)
        {
            stopGame = gameMaster.GetComponent<GameMaster>().stopGame;
        }
       
        AutoMove();
    }

    void AutoMove()
    {
        if (stopGame)
        {
            if (speed >= 0.001f)
            {
                speed *= 0.9f;
                audioSource.volume -= 0.01f;
                audioSource.pitch -= 0.01f;
            }
            else
            {
                speed = 0.0f;
                audioSource.volume = 0.0f;
                audioSource.pitch = 0.0f;
            }
        }

        transform.Translate(0.1f * speed, 0, 0);
    }
}
