using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AddGold : MonoBehaviour {


	public void PlusGold(){
		int g = PlayerPrefs.GetInt ("currency");
		g += 50;
		PlayerPrefs.SetInt ("currency", g);
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
