using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] bool upDownAnime = true;

    [SerializeField] float udspeed = 1.0f;
    [SerializeField] float returnTime = 1.0f;
    
    float time;
    bool turn;

    [SerializeField] bool forwardMove = true;
    [SerializeField] bool upDownMove = false;
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float upmoveSpeed = 1.0f;

    GameObject gameMaster;
    bool ready;

    void Start()
    {
        turn = true;

        if (gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        }

        ready = true;
    }
    
    void Update()
    {
        if (ready)
        {
            ready = gameMaster.GetComponent<GameMaster>().ready;
        }
        else
        {
            if (upDownAnime)
            {
                time += Time.deltaTime;

                if (time < returnTime && turn)
                {
                    transform.Translate(0, udspeed * Time.deltaTime, 0);
                }
                else if (time < returnTime && !turn)
                {
                    transform.Translate(0, -udspeed * Time.deltaTime, 0);
                }

                if (time >= returnTime)
                {
                    time = 0.0f;
                    if (turn)
                    {
                        turn = false;
                    }
                    else
                    {
                        turn = true;
                    }
                }
            }

            if (forwardMove)
            {
                transform.position = new Vector3(transform.position.x + (-moveSpeed * Time.deltaTime),
                                                 transform.position.y,
                                                 transform.position.z);
            }

            if (upDownMove)
            {
                transform.position = new Vector3(transform.position.x,
                                                 transform.position.y + (upmoveSpeed * Time.deltaTime),
                                                 transform.position.z);
            }

        }
    }
}
