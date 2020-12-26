using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverPanel;
    public Text scoreText;
    float score;
    bool isDead;
    

    private void Update()
    {
        if(isDead == false)
        {
            score = Time.timeSinceLevelLoad;
            scoreText.text = score.ToString("f0");

           
        }
        
    }

    public void gameOver()
    {
        isDead = true;
        Invoke("delay", .75f);
    }

    public void delay()
    {
        gameOverPanel.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene("game");
    }

    public void toMainMenu()
    {

    
        SceneManager.LoadScene("menu");
    }

    public float getScore()
    {
        return score;
    }

}




