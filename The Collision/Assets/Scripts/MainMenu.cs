using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{

    public Text highScore;
    public GameObject dPanel;

    public void Start()
    {
        highScore.text = "High Score " + PlayerPrefs.GetFloat("score").ToString("f0");
    }

    public void playGame()
    {
        SceneManager.LoadScene("game");
    }

    public void OpenLinks()
    {
        Application.OpenURL("https://solo.to/imjaewilliams");
    }


    public void quit()
    {
        Application.Quit();
    }



    public void howToPlay()
    {
        dPanel.SetActive(true);
    }

    public void backToMenu()
    {
        dPanel.SetActive(false);
    }

  

}

