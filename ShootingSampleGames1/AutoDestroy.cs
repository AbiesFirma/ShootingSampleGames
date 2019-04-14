using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] bool notDestroy = false;

    float timer = 0.0f;
    bool mouTuskawanai = false;

    void Start()
    {
        if (!notDestroy)
        {
            Destroy(gameObject, lifeTime);
        }
        
    }

    void Update()
    {
        if(notDestroy && !mouTuskawanai)
        {
            timer += Time.deltaTime;
            if(timer >= lifeTime)
            {
                gameObject.SetActive(false);
                timer = 0.0f;
                mouTuskawanai = true;
            }
        }
    }
}
