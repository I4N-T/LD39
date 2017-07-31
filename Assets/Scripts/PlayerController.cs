using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

    //PLAYER OBJECT COMPONENTS
    Rigidbody2D rb2d;
    BoxCollider2D bc2d;
    LineRenderer lineRend;

    //MOVEMENT STUFF
    public float moveSpeed;
    //public float maxSpeed;
    public float jumpForce;

    bool isGrounded;

    //RAYCAST STUFF
    public Transform beamStart, beamEnd;
    public static bool spotted;

    RaycastHit2D hit;
    SpriteHide enemySpriteHideScript;
    public bool hasBeenHit;

    //MOUSE POSITION STUFF
    float mousex;
    float mousey;
    public static Vector3 mouseposition;

    //PLAYER STATS
    public int power;
    //public int hitPoints;

    

    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        lineRend = GetComponent<LineRenderer>();

        hasBeenHit = false;
        spotted = false;

        power = 100;
        //hitPoints = 3;

       // lineRend.sortingLayerID = 1;
        

    }

	void Update () {

        //RAYCASTING STUFF

        //FLASHLIGHT ON
        if (power > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(PowerDeplete(.75f));
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 vec = mouseposition - beamStart.position;
                Raycasting(vec);
                GetMousePosition();

                //StartCoroutine(PowerDeplete(1f));
            }
        }

        //FLASHLIGHT OFF 
        //DISABLE LINE RENDER
        if (Input.GetMouseButtonUp(0))
        {
            lineRend.SetPosition(0, new Vector3(0, 0, 0));
            lineRend.SetPosition(1, new Vector3(0, 0, 0));
            StopAllCoroutines();
        }

        //script for disabling enemy sprite is found in SprideHide.cs
        

        //INPUTS/CONTROLS
        //LimitSpeed();

        if (Input.GetKey("d"))
        {
            //rb2d.AddForce(Vector3.right * moveSpeed);
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        if (Input.GetKey("a"))
        {
            //rb2d.AddForce(Vector3.left * moveSpeed);
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        if (Input.GetKeyDown("w"))
        {
            if (isGrounded)
            {
                //rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpForce));
                rb2d.velocity = Vector3.up * jumpForce;
            }
        }

    }

    void Raycasting(Vector3 vec)
    {
        //Debug.DrawLine(beamStart.position, beamEnd.position, Color.black);
        Debug.DrawRay(beamStart.position, vec, Color.green);
        

        //LINE RENDER
        lineRend.SetPosition(0, beamStart.position);
        lineRend.SetPosition(1, new Vector3(mouseposition.x, mouseposition.y, 0));

        //ACTUAL RAYCAST
        hit = Physics2D.Raycast(beamStart.position, vec, 15f, 1 << LayerMask.NameToLayer("Enemy"));
        if (hasBeenHit == false)
        {
            if (hit)
            {
                hasBeenHit = true;
                spotted = true;
                enemySpriteHideScript = hit.collider.GetComponent<SpriteHide>();
                enemySpriteHideScript.ActivateRenderer();
            }
        }

        else if (hasBeenHit == true)
        {
            if (hit)
            {
                //hasBeenHit = true;
                spotted = true;
                enemySpriteHideScript = hit.collider.GetComponent<SpriteHide>();
                enemySpriteHideScript.ActivateRenderer();
            }
            else if (!hit)
            {
                enemySpriteHideScript.DeactivateRenderer();

            }
        }


    }

    void GetMousePosition()
    {
        mousex = (Input.mousePosition.x);
        mousey = (Input.mousePosition.y);
        mouseposition = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 0));

    }

    //POWER DEPLETION 
    IEnumerator PowerDeplete(float waitTime)
    {
        while (Input.GetMouseButton(0))
        {
            power--;
            yield return new WaitForSeconds(waitTime);
        }
    }

    //GETTING HURT AND DYING LIKE A LITTLE BITCH
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //WISHLIST
            //play hit sound
            //decrease hitPoints

            //FOR NOW
            //load game over screen/text
            SceneManager.LoadScene(2);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(3);
        }
    }

    /*void LimitSpeed()
    {
        if (rb2d.velocity.magnitude >= maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }*/
}
