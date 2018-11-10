using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	public bool open;
	public GameObject owner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setClosed() {
		open = false;
	}

	void isOpen?() {
		return open;
	}
}
