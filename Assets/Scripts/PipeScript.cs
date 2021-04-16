using UnityEngine;

public class PipeScript : MonoBehaviour
{
	float scrollSpeed;

    void Start()
    {
        scrollSpeed = FindObjectOfType<PipeSpawner>().ShareSpeed();
    }

    void Update()
    {
    	if (transform.position.x < -25) {
    		Destroy(gameObject);
    	} else {
	        transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0);
    	}

    	scrollSpeed = FindObjectOfType<PipeSpawner>().ShareSpeed();
    }
}
