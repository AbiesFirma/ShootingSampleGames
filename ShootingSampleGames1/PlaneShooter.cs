using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooter : MonoBehaviour
{
    [SerializeField] GameObject bullet1Prefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootInterval = 0.5f;

    float shootTime;
    bool buttonDown;

    void Start()
    {
        shootTime = 0.0f;
        buttonDown = false;
    }

    void Update()
    {
        shootTime += Time.deltaTime;

        if(buttonDown)
        {
            PlaneShoot1();
        }
    }

    public void PlaneShoot1()
    {
        if (shootTime >= shootInterval)
        {
            GameObject bullet1 = Instantiate(bullet1Prefab, shootPoint.position, Quaternion.Euler(0, 90, 0));
            shootTime = 0.0f;
        }
    }

    public void rightButtonDown()
    {
        buttonDown = true;
    }
    public void rightButtonUp()
    {
        buttonDown = false;
    }
}
