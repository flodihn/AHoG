using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Debug.log();


public class BugInfo : MonoBehaviour {

	public void prefInfo(){
		string armor = PlayerPrefs.GetInt("armor").ToString();
		string life = PlayerPrefs.GetInt("life").ToString();
		string currency = PlayerPrefs.GetInt("currency").ToString();
		string info = "Armor: " + armor + " " +  "Life: " + life + " " + "Gold: " + currency;
		Debug.Log(info);



	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
