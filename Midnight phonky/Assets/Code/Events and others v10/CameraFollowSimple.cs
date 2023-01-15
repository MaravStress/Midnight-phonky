using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{

    public Transform follow;

    public float speed = 1;
    public float speedRotation = 3;


    void Update()
    {
        if (follow != null )
        {
            if(Mathf.Abs(Vector3.Distance(follow.position, transform.position)) > 0.2)
            transform.Translate((follow.position - transform.position) * Time.deltaTime * speed);

             Vector3 e = new Vector3(follow.rotation.x - transform.rotation.x, follow.rotation.y - transform.rotation.y, follow.rotation.z - transform.rotation.z);
             transform.Rotate(e* speedRotation);
        }
       
    }


    public void Follow(Transform i) {
        follow = i;
    }
}
