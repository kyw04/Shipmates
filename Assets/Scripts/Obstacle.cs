using UnityEngine;
using UnityEngine.UIElements;

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
                int i = Random.Range(0, 2);
                i = i == 0 ? -1 : i;

                Scale = new Vector3(i, 1, 1);
                GameObject newOb2 = Instantiate(obstaclePrefab[prefabIndex], new Vector3(i * 0.75f, startPostion.position.y, 0), Quaternion.identity);
                newOb2.transform.localScale = Scale;
                newOb2.GetComponent<MoveDown>().direction = Vector3.down;
                newOb2.GetComponent<MoveDown>().speed = speed;
                return;
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
