using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour {


    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.right, 3);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        if(hit2D.collider.tag == "Player")
        {
            Debug.Log("Killed");
        }

    }

}
