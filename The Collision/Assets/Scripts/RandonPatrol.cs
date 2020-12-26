using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RandonPatrol : MonoBehaviour
{

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    // speed for difficulty
    float speed;
    public float minSpeed;
    public float maxSpeed;
    static bool isDead;

    public float secondsToMaxDifficulty;

    Vector2 targetPosition;

   
    void Start()
    {
        targetPosition = getRandomPosition();

        isDead = true;
    }

    
    void Update()
    {

        if (isDead == false)
        {
            return;
        }

        // Destroy(directions);

        if ((Vector2)transform.position != targetPosition)
        {
           speed = Mathf.Lerp(minSpeed, maxSpeed, getDiffuclty());

          transform.position =  Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = getRandomPosition();
        }

    }

    // random position for planets
    Vector2 getRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    

    float getDiffuclty()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Planets")
        {
            isDead = false;
        }
    }

}
