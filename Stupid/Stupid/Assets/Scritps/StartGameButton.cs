using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour {

	public Button startButtonObj;

	// Use this for initialization
	void Start () {
		startButtonObj.onClick.AddListener (gotoStageFnc);
	}
	
	void gotoStageFnc(){
		Application.LoadLevel("level01");
	}

	// Update is called once per frame
	void Update () {

	}

}
