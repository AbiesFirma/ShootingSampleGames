using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScreenButtonController : MonoBehaviour
{
    bool push; 

    void Start()
    {
        push = false;
    }

    void Update()
    {
        if (push)
        {
            Action();
        }
    }

    public void RightButtonUp()
    {
        push = false;
    }

    public void RightButtonDown()
    {
        push = true;
    }

    void Action()
    {
        //押している間の処理
        Debug.Log("pushing");
    }
}
