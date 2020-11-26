using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSceneTrigger : MonoBehaviour
{
    //private SpawnEnvironment spawnEnvironment;

    private void OnTriggerEnter()
    {
        var script = GameObject.Find("SpawnSceneTrigger").GetComponent<SpawnEnvironment>();
        script.Destroy();
        Debug.Log("Previous Scene has been Destroyed");

    }
}
