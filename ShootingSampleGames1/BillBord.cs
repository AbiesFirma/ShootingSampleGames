using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBord : MonoBehaviour
{
    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

   
    void Update()
    {
        transform.forward = mainCamera.transform.position;

    }
}
