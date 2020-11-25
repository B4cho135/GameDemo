using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{
    private Vector3 offset = new Vector3(510f, 0f, 0f);
    [SerializeField]
    private GameObject Scene;

    public List<GameObject> Scenes = new List<GameObject>();

    private void Start()
    {
        Scenes.Add(Scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        var lastSpawned = Instantiate(Scene, Scenes[0].transform.position + offset, Scenes[0].transform.rotation);
        Scenes.Add(lastSpawned);

        Debug.Log("Scene was spawned!");

        Debug.Log(Scenes.Count);



    }


}