using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Keyboard : MonoBehaviour {
	public Text gt;
	// Use this for initialization
	void Start () {
		gt = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if(Input.inputString.Equals("\b")){
				print("backspace!");
				if(gt.text.Length != 0){
					gt.text = gt.text.Remove(gt.text.Length - 1);
				}
			} else if (Input.inputString.Equals('\n')){
				print ("newline!");
			} else {
				gt.text = gt.text + Input.inputString;
				string s = gt.text;
				print (s);
			}

		}
	}
	//GetComponent<TextMesh> ().text = Input.inputString;
	/*string text;
		text =Input.inputString;
		GetComponent<TextMesh>().text = text;*/
}
