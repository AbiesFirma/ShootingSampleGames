using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] int lifeNumber;
    int currentLife;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    void Update()
    {
        currentLife = player.GetComponent<PlayerState>().life;

        if(currentLife < lifeNumber)
        {
            gameObject.SetActive(false);

        }
    }
}
