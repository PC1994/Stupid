using UnityEngine;
using System.Collections;

public class PlayerMovement2D : MonoBehaviour
{
	public int screenWidth = Screen.width;

	public float maxSpeed = 10f;
	public bool facingRight = true;
	Animator anim;
	bool grounded = false;
	public Transform groudnCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 850f;
	bool doubleJump = false;


	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		//Return true or false, did it hit anywhere or did it not hit anywhere.
		grounded = Physics2D.OverlapCircle (groudnCheck.position, groundRadius, whatIsGround);
		if (grounded) {
			ShotJump ();
			doubleJump = false;
		}
		if (!doubleJump)
			ShotJump ();
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

		//if (!grounded)
		//	return;

		float move = Input.GetAxis ("Horizontal");

		if(move==0)
			move = Input.acceleration.x*2;

		anim.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		;

		if ((move < 0 || Input.acceleration.x < 0 )&& facingRight) 
			Flip ();
		else if ((move > 0 || Input.acceleration.x > 0 ) && !facingRight)
			Flip ();
	}

	void jumpFnc(){
		anim.SetBool ("Ground", false);
		JumpAnim ();
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
		
		if (!doubleJump && !grounded)
			JumpAnim ();
		doubleJump = true;		
	}

	void Update ()
	{
		if ((grounded || !doubleJump) && Input.GetButtonDown ("Jump")) {
			jumpFnc();
		}
		if((grounded || !doubleJump) && Input.touchCount > 0){
			for (int i=0;i<=Input.touchCount;i++){
				if((Input.GetTouch (i).phase == TouchPhase.Began) && (Input.GetTouch(i).position.x<=screenWidth/2)){
					jumpFnc();
					break;
				}
			}
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "platform") {
			this.transform.parent = other.transform.parent;
		}
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "platform") {
			this.transform.parent = null;
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void ShootAnim ()
	{
		anim.SetTrigger ("Shoot");
	}

	public void StopShoot ()
	{
		anim.SetTrigger ("StopShoot");
	}

	public void JumpAnim ()
	{
		anim.SetTrigger ("Jump");
	}
	
	public void ShotJump ()
	{
		anim.SetTrigger ("StopJump");
	}
}
