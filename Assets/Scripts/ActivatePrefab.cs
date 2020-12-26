using System.Collections;
using UnityEngine;

public class ActivatePrefab : MonoBehaviour
{
    private EnemyObjectPool enemyObject;

    void Start()
    {
        enemyObject = GetComponent<EnemyObjectPool>();
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            float timeDelay = Random.Range(2f, 3.5f);
            enemyObject.UnitInstantiate(transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeDelay);
        }
    }
}
