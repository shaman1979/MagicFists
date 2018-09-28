using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBH 
{
    private float speed;
    private Transform obj;
    public enum TypeState
    {
        left = -1,
        stop = 0,
        right = 1
    }

    

    public moveBH(float s, Transform o)
    {
        speed = s;
        obj = o;
    }

    public void Direction(TypeState changesState , float speed)
    {
        obj.transform.Translate(speed * (int)changesState * Time.deltaTime, 0f, 0f);
    }

}
