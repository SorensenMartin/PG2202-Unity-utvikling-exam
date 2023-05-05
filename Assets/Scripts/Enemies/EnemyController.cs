using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float radius = 25f;
    public float speed = 5f;

    private Vector3 center;

    void Start()
    {
        center = new Vector3(-40, 40, -60);
    }

    void Update()
    {
        float angle = (Time.time * (speed / 10));
        Vector3 offset = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;
        transform.position = center + offset;

        Vector3 nextPosition = center + new Vector3(Mathf.Sin(angle + Time.deltaTime * (speed / 10)), 0, Mathf.Cos(angle + Time.deltaTime * (speed / 10))) * radius;

        Vector3 direction = nextPosition - transform.position;

        if (direction != Vector3.zero)
        {
    transform.GetChild(0).rotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(0, 180, 0);
        }

        transform.position = nextPosition;

    }
}