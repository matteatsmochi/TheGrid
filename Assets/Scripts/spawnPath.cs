using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPath : MonoBehaviour
{
    public GameObject front;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        front.SetActive(true);
    }



}
