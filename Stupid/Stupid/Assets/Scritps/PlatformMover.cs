using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour
{

	private float Xpos, Ypos;
	private bool max;
	public bool Vert;
	public int maxAmount;
	public float step;

	// Use this for initialization
	void Start ()
	{
		Xpos = transform.position.x;
		Ypos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Set the max
		if (Vert) { // Vertcal movement
			if (transform.position.y >= Ypos + maxAmount) {
				max = true;
			} else if (transform.position.y <= Ypos) {
				max = false;
			}
		} else { // Horizontal movement
			if (transform.position.x >= Xpos + maxAmount) {
				max = true;
			} else if (transform.position.x <= Xpos) {
				max = false;
			}
		}

		//Moving the platform
		if (Vert) { //Vertical movement
			if (!max) {
				transform.position += new Vector3 (0, step, 0);
			} else {
				transform.position -= new Vector3 (0, step, 0);
			}
		} else { // Horizontal movement
			if (!max) {
				transform.position += new Vector3 (step, 0, 0);
			} else {
				transform.position -= new Vector3 (step, 0, 0);
			}
		}

	}




}
