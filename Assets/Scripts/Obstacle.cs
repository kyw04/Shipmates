using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float[] percentages;
    public Transform[] endPostions;
    public Transform startPostion;

    public float spawnTime = 0.5f;
    public float speed;
    private float currentTime = 0;

    private int postionIndex;
    private int prefabIndex;
    private int percentage;

    private void Start()
    {
        for (int i = 1; i < obstaclePrefab.Length; i++)
        {
            percentages[i] = percentages[i] + percentages[i - 1];
        }
    }

    private void Update()
    {
        if (currentTime + spawnTime < Time.time)
        {
            currentTime = Time.time;
            percentage = Random.Range(0, 100);
            //Debug.Log(percentage);

            for (int i = 0; i < obstaclePrefab.Length; i++)
            {
                if (percentages[i] >= percentage)
                {
                    prefabIndex = i;
                    break;
                }
            }
            postionIndex = Random.Range(0, endPostions.Length);

            GameObject newOb = Instantiate(obstaclePrefab[prefabIndex], startPostion);
            newOb.GetComponent<MoveDown>().direction = (endPostions[postionIndex].position - startPostion.position).normalized;
            newOb.GetComponent<MoveDown>().speed = speed;
        }
    }
}
