using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAction : MonoBehaviour
{
	[SerializeField]
	private GameObject actionBox;
	[SerializeField]
	private GameObject parentContainer;

	private void OnMouseDown()
	{
		actionBox.transform.SetParent(parentContainer.transform);
		actionBox.transform.position = transform.position;
		gameObject.SetActive(false);
	}
}
