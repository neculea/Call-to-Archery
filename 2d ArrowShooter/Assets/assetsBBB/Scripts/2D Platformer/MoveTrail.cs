using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {
	
	public int moveSpeed = 230;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		Destroy (gameObject, 1);
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy") {
			if(col.gameObject.tag=="Enemy")
			{
				EnemyHP enemy = col.collider.GetComponent<EnemyHP>();
				if(enemy!=null){
					enemy.DamageEnemy(10);
				}
			}
			Destroy (gameObject);
		}

	}
}
