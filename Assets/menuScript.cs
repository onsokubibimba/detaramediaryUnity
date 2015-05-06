using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void creatediary() {
		Application.LoadLevel ("creatediary");
	}

	public void selectdiary() {
		Application.LoadLevel ("selectdiary");
	}

	public void applicationquit() {
		Application.Quit ();
	}
	

}
