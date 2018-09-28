using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] public float moveSpeed;
    [SerializeField] public float dirChangeTime;
    Rigidbody2D rbEnemy;
    int dir;

    private void Start()
    {
        dir = 1;
        moveSpeed = Random.Range(80,120);
        dirChangeTime = Random.Range(2, 4);
        rbEnemy = GetComponent<Rigidbody2D>();
        StartCoroutine(dirChange());
       
    }
    private void FixedUpdate()
    {
        rbEnemy.velocity = new Vector2(moveSpeed * Time.deltaTime * dir, rbEnemy.velocity.y);
    }
  
    IEnumerator dirChange()
    {
        while (true)
        {
            dir *= -1;
            transform.localScale = new Vector2(transform.localScale.x* -1,transform.localScale.y);
            yield return new WaitForSeconds(dirChangeTime);
        }
    }
}
