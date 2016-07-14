using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldText : MonoBehaviour {

	public Text levelText;

	public string key;

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey (key)) {
			PlayerPrefs.SetInt (key, 100);
		}

		int level = PlayerPrefs.GetInt (key);

		string gold = "Gold: " + level.ToString ();

		levelText.text = gold;
	}

	public void updateGold(){
		int level = PlayerPrefs.GetInt (key);

		string gold = "Gold: " + level.ToString ();

		levelText.text = gold;
	}


	public void updateArmor(){
		int level = PlayerPrefs.GetInt ("armor");

		string gold = level.ToString ();

		levelText.text = gold;
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
