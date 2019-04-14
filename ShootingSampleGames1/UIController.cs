using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] Text pointText;
    [SerializeField] Text countDownText;
    [SerializeField] GameObject gameOverObj;
    [SerializeField] GameObject gameClearObj;
    [SerializeField] GameObject retryButtonObj;

    [SerializeField] string title;
    [SerializeField] string shooting2D;
    [SerializeField] string shooting3D;


    float time;
    int point;
    float countdown;

    [SerializeField] GameObject gameMaster;
    bool ready;

    void Start()
    {
        if(timerText == null)
        {
            var timerOb = GameObject.Find("TimeNumber");
            timerText = timerOb.GetComponent<Text>();
        }
        if (pointText == null)
        {
            var pointOb = GameObject.Find("ScoreNumber");
            pointText = pointOb.GetComponent<Text>();
        }
        if (countDownText == null)
        {
            var cdObj = GameObject.Find("CountDownNumber");
            countDownText = cdObj.GetComponent<Text>();
        }

        if (gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        }

        ready = true;
    }

    void Update()
    {
        ready = gameMaster.GetComponent<GameMaster>().ready;
        var gameOver = gameMaster.GetComponent<GameMaster>().gameOver;

        if (ready)
        {
            time = gameMaster.GetComponent<GameMaster>().time;
            timerText.text = string.Format("{0:000.00}", time);

            countdown = gameMaster.GetComponent<GameMaster>().startCountDown;

            if (countdown >= 3.0f)
            {
                countDownText.text = string.Format("{0:0}", 3);
            }
            else if (countdown < 3.0f && countdown > 0.5f)
            {
                countDownText.text = string.Format("{0:0}", countdown);
            }
            else
            {
                var startText = "START";
                countDownText.text = string.Format("{0}", startText);
            }
        }
        else
        {
            time = gameMaster.GetComponent<GameMaster>().time;
            timerText.text = string.Format("{0:000.00}", time);

            point = gameMaster.GetComponent<GameMaster>().totalPoint;
            pointText.text = string.Format("{0:00000}", point);

            if (time <= 0)
            {
                gameClearObj.SetActive(true);
                retryButtonObj.SetActive(true);
            }
        }

        if(gameOver)
        {
            gameOverObj.SetActive(true);
            retryButtonObj.SetActive(true);
        }

        
    }

    public void Retry()
    {
        var activeScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeScene);
    }

    public void Back()
    {
        SceneManager.LoadScene(title);
    }

    public void Shooting2D()
    {
        SceneManager.LoadScene(shooting2D);
    }

    public void Shooting3D()
    {
        SceneManager.LoadScene(shooting3D);
    }

}
