using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void startGame()
	{
		Application.LoadLevel ("Level1");
	}
	public void returnToMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
	public void exitGame(){
		Application.Quit();
	}
}
