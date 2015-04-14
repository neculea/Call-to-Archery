using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[System.Serializable]
	public class PlayerStats {
		public int Health = 100;
	}

	public PlayerStats playerStats = new PlayerStats();

	private int immune = 1;
	public int fallBoundary = -20;
	private AudioSource source;
	public AudioClip hurtSound;
	private float vol = 0.5f;
	private Material mat;
	private Color[] colors = {Color.yellow, Color.red};
	private Color first;


	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) == true)
		{
			Application.LoadLevel("MainMenu");
		}
		if (transform.position.y <= fallBoundary)
			DamagePlayer (9999999);
	}
	void Awake () {

		source = GetComponent<AudioSource>();
		mat = GetComponent<SpriteRenderer> ().material;
	}
	void OnCollisionEnter2D (Collision2D col){
		if(col.gameObject.tag == "Enemy" && immune == 1){
			Debug.Log ("You were hit");
			immune=0;
			DamagePlayer(1);
			//curHealth = curHealth - 1;
			//SetHealthText ();
		}
	}

	void DamagePlayer (int damage) {
		source.PlayOneShot(hurtSound,vol);

		playerStats.Health -= damage;
		if (playerStats.Health <= 0) {
			Application.LoadLevel("GameOver");
		}
		StartCoroutine(invulnerable(1f, 0.05f));
		//yield return new WaitForSeconds(1);

	}
	IEnumerator invulnerable(float time, float intervalTime)
	{
		float elapsedTime = 0f;
		int index = 0;
		first = mat.color;
		while(elapsedTime < time )
		{
			mat.color = colors[index % 2];
			
			elapsedTime += Time.deltaTime;
			index++;
			yield return new WaitForSeconds(intervalTime);
		}
		immune = 1;
		mat.color = first;
	}

}
