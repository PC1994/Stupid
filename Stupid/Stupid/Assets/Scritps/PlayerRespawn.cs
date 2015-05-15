using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	public GameObject player;
	public Transform spawnPoint;


	void OnTriggerEnter2D(Collider2D other) {

		Destroy(other.gameObject);
		if (other.tag == "Player") {
			GameObject p = Instantiate (player, spawnPoint.position, Quaternion.identity) as GameObject;
			GameObject Cam = GameObject.Find("Main Camera");
			Cam.GetComponent<SmoothFollow2>().target = p.transform;

		}

	}
}
