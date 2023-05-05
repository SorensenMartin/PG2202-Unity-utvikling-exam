using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    public float radius = 10.0f; 
    public float altitude = 5.0f; 

    private Vector3 center;
    private float angle; 

    void Start()
    {
        center = transform.position; 
    }

    void Update()
    {
        angle -= speed * Time.deltaTime;
        float x = center.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = center.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        transform.position = new Vector3(x, altitude, z);

        transform.LookAt(center);
    }
}
