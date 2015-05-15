using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	public Transform spawnPoint;
	private Vector2 position;
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			position = new Vector2(transform.position.x, spawnPoint.position.y);
			spawnPoint.position = position;
			Destroy(gameObject);
		}
	}
}
