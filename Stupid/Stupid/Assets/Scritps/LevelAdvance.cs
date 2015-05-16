using UnityEngine;
using System.Collections;

public class LevelAdvance : MonoBehaviour {

	public string level;
	private bool isStaying = false;

	void enterDoorFnc(){
		Application.LoadLevel (level);
	}

	void OnGUI() {
		if (isStaying) {
			if (GUI.Button (new Rect (500, 10, 150, 100), "Enter door")) {
				enterDoorFnc ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			isStaying = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			isStaying = false;
		}
	}
	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Player") {
			if (Input.GetKeyUp ("up")) {
				enterDoorFnc();
			}
		} 
	}

}
