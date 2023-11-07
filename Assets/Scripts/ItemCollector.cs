using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
	private int bananas = 0;

	[SerializeField] private Text bananaText;
	[SerializeField] private AudioSource collectSoundEffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Banana"))
		{
			Destroy(collision.gameObject);
			bananas++;
			bananaText.text = "Banana :" + bananas;
			collectSoundEffect.Play();
		}
	}


}
