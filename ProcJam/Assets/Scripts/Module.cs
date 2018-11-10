using System.Collections;
using System.Collections.Generic;
using System.Linq
using UnityEngine;

public class Module : MonoBehaviour
{
	public Object rnd = new Random();
	public List<GameObject> exits;
	public enum type {
		corridor,
		room,
		junction
	}


	void Start ()
	{

	}

	void Update ()
	{

	}

	// given a transform, rotate self so that a random exit
	// aligns with the transform.
	void place(GameObject thatExit) {
		thisExit = exits[Random.range(0, exits.length - 1)];

		//TODO: Rotate and translate this module so thisExit and thatExit line up
	}

	List<GameObject> openExits() {
		// TODO: CHECK SYNTAX HERE!
		return exits.Where(e => e.isOpen? == true).ToList();
	}



}
