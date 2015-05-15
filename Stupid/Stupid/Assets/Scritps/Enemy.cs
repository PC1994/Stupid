using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private int HP = 3;
	private bool fall;
	public GameObject Player;
	public Transform spawnPoint;
	public bool stomp;
	public bool isDead;

	// Update is called once per frame
	void Update () {
		if (stomp) {
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
			stomp = false;
			fall = true;

			gameObject.GetComponent<PlatformMover>().step = 0;
		}

		if (fall) {
			transform.position -= new Vector3(0, 0.2f, 0); 
		}

		if (transform.position.y < -20) {
			Destroy(gameObject);
		}
		
		if (HP == 0) {
			die();
		}
	}
	

	void OnTriggerEnter2D(Collider2D other){
		if(!stomp && !isDead){
			if (other.tag == "Player") {
				Destroy(other.gameObject);
				GameObject p =  Instantiate(Player, spawnPoint.position, Quaternion.identity) as GameObject;

				GameObject Cam = GameObject.Find("Main Camera");
				Cam.GetComponent<SmoothFollow2>().target = p.transform;
				}
		}
	}
	public void Hurt(){
		HP--;
		print ("Hurt now HP: " + HP);
	}
	private void die(){
		Destroy(gameObject);
		isDead = true;
	}
}
