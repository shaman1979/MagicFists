using System.Collections;
using UnityEngine;

public class PlayerWar : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyKill")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyKill")
        {
            Destroy(this.gameObject);
        }
    }
}
