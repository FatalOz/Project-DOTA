using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
		
	public int health = 10;
	public bool damagebreak;
	private BoxCollider2D collisionBox; 
	void Start()
	{
		collisionBox = GetComponent<BoxCollider2D> ();
		damagebreak = false; 
	}	
	void Update() {
		RaycastHit2D[] results = new RaycastHit2D[3];
		if (collisionBox.Cast (new Vector2 (0, 0), results) > 0 && (transform.position.y <= results [0].transform.position.y)) {
			GetComponent<SpriteRenderer> ().sortingOrder = 2; 
		} else {
			GetComponent<SpriteRenderer> ().sortingOrder = 1;
		}
		if (health <= 0) {
			Time.timeScale = 0;
			GameObject.Find ("youded").GetComponent<CanvasGroup>().alpha = 1f;
		}
		if(damagebreak == true){
			StartCoroutine ("color", gameObject);
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.white; 
		}
	}

	IEnumerator color(GameObject obj){
		obj.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		obj.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.3f);
		damagebreak = false; 
	}
}
