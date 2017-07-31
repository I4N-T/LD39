using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManagerScript : MonoBehaviour {

    public Button rePlayButton;

    void Awake()
    {
        rePlayButton.onClick.AddListener(Action);
    }

    void Action()
    {
        SceneManager.LoadScene(1);
    }
}
