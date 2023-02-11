using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public Transform[] endPostions;
    public Transform startPostion;

    public float spawnTime = 0.5f;
    private float currentTime = 0;

    private int postionIndex;
    private int prefabIndex;

    private void Update()
    {
        if (currentTime + spawnTime < Time.time)
        {
            currentTime = Time.time;
            prefabIndex = Random.Range(0, obstaclePrefab.Length);
            postionIndex = Random.Range(0, endPostions.Length);

            GameObject newOb = Instantiate(obstaclePrefab[prefabIndex], startPostion);
            newOb.GetComponent<MoveDown>().direction = (endPostions[postionIndex].position - startPostion.position).normalized;
        }
    }
}
