using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePrebs : MonoBehaviour
{
    [SerializeField]
    private Stone stone;

    public Stone GetStone()
    {
        return stone;
    }
}
