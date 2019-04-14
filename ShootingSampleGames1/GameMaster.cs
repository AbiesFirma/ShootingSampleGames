using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public float startCountDown = 3.0f;
    public bool ready { get; private set; }

    public int totalPoint { get; private set; }
    public float time = 30.0f;

    public bool gameClear { get; private set; }
    public bool gameOver { get; private set; }

    public bool stopGame { get; private set; }

    AudioSource audioSouce;
    [SerializeField] AudioClip[] audioClip;  //0:countDown321, 1:countDown0, 2:clear
    int soundCount = 3;

void Start()
    {
        totalPoint = 0;
        ready = true;
        gameClear = false;
        gameOver = false;

        stopGame = false;

        audioSouce = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (gameOver || gameClear)
        {
            stopGame = true;
        }

           

        if (ready)
        {
            startCountDown -= Time.deltaTime;

            if(startCountDown < 3.5 && soundCount == 3)
            {
                audioSouce.PlayOneShot(audioClip[0]);
                --soundCount;
            }
            else if (startCountDown < 2.5 && soundCount == 2)
            {
                audioSouce.PlayOneShot(audioClip[0]);
                --soundCount;
            }
            else if (startCountDown < 1.5 && soundCount == 1)
            {
                audioSouce.PlayOneShot(audioClip[0]);
                --soundCount;
            }
            else if (startCountDown < 0.5 && soundCount == 0)
            {
                audioSouce.PlayOneShot(audioClip[1]);
                --soundCount;
            }


            if (startCountDown <= 0.0)
            {
                ready = false;
            }
        }
        else if(!gameOver)        
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = 0.0f;
                gameClear = true;
                
                if (soundCount == -1)
                {
                    audioSouce.PlayOneShot(audioClip[2]);
                    --soundCount;
                }
            }
        }
    }

    void EnemyDestroy(int getPoint)
    {
        totalPoint += getPoint;
    }

    void GameOver()
    {
        gameOver = true;
    }
}
