using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {
	public AudioClip[] jumpClip;

	AudioSource jump;

	// Use this for initialization
	void Start () {
		jump = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Jump")){
			if (!jump.isPlaying) {
				int jumpAudio = Random.Range(0, 3);
				jump.clip = jumpClip[jumpAudio];
				jump.Play();
			}
		}
	}

}

		

		
	
