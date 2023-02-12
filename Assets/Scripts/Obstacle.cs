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
            Vector3 Scale;
            //Debug.Log(percentage);

            for (int i = 0; i < obstaclePrefab.Length; i++)
            {
                if (percentages[i] >= percentage)
                {
                    prefabIndex = i;
                    break;
                }
            }

            if (obstaclePrefab[prefabIndex].CompareTag("LightHouse"))
            {
                postionIndex = 1;
                Scale = new Vector3(-1, 1, 1);
            }
            else
            {
                postionIndex = Random.Range(0, endPostions.Length);
                Scale = obstaclePrefab[prefabIndex].transform.localScale;
            }

            GameObject newOb = Instantiate(obstaclePrefab[prefabIndex], startPostion);
            newOb.transform.localScale = Scale;
            newOb.GetComponent<MoveDown>().direction = (endPostions[postionIndex].position - startPostion.position).normalized;
            newOb.GetComponent<MoveDown>().speed = speed;
        }
    }
}
