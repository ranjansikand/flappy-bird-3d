using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public float jump = 150f;
	public float gravity = -10000f;

	public Text score_text;
	public int highscore;
	public bool newhigh = false;
	int score = 0;

	bool playing = true;

	Transform player;
	float fx;
	float fy;
	float fz;

    void Start()
    {
    	highscore = PlayerPrefs.GetInt("hi");
    	score_text.text = "0";
    	player = GetComponent<Transform>();
    }

    void Update() {
    	score_text.text = score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	if (playing) {
	        if (Input.GetKey("space")) {
	        	GetComponent<Rigidbody>().AddForce(0, jump * Time.deltaTime, 0, ForceMode.VelocityChange);
	        }
    	
    	    GetComponent<Rigidbody>().AddForce(0, gravity*Time.deltaTime, 0);
    	} else {
    		player.position = new Vector3(fx, fy, fz);
    	}
    }

    public int StopGame() {
    	playing = false;

    	fx = player.position.x;
    	fy = player.position.y;
    	fz = player.position.z;

    	if (score > highscore) {
    		newhigh = true;
        	highscore = score;
    		PlayerPrefs.SetInt("hi", highscore);
        }

        return highscore;
    }

    public void ResumeGame() {
    	playing = true;
    }

    void OnCollisionEnter(Collision other) {
    	FindObjectOfType<ManagementScript>().GameOver();
    }

    void OnTriggerEnter(Collider other) {
    	score += 1;
    	GetComponent<AudioSource>().Play();
    }
}
