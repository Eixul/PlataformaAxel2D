using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField] GameObject objectPreFab;
    [SerializeField] float spawnRate = 1;
    [SerializeField] int numberOfObjectsToSpawn = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

        /*StopCoroutine(spawn());

        StopAllCoroutine()*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Instantiate(objectPreFab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
