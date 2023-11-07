using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
	private bool isDragging;
	private bool onPlatform = false;
	private Transform parentContainer;
	private Collider2D colliderAction;
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private GameObject waypoint;

	private void Start()
	{
		colliderAction = GetComponent<Collider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (transform.parent.gameObject != null)
		{
			parentContainer = transform.parent.gameObject.transform;
		}
	}

	private void OnMouseDown()
	{
		if (!onPlatform)
		{
			isDragging = true;
			colliderAction.isTrigger = true;
			spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
		}
	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1))
		{
			ReturnAction();
		}
	}

	private void OnMouseUp()
	{
		var origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, Mathf.Infinity, 7);
		origin.x += 3;
		RaycastHit2D hitRight = Physics2D.Raycast(origin , Vector2.zero, Mathf.Infinity, 7);
		origin.x -= 6;
		RaycastHit2D hitleft = Physics2D.Raycast(origin, Vector2.zero, Mathf.Infinity, 7);

		var origin2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		RaycastHit2D hitShort = Physics2D.Raycast(origin2, Vector2.zero, Mathf.Infinity, 7);
		origin2.x += 1;
		RaycastHit2D hitRightShort = Physics2D.Raycast(origin2, Vector2.zero, Mathf.Infinity, 7);
		origin2.x -= 2;
		RaycastHit2D hitleftShort = Physics2D.Raycast(origin2, Vector2.zero, Mathf.Infinity, 7);

		if (transform.gameObject.name == "Space Jump")
		{
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.CompareTag("NoAction") )
				{
					ReturnAction();
				}
			}
			if (hitRight.collider != null )
			{
				if (hitRight.collider.gameObject.CompareTag("NoAction") )
				{
					ReturnAction();
				}
			}
			if ( hitleft.collider != null)
			{
				if (hitleft.collider.gameObject.CompareTag("NoAction"))
				{
					ReturnAction();
				}
			}
		}
		else
		{
			if (hitShort.collider != null)
			{
				if (hitShort.collider.gameObject.CompareTag("NoAction"))
				{
					ReturnAction();
				}
			}
			if (hitRightShort.collider != null)
			{
				if (hitRightShort.collider.gameObject.CompareTag("NoAction"))
				{
					ReturnAction();
				}
			}
			if (hitleftShort.collider != null)
			{
				if (hitleftShort.collider.gameObject.CompareTag("NoAction"))
				{
					ReturnAction();
				}
			}

		}
		
		
		if (!onPlatform)
		{
			isDragging = false;
			colliderAction.isTrigger = false;
			spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
		}

		waypoint.SetActive(true);

	}

	private void Update()
	{
		if (isDragging && !onPlatform)
		{
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			transform.Translate(mousePosition);
			transform.SetParent(null);
		}



		if (Input.GetKey(KeyCode.LeftShift))
		{
			ReturnAction();
		}
	}
	private void ReturnAction()
	{
		transform.SetParent(parentContainer);
		transform.position = waypoint.transform.position;
		waypoint.SetActive(false);

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			onPlatform = true;
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			onPlatform = false;
		}
	}



}
