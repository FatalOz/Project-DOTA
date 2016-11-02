using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private Animator c_anim;
    private SpriteRenderer c_sprite;
    private CircleCollider2D attackArea;
    // Use this for initialization
    void Start()
    {
        c_anim = GetComponent<Animator>();
        c_sprite = GetComponent<SpriteRenderer>();
        attackArea = GetComponentInChildren<CircleCollider2D>();
    }
   
    // Update is called once per frame
    void Update()
    {
        Vector2 directionRight = new Vector2(1, 0);
        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            RaycastHit2D[] results = new RaycastHit2D[3];
            c_anim.SetBool("attacking", true);
            if (attackArea.Cast(directionRight, results, 0, false) > 0)
            {
                foreach (RaycastHit2D enemy in results)
                {
                    print("HIT");
                    Enemy hitEnemy = enemy.collider.GetComponent<Enemy>();
                    SpriteRenderer e_sprite = enemy.collider.GetComponent<SpriteRenderer>();
                    hitEnemy.health -= 1;
                    e_sprite.color = Color.red;
                    WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1f);
                    e_sprite.color = Color.white;
                }
            }
        }
        else c_anim.SetBool("attacking", false);
    }
}
