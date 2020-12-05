using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrct : MonoBehaviour
{
    public GameObject DestroyedVersion;

    void OnCollisionEnter(Collision CollisionInfo)
    {
        if (CollisionInfo.collider.name ==  "Car")
        {
            var destroyableBox = Instantiate(DestroyedVersion, transform.position + new Vector3(0f,0.5f,1f), transform.rotation);

            destroyableBox.name = "DestroyedBox";


            Destroy(gameObject);

            Object.Destroy(GameObject.Find("DestroyedBox"), 2.0f);

        }
    }
}
