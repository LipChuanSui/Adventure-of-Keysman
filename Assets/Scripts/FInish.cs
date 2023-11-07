using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInish : MonoBehaviour
{
    private AudioSource finishSoundEffect;
	private bool levelCompleted = false;
    void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "Player" && !levelCompleted)
		{
			finishSoundEffect.Play();
			levelCompleted = true;
			Invoke("CompleteLevel", 2f); //delay 2sec 
			//CompleteLevel();
		}
	}

	private void CompleteLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
