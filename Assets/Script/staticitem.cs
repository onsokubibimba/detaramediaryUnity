using UnityEngine;
using System.Collections;

public class staticitem : MonoBehaviour {

	public static string readhiduke = "";


	public static string gethiduke() {
		return readhiduke;
	}

	public static void sethiduke(string hiduke) {
		readhiduke = hiduke;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
