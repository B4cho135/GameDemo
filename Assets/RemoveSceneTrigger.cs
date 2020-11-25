using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSceneTrigger : MonoBehaviour
{
    //private SpawnEnvironment spawnEnvironment;

    private void OnTriggerEnter()
    {
        var spawnObject = new SpawnEnvironment();
        spawnObject.DestroyObject();
        Debug.Log("Previous Scene has been Destroyed");

    }
}
