using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ManipulateChildren : MonoBehaviour {

	public List<GameObject> children; 
	public int spellNum;
	public GameObject currentSpell;

	// Use this for initialization
	void Start () {
		children = new List<GameObject> ();
		spellNum = 0;


		GameObject[] ts = GameObject.FindGameObjectsWithTag ("spell"); 
		for (int i = 0; i < ts.Length; i++) {
			Debug.Log("Child: "+ts[i]);
			children.Add(ts[i]);
			ts[i].SetActive(false);

		}

		currentSpell = children [spellNum];
	}


	// Update is called once per frame
	void Update () {
		checkInput ();
	}

	void checkInput(){
		if (Input.GetKeyDown ("w")) {
			changeSpell();
		}
	}

	void changeSpell(){
		Debug.Log("ActiveSpell: "+currentSpell);
		if (spellNum == 0) {
			currentSpell.SetActive (true);
			spellNum++;
		} else if (spellNum == 4) {
			currentSpell.SetActive (false);
			spellNum = 0;
			currentSpell = children [spellNum];
			currentSpell.SetActive (true);
		}else{
			currentSpell.SetActive (false);
			currentSpell = children [spellNum];
			spellNum++;
			currentSpell.SetActive (true);
		}
		Debug.Log("nextSpell: "+currentSpell);
	}
	
}
