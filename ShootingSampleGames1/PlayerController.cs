using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2DShooting横スクロール、3D奥スクロール、左半分で移動のプレイヤーコントローラー
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    bool onFlick;

    Vector3 startPosSc;
    Vector3 currentPosSc;
    float verticalDir;
    float horizontalDir;

    Touch touch;
    int touchID;


    [SerializeField] float speed = 5.0f;
    [SerializeField] float stopPower = 5.0f;

    [SerializeField] bool shootin2D = true; 


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        onFlick = false;
    }

    void Update()
    {
        int touchCount = Input.touchCount;

        //Debug.Log(onFlick + ";" + touch.position.x + ";" + Screen.width);


        //タッチしている場所（指）が0より多ければ（タッチしていたら）
        if (touchCount > 0)
        {
            //触れているすべての指を判定
            foreach (Touch t in Input.touches)
            {
                //フリック中か否か
                if (!onFlick)
                {
                    //フリック中でない場合画面左半分のみ反応
                    if (t.position.x < Screen.width * 0.5)
                    {
                        touch = t;
                    }
                    else
                    {
                    }
                }
                else
                {
                    //フリック中はfingerIDが同じ（フリックを始めた指である）場合に更新
                    if (t.fingerId == touch.fingerId)
                    {
                        touch = t;
                    }
                    else
                    {
                        //Debug.Log("otherFinger");
                    }
                }

            }

            //フリック中でない場合フリック開始処理
            if (!onFlick)
            {
                //画面左半分に触れたらフリック開始(触れた位置にマーカを表示)
                if (touch.position.x < Screen.width * 0.5 && touch.position.x != 0)   //バグ？で起動初タップで右のボタンに反応して移動してしまうので0のみ除外で回避
                {
                    if (touch.phase == TouchPhase.Began)    //=GetMouseButtonDown
                    {
                        startPosSc = touch.position;
                        touchID = touch.fingerId;
                        onFlick = true;
                    }
                }
            }
            //フリック中はfingerIDが同じときcurrentMarkerの位置を更新移動量計算
            else
            {
                if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && touch.fingerId == touchID)   //=GetMouseButton
                {
                    currentPosSc = touch.position;
                    horizontalDir = currentPosSc.x - startPosSc.x;
                    verticalDir = currentPosSc.y - startPosSc.y;
                }


                //指を離したときマーカー、ラインを消し、フリック中状態を解除、移動量を０に
                if (touch.phase == TouchPhase.Ended && touch.fingerId == touchID)    //GetMouseButtonUp
                {
                    horizontalDir = 0.0f;
                    verticalDir = 0.0f;

                    onFlick = false;
                }
            }
        }
        //タッチしていないときはフリック中状態をオフに
        else
        {
            horizontalDir = 0.0f;
            verticalDir = 0.0f;

            onFlick = false;
        }
    }

    private void FixedUpdate()
    {
        if (shootin2D)
        {
            //２D横スクロール右X,上Y,奥Z
            Vector3 moveDir = new Vector3(horizontalDir, verticalDir, 0);

            rb.AddForce((moveDir * speed * 0.1f) - (rb.velocity * stopPower));
        }
        else
        {
            //3D奥スクロール前X,上Y,左Z
            Vector3 moveDir = new Vector3(0, verticalDir, -horizontalDir);

            rb.AddForce((moveDir * speed * 0.1f) - (rb.velocity * stopPower));
        }
    }

}
