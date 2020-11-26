using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrct : MonoBehaviour
{
    public GameObject DestroyedVersion;
  
    void OnCollisionEnter(Collision CollisionInfo)
    {
        if(CollisionInfo.collider.tag == "breakable_objects")
        {
            Instantiate(DestroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject); 
        }
    }
}

