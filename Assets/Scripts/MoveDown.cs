using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed;
    public float scale = 0.25f;
    public Vector3 direction;

    private Vector3 startScale;
    
    private void Start()
    {
        Destroy(gameObject, 5f);
        startScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        speed += Time.deltaTime;

        transform.position += direction * speed * Time.deltaTime;
        transform.localScale += startScale * speed * scale * Time.deltaTime;
    }
}
