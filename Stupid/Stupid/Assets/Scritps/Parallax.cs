using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private float X;
	public int offset;
	public bool followCamera;

	// Use this for initialization
	void Start () {
		X = Camera.main.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (followCamera) {
			transform.position = new Vector3 ((Camera.main.transform.position.x - X) / offset, transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 ((X - Camera.main.transform.position.x) / offset, transform.position.y, transform.position.z);

		}
		
	}
}
