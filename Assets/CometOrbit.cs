using UnityEngine;

public class CometOrbit : MonoBehaviour
{
    public Transform attractor;

    public float gravity = 0.2f;

    public Vector3 velocity = new Vector3(0f, 0.15f, 0.35f);

    void Update()
    {
        Vector3 offset = transform.position - attractor.position;

        float distance = offset.magnitude;

        if (distance > 0.001f)
        {
            Vector3 acceleration =
                -gravity * offset / Mathf.Pow(distance, 3);

            velocity += acceleration * Time.deltaTime;

            transform.position += velocity * Time.deltaTime;
        }
    }
}