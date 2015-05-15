using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//send the info to the all the way top of the object.
			transform.root.gameObject.GetComponent<Enemy>().stomp = true;
			transform.root.gameObject.GetComponent<Enemy>().isDead = true;
		}
	}
}
