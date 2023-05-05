using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.1f;

    public float height = 50f;

    public float turnRange = 30f;

    void Update()
    {

        Vector3 position = transform.position;

        position.y = height;

        position += transform.forward * (speed / 10f) * Time.deltaTime;

        float angle = Random.Range(-turnRange, turnRange);

        transform.Rotate(0f, angle, 0f);

        transform.position = position;

    }
}