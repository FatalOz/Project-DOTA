using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
		
	public int health = 10;
	public bool damagebreak;

	void Start()
	{
		damagebreak = false; 
	}	
	void Update() {
		if (health == 0) {
			Destroy (gameObject);
			Debug.Log ("Game Over.....");
		}
		if(damagebreak == true){
			Debug.Log ("taking damage");
			StartCoroutine ("color");
		}
		else
		{
			GetComponent<SpriteRenderer>().color = Color.white; 
		}
	}

	IEnumerator color(){
		GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.3f);
		damagebreak = false; 
	}
}
