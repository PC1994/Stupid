using UnityEngine;
using System.Collections;

public class LevelAdvance : MonoBehaviour {

	public string level;

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if(Input.GetKeyUp("up")){
				Application.LoadLevel(level);
			}
		}
	}

}
