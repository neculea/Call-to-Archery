using UnityEngine;
using System.Collections;

public class OneWay : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D player)
	{
		transform.parent.GetComponent<Collider2D>().isTrigger = false;
	}
	

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			transform.parent.GetComponent<Collider2D> ().isTrigger = true;
		} 
	}
	
	// Use this for initialization
	void Start () {
		transform.parent.GetComponent<Collider2D>().isTrigger = true;
	}
}
