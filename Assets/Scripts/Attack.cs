using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private Animator c_anim;
    private SpriteRenderer c_sprite;
    private BoxCollider2D attackArea;
	private GameObject enemy;
    // Use this for initialization
    void Start()
    {
        c_anim = GetComponent<Animator>();
		attackArea = gameObject.GetComponentInChildren<BoxCollider2D>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			enemy = col.gameObject;
			Enemy script = enemy.GetComponent<Enemy>();
			if (Input.GetKeyDown (KeyCode.Space) == true) {
				script.health -= 1;
				StartCoroutine (color(enemy.gameObject));
			}
		}
	}

	void OnTriggerExit(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			enemy = null;
		}
	}

	IEnumerator color(GameObject obj){
		obj.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		obj.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.3f);
	}
}
