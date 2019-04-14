using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] bool shooting2D = true;
    [SerializeField] float backDistance3D = 60.0f;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("PlayerRoot");
        }
    }
        
    void Update()
    {
        if (shooting2D)
        {
            Vector3 playerPos = player.transform.position;
            this.transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
        }
        else
        {
            Vector3 playerPos = player.transform.position;
            this.transform.position = new Vector3(playerPos.x - backDistance3D, transform.position.y, transform.position.z);
        }
    }
}
