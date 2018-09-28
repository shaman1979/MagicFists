using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D rbPlayer;
    [SerializeField] public float MoveSpeed;
    [SerializeField] public float JumpForce;
    int move;
    bool isGrounded;
    public int JumpCount;
    public LayerMask Layer;
    void Start () {
        rbPlayer = GetComponent<Rigidbody2D>();
        JumpCount = 0;
	}
	
	void FixedUpdate () {
        rbPlayer.velocity = new Vector2(move*MoveSpeed*Time.deltaTime,rbPlayer.velocity.y);
	}

   void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x,transform.position.y-0.6f), Vector2.down * 0.3f,Color.yellow);
        RaycastHit2D hit2D = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.6f),Vector2.down,0.3f);
      
        //pc
        if (Input.GetKey(KeyCode.A))
        {
            move = -1;
            if (move <= -1 && transform.localScale.x >= 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            move = 1;
            if (move >= 1 && transform.localScale.x <= 0)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            move = 0;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            move = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void MoveDirection(int moveDir)
    {
        move = moveDir;
        if (move <= -1 && transform.localScale.x >=0)
        {
            transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);
        }
      else if (move >= 1 && transform.localScale.x <= 0)
        {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
    public void Jump()
    {
        JumpCount++;
        if (JumpCount ==1)
        {
            rbPlayer.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        else if (JumpCount==2)
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x,0);
            rbPlayer.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
        
    }
   void OnCollisionEnter2D (Collision2D collision)
    {
       if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            JumpCount = 0;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
