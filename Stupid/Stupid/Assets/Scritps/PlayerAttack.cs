using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerAttack : MonoBehaviour
{
	public int screenWidth = Screen.width;
	public Rigidbody2D shot;
	public Transform shotSpawn;
	public float speed = 20;		
	private PlayerMovement2D playerCtrl;		// Reference to the PlayerControl script.


	void Awake()
	{
		// Setting up the references.
		playerCtrl = transform.root.GetComponent<PlayerMovement2D>();
	}

	void shootSalivaFnc()
	{
		GetComponent<AudioSource>().Play ();
		playerCtrl.ShootAnim();
		
		if(playerCtrl.facingRight)
		{
			
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			Rigidbody2D bulletInstance = Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(speed, 0);
		}
		else
		{
			// Otherwise instantiate the rocket facing left and set it's velocity to the left.
			Rigidbody2D bulletInstance = Instantiate(shot, shotSpawn.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
			bulletInstance.velocity = new Vector2(-speed, 0);
			
		}
		
		playerCtrl.StopShoot();
	}
	

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F))
		{
			shootSalivaFnc();
		}
		if(Input.touchCount > 0){
			for (int i=0;i<=Input.touchCount;i++){
				if((Input.GetTouch (i).phase == TouchPhase.Began) && (Input.GetTouch(i).position.x>=screenWidth/2)){
					shootSalivaFnc();
					break;
				}
			}
		}
	}
	
	void FixedUpdate ()
	{
	}
}