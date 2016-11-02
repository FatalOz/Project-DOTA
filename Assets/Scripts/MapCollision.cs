using UnityEngine;
using System.Collections;


public class MapCollision: MonoBehaviour {

	public GameObject[] enemies;

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.name == "character") {
			foreach (GameObject enemy in enemies) {
				enemy.GetComponent<Enemy>().setActivate (true);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.name == "character") {
			foreach (GameObject enemy in enemies) {
				enemy.GetComponent<Enemy>().setActivate (false);
			}
		}
	}
}