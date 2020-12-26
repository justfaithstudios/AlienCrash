using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
public class CloudOnceServices : MonoBehaviour
{
    // creates singleton class
    public static CloudOnceServices instance;



    private void Awake()
    {
        testSingleton();
    }


    private void testSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void submitScoreToLeaderBoard(int score)
    {
        Leaderboards.AcScores.SubmitScore(score);
    }
}
