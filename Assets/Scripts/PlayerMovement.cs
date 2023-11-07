using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anime;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private float dirX = 0f;

    [SerializeField]
    private float moveSpeed = 7f;
    [SerializeField]
    private float jumpForce = 14f;
    [SerializeField]
    private LayerMask jumpableGround;

    private enum MovementState { idle,running,jumping,falling}

    [SerializeField]
    private AudioSource jumpSoundEffect;

    [SerializeField]
    private GameObject[] action;
    //action[0] = jump
    //action[1] = left
    //action[2] = right

    private GameObject leftAction,rightAction, jumpAction;
    private bool isJumpActive, isLeftActive,isRightActive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        leftAction = GameObject.Find("Space Left");
        jumpAction = GameObject.Find("Space Jump");
        rightAction = GameObject.Find("Space Right");


    }

    IEnumerator Flash(GameObject gameObject)
    {
        for (int n = 0; n < 2; n++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);

        }

    }
    // Update is called once per frame
    void Update()
    {
        if (action[0].transform.parent != null)
        {
            isJumpActive = false;
        }
        else
        {
            isJumpActive = true;
        }

        if (action[1].transform.parent != null)
        {
            isLeftActive = false;
        }
        else
        {
            isLeftActive = true;
        }
        if (action[2].transform.parent != null)
        {
            isRightActive = false;
        }
        else
        {
            isRightActive = true;
        }

        dirX = Input.GetAxisRaw("Horizontal");

		if (isLeftActive && dirX <0) 
		{
            dirX = 0;
            StartCoroutine(Flash(leftAction));
        }

        if (isRightActive && dirX > 0)
        {
            dirX = 0;
            StartCoroutine(Flash(rightAction));

        }

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded() && !isJumpActive)
		{
            jumpSoundEffect.Play();
            rb.velocity = new Vector3(0, jumpForce, 0);
		}
		else if(Input.GetButtonDown("Jump") && IsGrounded() && isJumpActive)
		{
            StartCoroutine(Flash(jumpAction));

        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            sprite.flipX = false;

        }

        if(rb.velocity.y > .1f)
		{
            state = MovementState.jumping;
		}
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anime.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
	{   //create box under player to touch ground 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
	}
}
