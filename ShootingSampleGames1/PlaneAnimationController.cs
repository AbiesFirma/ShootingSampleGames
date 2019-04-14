using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAnimationController : MonoBehaviour
{
    [SerializeField] GameObject prop1;
    [SerializeField] GameObject prop2;
    [SerializeField] float prop1Speed = 100.0f;
    [SerializeField] float prop2Speed = 100.0f;

    [SerializeField] float maxPlaneAngle = 30.0f;
    [SerializeField] float animeSpeed = 5.0f;

    float beforePos;
    float currentPos;
    float move;

    Quaternion defAngle;

    [SerializeField] bool shooting2D = true;

    void Start()
    {
        if (shooting2D)
        {
            beforePos = transform.position.y;
            currentPos = transform.position.y;
        }
        else
        {
            beforePos = transform.position.z;
            currentPos = transform.position.z;
        }
        

        defAngle = transform.rotation;
    }

    void Update()
    {
        //プロペラ回転
        prop1.transform.Rotate(prop1Speed * Time.deltaTime, 0, 0);
        prop2.transform.Rotate(prop2Speed * Time.deltaTime, 0, 0);

        //機体回転

        if (shooting2D)
        {
            currentPos = transform.position.y;
            move = currentPos - beforePos;
        }
        else
        {
            currentPos = transform.position.z;
             move = currentPos - beforePos;
        }
        //Debug.Log(moveY);
        
        
        if (move > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(maxPlaneAngle, 0, 0) * defAngle, Time.deltaTime * animeSpeed);
        }
        else if (move < -0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-maxPlaneAngle, 0, 0) * defAngle, Time.deltaTime * animeSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, defAngle, Time.deltaTime * animeSpeed);
        }
        
        
    }

    void LateUpdate()
    {
        beforePos = currentPos;
        
    }
}
