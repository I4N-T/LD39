using UnityEngine;
using System.Collections;

public class EnemyPatrollerScript : MonoBehaviour {

    Rigidbody2D rb2d;

    public float moveSpeed;
    public float patrolRange;
    float currentTime;
    

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        currentTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {

        Patrol(patrolRange);
        //print("currentTime: " + currentTime);
        //print("Time: " + Time.time);
        //print("difference: " + (Time.time - currentTime));
	
	}

    void Patrol(float patrolRange)
    {
        //move right 
        if (Time.time - currentTime < patrolRange)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            
        }

        else if ((Time.time - currentTime) > patrolRange && (Time.time - currentTime) < (patrolRange * 1.9765f))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        //move left 
        else 
        {
            currentTime = Time.time;
        }

        
    }
}
