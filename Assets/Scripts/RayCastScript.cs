using UnityEngine;
using System.Collections;

public class RayCastScript : MonoBehaviour {

    public Transform beamStart, beamEnd;

    public static bool spotted;

    //MOUSE POSITION STUFF
    float mousex;
    float mousey;
    public static Vector3 mouseposition;

    //RAYCAST STUFF
    RaycastHit2D hit;
    SpriteHide enemySpriteHideScript;
    public bool hasBeenHit;

    // Use this for initialization
    void Start()
    {
        hasBeenHit = false;
        spotted = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = mouseposition - beamStart.position;
        Raycasting(vec);
        GetMousePosition();
        
    }

    void Raycasting(Vector3 vec)
    {
         //Debug.DrawLine(beamStart.position, beamEnd.position, Color.black);
         Debug.DrawRay(beamStart.position, vec, Color.green);
         /*spotted = Physics2D.Raycast(beamStart.position, vec, 15f, 1 << LayerMask.NameToLayer("Enemy"));

         if (spotted)
         {
             hit = Physics2D.Raycast(beamStart.position, vec, 15f, 1 << LayerMask.NameToLayer("Enemy"));
             enemySpriteHideScript = hit.collider.GetComponent<SpriteHide>();
             enemySpriteHideScript.ActivateRenderer();
         }*/

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
}
