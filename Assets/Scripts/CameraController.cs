 using UnityEngine;
 using System.Collections;
 
 public class CameraController : MonoBehaviour {
 
     public float turnSpeed = 4.0f;
     public Transform player;
 
     public Vector3 offset;
     public bool isInverted;
 
     void Start () {
         offset = new Vector3(player.position.x, player.position.y + 2.5f, player.position.z - 6.25f);
     }
 
     void LateUpdate()
     {
         offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
         transform.position = player.position + offset; 
         transform.LookAt(player.position);
     }
 }