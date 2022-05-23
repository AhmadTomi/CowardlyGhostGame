using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject gameStartPanel;
    public GameObject newHighscore;
    
    public static int poin;
    public TMPro.TextMeshProUGUI poinText;
    public TMPro.TextMeshProUGUI hiText;
    public TMPro.TextMeshProUGUI hiTextGameOver;
    private int Highscore;
    

    public static bool isGameStarted;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        poin = 0;
        Highscore = PlayerPrefs.GetInt("highscore",0);
        hiText.text = Highscore.ToString();
        hiTextGameOver.text = Highscore.ToString();
        newHighscore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive (true);
            if (poin>Highscore)
            {
                PlayerPrefs.SetInt("highscore", poin);
                Highscore = poin;
                hiText.text = Highscore.ToString();
                hiTextGameOver.text = Highscore.ToString();
                newHighscore.SetActive(true);
            }
        }
        if (isGameStarted)
        {
            gameStartPanel.SetActive(false);
        }

        poinText.text = "Poin :" + poin;
    } 
}
