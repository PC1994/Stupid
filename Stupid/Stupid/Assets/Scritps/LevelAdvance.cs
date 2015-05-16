using UnityEngine;
using System.Collections;

public class LevelAdvance : MonoBehaviour {

	public string level;
	private bool stayDoor = false;

	void enterDoorFnc(){
		Application.LoadLevel (level);
	}

	void OnGUI() {
		if (stayDoor) {
			if (GUI.Button (new Rect (500, 10, 150, 100), "Enter door")) {
				enterDoorFnc ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			stayDoor = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			stayDoor = false;
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
