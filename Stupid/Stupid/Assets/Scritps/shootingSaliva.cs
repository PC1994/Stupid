using UnityEngine;
using System.Collections;

public class shootingSaliva : MonoBehaviour {
	public float speed = 400f ;


	// Use this for initialization
	void Start () {
		// Destroy the rocket after 5 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 5);
	}
	void FixedUpdate (){

	}
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<Rigidbody2D>().velocity.y == 0) {
			disappear();
		}
	}
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if (col.tag == "Enemy") {
			// ... find the Enemy script and call the Hurt function.
//			col.gameObject.GetComponent<Enemy>().Hurt();
			print ("Ememy");
			// Call the explosion instantiation.
//			OnExplode();
			col.gameObject.GetComponent<Enemy> ().Hurt ();
			print ("gogogo");
			// Destroy the rocket.
			disappear();
		} else if (col.tag != "Enemy") {
			disappear();
		}
//		// Otherwise if it hits a bomb crate...
//		else if(col.tag == "BombPickup")
//		{
//			// ... find the Bomb script and call the Explode function.
//			col.gameObject.GetComponent<Bomb>().Explode();
//			
//			// Destroy the bomb crate.
//			Destroy (col.transform.root.gameObject);
//			
//			// Destroy the rocket.
//			Destroy (gameObject);
//		}
//		// Otherwise if the player manages to shoot himself...
//		else if(col.gameObject.tag != "Player")
//		{
//			// Instantiate the explosion and destroy the rocket.
//			OnExplode();
//			Destroy (gameObject);
//		}
	}
	private void disappear(){
		Destroy (gameObject);
	}
}
