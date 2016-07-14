using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

	public Text levelText;

	public int maxLevel;

	public string key;

	public void AddLevel(){
		int level = PlayerPrefs.GetInt (key);
		int gold = PlayerPrefs.GetInt ("currency");

		if (gold > 0 && level < maxLevel) {
			level++;
			gold--;
		}
			
		if (level > maxLevel) {
			level = maxLevel;
		}
			
		PlayerPrefs.SetInt (key, level);
		PlayerPrefs.SetInt ("currency", gold);

		string testString = level.ToString() + " / " + maxLevel.ToString();	
		levelText.text = testString;
	}

	public void updateLevel(){
		int level = PlayerPrefs.GetInt (key);

		string gold = level.ToString() + " / " + maxLevel.ToString();

		levelText.text = gold;
	}
		
	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey (key)) {
			PlayerPrefs.SetInt (key, 0);
		}

		int level = PlayerPrefs.GetInt (key);

		string testString = level.ToString() + " / " + maxLevel.ToString();	
		levelText.text = testString;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
