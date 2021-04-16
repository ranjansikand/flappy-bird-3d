using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
	public Text high_text;
	int highscore;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("hi");

        high_text.text = "High Score: " + highscore.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown("enter") || (Input.GetKeyDown("return")) || (Input.GetKeyDown("space"))) {
        	GetComponent<AudioSource>().Play();
        	Invoke("NextScene", 1);
        }
    }

    void NextScene() {
    	SceneManager.LoadScene("Play");
    }
}
