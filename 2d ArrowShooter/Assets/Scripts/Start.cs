using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void startGame()
	{
		Application.LoadLevel ("Level1");
	}
	void exitGame(){
		Application.Quit();
	}
}
