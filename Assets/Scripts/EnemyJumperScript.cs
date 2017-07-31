using UnityEngine;
using System.Collections;

public class EnemyJumperScript : MonoBehaviour {

    Rigidbody2D rb2d;

    public float jumpForce;
    public bool isGrounded;

    float currentTime;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        currentTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

        Jump(jumpForce);
	
	}

    void Jump(float jumpForce)
    {
        if (isGrounded)
        {
            rb2d.velocity = Vector3.up * jumpForce;
        }
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }
}
