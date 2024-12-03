using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   // [SerializeField] private float spawnRate = 6.0f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawner());
        Debug.Log(Random.Range(2f, 4f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawner()
    {
        float spawnRate = Random.Range(1f, 3f);

        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefabs.Length);
                
            Instantiate(enemyPrefabs[rand], transform.position , Quaternion.identity);
        }
    }
}
