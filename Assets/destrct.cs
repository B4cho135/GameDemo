using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrct : MonoBehaviour
{
    public GameObject DestroyedVersion;
  
    void OnMouseDown()
    {
        Instantiate(DestroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}
