using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    //TEXT/UI
    public Text powerText;

    //PLAYERCONTROLLER REFERENCE
    public PlayerController playerController;

    // Use this for initialization
    void Start () {

        
	
	}
	
	// Update is called once per frame
	void Update () {

        powerText.text = "Power: " + playerController.power + "/100";

	}

    
}
