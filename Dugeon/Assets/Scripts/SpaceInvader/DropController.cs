using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public GameObject virus;
    public Vector3 spawnValues;
    public int virusCount;
    public float startWait;
    public float spawnWait;
    public float waveWait; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves()); 
    }

    // Update is called once per frame
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < virusCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(virus, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); 
            }
            yield return new WaitForSeconds(waveWait); 
        }
    }
}
