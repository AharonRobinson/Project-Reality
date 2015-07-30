using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class CycleSpell : MonoBehaviour {

	public List<GameObject> children; 
	public int spellNum;
	public GameObject currentSpell;
	public GameObject myo = null;

	private Pose _lastPose = Pose.Unknown;

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
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
		 
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;  

			if (thalmicMyo.pose == Pose.FingersSpread) {
				thalmicMyo.Vibrate (VibrationType.Medium);
				changeSpell ();
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
				// Change material when wave in, wave out or double tap poses are made.
			}
		}

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

	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}
		
		myo.NotifyUserAction ();
	}
	
}
