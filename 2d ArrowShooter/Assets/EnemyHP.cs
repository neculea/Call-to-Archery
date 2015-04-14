using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	[System.Serializable]
	public class EnemyStats {
		public int hp = 50;
	}
	
	public EnemyStats enemyStats = new EnemyStats();
	private AudioSource source;
	public AudioClip hurtSound;
	public Transform deadPrefab;
	private float vol = 0.5f;
	public int fallBoundary = -20;
	
	void Update () {
		
		if (transform.position.y <= fallBoundary)
			DamageEnemy (9999999);
	}
	void Awake () {
		
		source = GetComponent<AudioSource>();
		
	}
	
	public void DamageEnemy (int damage) {
		source.PlayOneShot(hurtSound,vol);
		enemyStats.hp =enemyStats.hp-damage;
		if (enemyStats.hp <= 0) {
			Instantiate (deadPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
	

}
