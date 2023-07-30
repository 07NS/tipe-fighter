using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Vector2 spawnPosL = new Vector2(-8,6);
    [SerializeField] Vector2 spawnPosR = new Vector2(8,6);
    [SerializeField] GameObject enemy;
    [SerializeField] float delay = 5f;
    Vector2 spawnPos;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = SpawnAfterDelay(delay);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnAfterDelay(float d)
    {
        float x = Mathf.Floor(Random.Range(spawnPosL.x, spawnPosR.x));
        float y = Mathf.Floor(Random.Range(spawnPosL.y, spawnPosR.y));
        spawnPos = new Vector2(x, y);
        GameObject en = Instantiate(enemy,spawnPos,Quaternion.identity,transform);
        yield return new WaitForSeconds(d);
        coroutine = SpawnAfterDelay(delay);
        StartCoroutine(coroutine);
    }
}
