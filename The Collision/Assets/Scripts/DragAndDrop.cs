using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class DragAndDrop : MonoBehaviour

{
    bool moveAllowed;
    Collider2D col;
    public GameObject selectionEffect;
    public GameObject explosionEffect;

    private GameOver gm;
    
    static int count;
   

    void Start()
    {

        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameOver>();
        col = GetComponent<Collider2D>();
        Advertisement.Initialize("3676952"); // 3676952 - iOS, 3676953 - android
        CloudOnceServices.instance.submitScoreToLeaderBoard((int)PlayerPrefs.GetFloat("score"));
        
        count++;
    }

    
    void Update()
    {

        // player controls

       if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPositiion = Camera.main.ScreenToWorldPoint(touch.position);


            // begin touch
            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPositiion);
                if(col == touchCollider)
                {
                    Handheld.Vibrate(); // only have active for iOS build of the game
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    moveAllowed = true;
                }

            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPositiion.x, touchPositiion.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planets")
        {

            if(count%3 == 0)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
            }

            CloudOnceServices.instance.submitScoreToLeaderBoard((int)gm.getScore());


            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Handheld.Vibrate(); 
            gm.gameOver();
            Destroy(gameObject);

            if(PlayerPrefs.GetFloat("score") < gm.getScore())
            {
                PlayerPrefs.SetFloat("score", gm.getScore());
                PlayerPrefs.Save();
            }
            
        }
    }
}
