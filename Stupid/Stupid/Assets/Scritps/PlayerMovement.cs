using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	[HideInInspector]
	public bool
		isGrounded = false;
	[HideInInspector]
	public bool
		jump = false;
	public float speed = 10f;
	public float jumpHeight = 8f;
	public float jumpMul = 100;
	public Vector3 move;
	public float maxSpeed = 5f;
	public float moveForce = 10f;	
				
	// Use this for initialization
	void Start ()
	{
	}

	void Update ()
	{
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetKeyDown (KeyCode.W) && isGrounded)
			jump = true;

//		if (Input.touchCount > 0) {
//			if (Input.GetTouch (0).phase == TouchPhase.Began) {
//				jump = true;
//			}
//		}

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		// Cache the horizontal input.
		float h = Input.GetAxis ("Horizontal");

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if (h * GetComponent<Rigidbody2D> ().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * h * moveForce);
		if (Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (Mathf.Sign (GetComponent<Rigidbody2D> ().velocity.x) * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);


		//	move = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);
		//transform.position += move * speed * Time.deltaTime;



		if (jump) {

			// Add a vertical force to the player.
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpHeight * jumpMul));

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			isGrounded = false;
			jump = false;
		}

	}


}
