using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private Animator c_anim;
    private SpriteRenderer c_sprite;
    private BoxCollider2D attackArea;
    // Use this for initialization
    void Start()
    {
        c_anim = GetComponent<Animator>();
        attackArea = GetComponentInChildren<BoxCollider2D>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Vector2 directionRight = new Vector2(1, 0);
        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            RaycastHit2D[] results = new RaycastHit2D[3];
            c_anim.SetBool("attacking", true);
			if (attackArea.Cast(directionRight, results, 0, true) > 0 && results[0].collider.gameObject.name == "Skeleton Warrior")
            {
                foreach (RaycastHit2D enemy in results)
                {
                    print("HIT");
                    Enemy hitEnemy = enemy.collider.gameObject.GetComponent<Enemy>();
                    hitEnemy.health -= 1;
					StartCoroutine ("color", enemy.collider.gameObject);
                }
            }
        }
        else c_anim.SetBool("attacking", false);
    }
	IEnumerator color(GameObject obj){
		obj.GetComponent<SpriteRenderer> ().color = Color.red;
		yield return new WaitForSeconds (0.3f);
		obj.GetComponent<SpriteRenderer> ().color = Color.white;
		yield return new WaitForSeconds (0.3f);
	}
}
