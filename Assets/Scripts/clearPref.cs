using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clearPref : MonoBehaviour {


	public void clearPrefs(){
		PlayerPrefs.DeleteAll();
	}

	public void clearGold(){
		PlayerPrefs.DeleteKey ("currency");	
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
