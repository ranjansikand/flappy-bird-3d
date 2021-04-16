using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagementScript : MonoBehaviour
{
    public Text game_over;
    public Text high_score;
    bool gameEnded = false;
    bool paused = false;

    int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            FindObjectOfType<BackSound>().PlaySound();
            Invoke("LastScene", 0.5f);
        }

        if (gameEnded) {
            if ((Input.GetKeyDown("space"))) {
                GetComponent<AudioSource>().Play();
                Invoke("NextScene", 1);
            }
        }

        if (!(gameEnded)) {
            if (Input.GetKeyDown("p")) {
                if (paused) {
                    game_over.text = "";
                    paused = false;
                    // resume game
                    FindObjectOfType<PipeSpawner>().ResumeGame();
                    FindObjectOfType<PlayerMovement>().ResumeGame();
                } else {
                    paused = true;
                    game_over.text = "Paused";
                    // pause game
                    FindObjectOfType<PipeSpawner>().StopGame();
                    FindObjectOfType<PlayerMovement>().StopGame();
                }
            }
        }
    }

    public void GameOver() {
    	game_over.text = "Game Over";
        gameEnded = true;

        FindObjectOfType<PipeSpawner>().StopGame();
        FindObjectOfType<PlayerMovement>().StopGame();

        highscore = FindObjectOfType<PlayerMovement>().highscore;

        //write high score to text;
        Debug.Log("high score is " + highscore);
        if (FindObjectOfType<PlayerMovement>().newhigh) {
            high_score.text = "New High Score!";
            FindObjectOfType<HighScoreSound>().PlaySound();
        } else {
            high_score.text = "High Score: " + highscore.ToString();
        }
    }

    void NextScene() {
        SceneManager.LoadScene("Play");
    }
    void LastScene() {
        SceneManager.LoadScene("Start");
    }
}
