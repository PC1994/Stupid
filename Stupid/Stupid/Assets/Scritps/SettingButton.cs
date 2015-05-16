﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour {

	public Button settingButtonObj;
	
	// Use this for initialization
	void Start () {
		settingButtonObj.onClick.AddListener (gotoSettingSceneFnc);
	}
	
	void gotoSettingSceneFnc(){
		print ("go to setting scene");
//		Application.LoadLevel("level01");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}