using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject wall;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    public GameObject skype;
    public GameObject grass;

    private bool isEndGame;

    private int point = 0;
    public Text txtPoint;
    public GameObject panelEndGame;
    public Text endPoint;
    public Text highPoint;
    public Button btnRestart;
    public Text tapToPlay;

    // Start is called before the first frame update
    void Start()
    {
        txtPoint.enabled = false;
        tapToPlay.enabled = true;
        panelEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
    }

    public void StartGame()
    {
        if (Input.GetMouseButton(0))
        {
            if (isEndGame)
            {
                Debug.Log("game is ended");
                //SceneManager.LoadScene(0);
            } else
            {
                txtPoint.enabled = true;
                tapToPlay.enabled = false;
            }
        } 
    }

    public void GetPoint()
    {
        point++;
        txtPoint.text = point.ToString();
    }

    public void EndGame()
    {
        //Time.timeScale = 0;
        isEndGame = true;
        wall.GetComponent<WallMove>().StopWall();
        wall1.GetComponent<WallMove>().StopWall();
        wall2.GetComponent<WallMove>().StopWall();
        wall3.GetComponent<WallMove>().StopWall();
        wall4.GetComponent<WallMove>().StopWall();
        wall5.GetComponent<WallMove>().StopWall();
        skype.GetComponent<BgrMove>().StopBgr();
        grass.GetComponent<BgrMove>().StopBgr();

        // save score
        if (point > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", point);
            PlayerPrefs.Save();
        }

        panelEndGame.SetActive(true);
        endPoint.text = "Your score:" + point.ToString();
        highPoint.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString();
        btnRestart.onClick.AddListener(delegate
        {
            SceneManager.LoadScene(0);
            panelEndGame.SetActive(false);
        });
    }
}
