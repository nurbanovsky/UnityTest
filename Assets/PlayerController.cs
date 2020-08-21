using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D body;

	public SpriteRenderer spriteRenderer;
	public Sprite right;
	public Sprite left;
	public Sprite up;
	public Sprite down;

	float horizontal;
	float vertical;
	float moveLimiter = 0.7f;

	public float runSpeed = 20.0f;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw ("Horizontal");
		vertical = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate () {
		if (horizontal != 0 && vertical != 0) {
			horizontal *= moveLimiter;
			vertical *= moveLimiter;

			if (horizontal > 0 && vertical == 0)
				ChangeSprite (right);
			else if (horizontal < 0 && vertical == 0)
				ChangeSprite (left);
		} else {
			ChangeSprite (right);
		}

		body.velocity = new Vector3 (horizontal * runSpeed, vertical * runSpeed, 0.0f);
	}

	void ChangeSprite (Sprite s){
		spriteRenderer.sprite = s;
	}
}
