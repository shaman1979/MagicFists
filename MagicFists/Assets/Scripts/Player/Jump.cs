using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump
{
    JumpBehavior jump;
    private float forgeJump;
    Rigidbody2D obj;
    public void JumpObj(JumpBehavior j)
    {
        jump = j;
        jump.jump(forgeJump, obj);
    }

    public Jump(float f, Rigidbody2D rg)
    {
        forgeJump = f;
        obj = rg;
    }
}

public interface JumpBehavior
{
    void jump(float forgeJump, Rigidbody2D rbObj);
}

public class JustJump : JumpBehavior
{
    public void jump(float forgeJump, Rigidbody2D rbObj)
    {
       
        rbObj.AddRelativeForce(Vector2.up * forgeJump, ForceMode2D.Impulse);
        
    }

}

public class DoubleJump : JumpBehavior
{
    
    public void jump(float forgeJump, Rigidbody2D rbObj)
    {
        rbObj.velocity = new Vector2(rbObj.velocity.x, 0);
        rbObj.AddForce(Vector2.up * forgeJump, ForceMode2D.Impulse);
    }

    
}