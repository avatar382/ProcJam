using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject startRoomPrefab;
	public GameObject roomPrefab;
	public GameObject corridorPrefab;
	public GameObject junctionPrefab;
	public int moduleCount;
	public int moduleLimit;
	public List<GameObject> openExits;


	// Use this for initialization
	void Start () {
		// TODO: Do we need to validate moduleCount to make sure it's not too small or too big?
		openExits = new List<GameObject>;

		GameObject startRoom = Instatiate(startRoomPrefab);
		Module startRoom = GetComponent<Module>();

		openExits = startRoom.openExits();


		// While we  still have modules available, add modules, chaining them together, exit to exit.
		while(moduleCount < moduleLimit) {
			addAnotherModule();
		}

		// TODO: close off exits somehow
	}
	
	// Update is called once per frame
	void Update () {}


	void addAnotherModule() {
		// Get an endpoint (an open exit)
		endpoint = openExits[Random.Range(0, openExits.length)];

		GameObject nextModule = getNextModule(endpoint);
		nextModule.place(endpoint);

		// TODO: CHECK SYNTAX: is this how you merge two lists?
		openExits = openExits.Concat(nextModule.openExits()).ToList();
		moduleCount += 1;
	}

	// Generate a suitable module based on the module it's going to be connected to.
	GameObject getNextModule(GameObject endpoint) {

		switch(endpoint.owner.type) {

			// corridors can link to rooms or junctions
			case type.corridor: {
				if(Random.Range(1, 2) % 2 == 0) {
					GameObject nextModule = Instatiate(roomPrefab);
				}
				else {
					GameObject nextModule = Instatiate(junctionPrefab);
				}
			}

			// rooms can link to corridors
			case type.room: {
				GameObject nextModule = Instatiate(corridorPrefab);
			}

			// junctions can link to corridors or rooms
			case type.junction: {
				if(Random.Range(1, 2) % 2 == 0) {
					GameObject nextModule = Instatiate(corridorPrefab);
				}
				else {
					GameObject nextModule = Instatiate(roomPrefab);
				}
			}

	}
}
