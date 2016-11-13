using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public BoxCollider2D attackArea;
    private GameObject[] targets = new GameObject[5];
    public bool canAttack = true;
    public int attackPower;

    // Use this for initialization
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) == true && canAttack) {
            foreach(GameObject entity in targets) {
                if (entity != null) {
                    entity.GetComponent<Enemy>().health -= attackPower;
					StartCoroutine(attackCooldown());
					if (entity.GetComponent<Enemy>().health > 0) {
						StartCoroutine (color (entity));
					}
                }
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col) {
        // Detects the hitBox in Enemy.cs
        if (col.gameObject.tag == "Enemy" && col.Equals(col.gameObject.GetComponent<Enemy>().hitBox)) {
            for(int i = 0; i < targets.Length; i++) {
                if (targets[i] == null) {
                    targets[i] = col.gameObject;
                    return;
                }
                else if (targets[i].Equals(col.gameObject))
                {
                    return;
                }
            }
        }
    }

    void OnTriggerExit2D (Collider2D col) {
        // Detects the hitBox in Enemy.cs
        if(col.gameObject.tag == "Enemy" && col.Equals(col.gameObject.GetComponent<Enemy>().hitBox)) {
            for(int i = 0; i < targets.Length; i++) {
                if(targets[i].Equals(col.gameObject)) {
                    targets[i] = null;
                    return;
                }
            }
        }
    }
	IEnumerator color(GameObject obj){
		obj.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		obj.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.3f);
	}
    IEnumerator attackCooldown() {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}
