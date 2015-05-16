using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

	public Button exitButtonObj;

	// Use this for initialization
	void Start () {
		exitButtonObj.onClick.AddListener (exitFnc);
	}
	
	void exitFnc(){
		print ("Application quit.");
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
