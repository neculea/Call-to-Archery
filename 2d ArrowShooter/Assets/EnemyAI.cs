using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

	public Transform target;
	public float updateRate = 2f;
	private Seeker seeker;
	private Rigidbody2D rb;
	public float engage;
	public float jumping;


	// Use this for initialization
	public Path path;
	public float speed = 300f;
	public ForceMode2D fMode;
	private bool m_FacingRight = true;


	[HideInInspector]
	public bool pathIsEnded = false;
	private int currentWaypoint = 0;
	public float nextWaypointDistance = 0;


	void Start(){
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();


		seeker.StartPath (transform.position, target.position, OnPathComplete);
		StartCoroutine (UpdatePath ());
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Jump") {
			rb.AddForce(transform.up*jumping, fMode);
			Debug.Log("Got It");

		}
		
	}
	public void OnPathComplete(Path p)
	{
		//Debug.Log ("Did we have an error" + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	IEnumerator UpdatePath(){
		if (target == null) {
			return false;
		}

		seeker.StartPath (transform.position, target.position, OnPathComplete);
		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine (UpdatePath ());
	}
	void FixedUpdate(){
		if (target == null) {
			return;
		}

		Vector3 chaseDir = target.position - transform.position;
		if (chaseDir.x < 0 && m_FacingRight) {
			Flip ();
		}
		if (chaseDir.x > 0 && !m_FacingRight) {
			Flip ();
		}
		//Debug.Log (chaseDir);
		// rotate to his direction

		if (path == null) {
			return;
		}
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			//Debug.Log ("Path done");
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		if (Vector3.Distance (transform.position, target.position) < engage) {

			rb.AddForce (dir, fMode);
			float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
			if (dist < nextWaypointDistance) {
				currentWaypoint++;
				return;
			}
		}

	}
	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


}
