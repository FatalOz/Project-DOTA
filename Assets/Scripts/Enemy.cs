using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int health;
	private bool activate = false;
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 0.1f;
    public bool getActivate() {
		return activate;	
	}
	public void setActivate(bool con) {
		this.activate = con;
	}


	void Start()
    {
    
    }

	void Update() {
		if (health == 0) {
			Destroy (gameObject);
			GameObject[] enemies = gameObject.GetComponentInParent<MapCollision>().enemies;
			int index = 0;
			foreach (GameObject enemy in enemies) {
				if (enemy == gameObject) {
					enemies [index] = null;
					break;
				} else {
					index++;
				}
			}
		}
		if (activate) {
            Vector3 direction = target.position - transform.position;
            direction = direction.normalized;
            //move towards the player
            if (Vector3.Distance(transform.position, target.position) > 1f) 
            {//move if distance from target is greater than 1
                transform.Translate(direction*speed*Time.deltaTime);
            }
        }
	}

	void OnTriggerEnter2D(Collider2D col) {
		while (col.gameObject.name == "character") {
			col.gameObject.GetComponent<Character> ().health -= 1;
			StartCoroutine (wait ());
			Debug.Log ("Pow!");

		}
	}

	IEnumerator wait() {
		yield return new WaitForSecondsRealtime (1f);
	}
}