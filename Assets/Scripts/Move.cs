using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {
    private Rigidbody2D c_body;
    private Animator c_anim;
    [SerializeField] private float speed = 100f;
    private bool facingRight = true;
	private bool isMovingUp = false;
	private bool isMovingDown = false;
	private bool isMovingLeft = false;
	private bool isMovingRight = false;
    // Use this for initialization
    void Start() {
        c_body = GetComponent<Rigidbody2D>();
        c_anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update() {
        //If ESC is pressed go to main menu
        if (Input.GetKey(KeyCode.Escape) == true)
        {
            SceneManager.LoadScene("Menu");
        }
        int direction = 0; //0 = not moving, 1 = up, 2 = down, 3 = left, 4 = right
		if(Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W) == true){
			c_body.AddForce(new Vector2(0f, speed));
			isMovingUp = true;
		}
		else {isMovingUp = false;}
		if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S) == true) { 
			c_body.AddForce(new Vector2(0f, -speed));
			isMovingDown = true;
		}
		else { isMovingDown = false; }
		if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A) == true) { 
			c_body.AddForce(new Vector2(-speed, 0f)); 
			isMovingLeft = true;
		}
		else { isMovingLeft = false; }
		if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D) == true) { 
			c_body.AddForce(new Vector2(speed, 0f));
			isMovingRight = true;
		}
		else { isMovingRight = false; }
        
        if ( isMovingUp || isMovingDown || isMovingLeft || isMovingRight )
        {
            c_anim.SetBool("moving", true);
        }
        else c_anim.SetBool("moving", false);
        if(c_body.velocity.x > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else if(c_body.velocity.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
