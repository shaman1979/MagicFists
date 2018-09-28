using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform Player;
    [SerializeField] public float speed;
    private void FixedUpdate()
    {
        if(Player!=null)
        transform.position = Vector3.Lerp(transform.position,new Vector3(Player.position.x,Player.position.y,transform.position.z),speed*Time.deltaTime);    
    }

}
