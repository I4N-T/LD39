using UnityEngine;
using System.Collections;

public class SpriteHide : MonoBehaviour {

    SpriteRenderer sprite;
    

    //public Transform beamStart, beamEnd;

	// Use this for initialization
	void Start () {

        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
	
	}

    void Update()
    {
        //FLASHLIGHT OFF; ENEMIES DISAPPEAR
        if (Input.GetMouseButtonUp(0))
        {
            sprite.enabled = false;
        }
    }

    public void ActivateRenderer()
    {
        sprite.enabled = true;
    }

    public void DeactivateRenderer()
    {
        sprite.enabled = false;
    }
}
