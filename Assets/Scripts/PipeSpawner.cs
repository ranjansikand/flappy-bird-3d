using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
	public GameObject pipe_prefab;
	public GameObject scorepost;

	bool spawn = true;

	int yLocation;

	public int gap_size = 13;
	public float scrollSpeed = 10f;
	float tempSpeed;

	void Start () {
		StartCoroutine(SpawnPipes());
		tempSpeed = scrollSpeed;
	}

	void Update () {

	}

	public float ShareSpeed() {
		return scrollSpeed;
	}

    public void StopGame() {
    	// for game over or pause functions
    	scrollSpeed = 0;
    	spawn = false;
    }

    public void ResumeGame() {
    	// to continue after pause -- game over reloads script
    	scrollSpeed = tempSpeed;
    	spawn = true;
    }

	IEnumerator SpawnPipes() {
		while (spawn) {
			yLocation = Random.Range(-1, 4);

			Instantiate(pipe_prefab, new Vector3(35, yLocation, 1),
				Quaternion.Euler(0f, 0f, 0f));

			Instantiate(scorepost, new Vector3(35, yLocation + 6, 1),
				Quaternion.Euler(0f, 0f, 0f));

			Instantiate(pipe_prefab, new Vector3(35, yLocation + gap_size, 1),
				Quaternion.Euler(0f, 0f, 0f));

			yield return new WaitForSeconds(2);
			// can randomize later
		}
	}
}
