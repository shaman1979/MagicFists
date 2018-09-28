using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // speed run 
    [SerializeField]
    private float speed = 60f;
    // forge Jump
    [SerializeField]
    private float forgeJump = 120f;

    private moveBH _move;
    private Jump _jump;
    private SpriteRenderer _sprite;
    private GloveManager _gloveManager;
    private GameObject stone;

    public bool IsGround;
    public bool IsJumping;
    private void Start()
    {
        //the connection of the main components
        _sprite = GetComponent<SpriteRenderer>();
        Rigidbody2D _rigibody = GetComponent<Rigidbody2D>();
        _move = new moveBH(speed, transform);
        _jump = new Jump(forgeJump, _rigibody);
        _gloveManager = new GloveManager();
    }

    public void AddStoneToGlove(string namePosition)
    {
        Stone stone = this.stone.GetComponent<StonePrebs>().GetStone();
        Sprite Icon;
        string name;
        stone.display(out name, out Icon);
        
        switch (namePosition)
        {
            case "MainStone":
                _gloveManager.getMainStone(stone);
                GameUI.UIManager.mainStone.UpdateElements(Icon, stone.color);
                break;
            case "SecondaryStone":
                _gloveManager.getSecondaryStone(stone);
                GameUI.UIManager.secondutyStone.UpdateElements(Icon, stone.color);
                break;
            case "AdditionalStone":
                _gloveManager.getaAdditionalStone(stone);
                GameUI.UIManager.additionalStone.UpdateElements(Icon, stone.color);
                break;
        }
        Destroy(this.stone);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _move.Direction(moveBH.TypeState.left, speed);
            _sprite.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _move.Direction(moveBH.TypeState.right, speed);
            _sprite.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            _jump.JumpObj(new JustJump());
        }
    }
    public void Move(Vector2 axis)
    {
        var acceleration = Mathf.Abs(axis.x * 3);

        if (axis.x > 0)
        {
            _move.Direction(moveBH.TypeState.right, speed + acceleration);
            _sprite.flipX = false;
        }
        else if (axis.x < 0)
        {
            _move.Direction(moveBH.TypeState.left, speed + acceleration);
            _sprite.flipX = true;
        }
        if (axis.y > 0.7f && IsGround && !IsJumping)
        {
            _jump.JumpObj(new JustJump());
            IsJumping = true;
        }
        if (axis.y < 0.5f)
            IsJumping = false;



    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            IsGround = true;
        print("IsGround");

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            IsGround = false;
        print("Dont is ground");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            stone = collision.gameObject;
            GameUI.UIManager.ActiveAddStonePanels(true);
        }

        print("Stone");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Stone")
        {
            stone = null;
            GameUI.UIManager.ActiveAddStonePanels(false);
        }

    }
}
