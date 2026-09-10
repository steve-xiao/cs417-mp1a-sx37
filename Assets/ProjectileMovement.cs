using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Vector3 velocity;

    private Transform attractor;
    private float gravity;

    public float lifetime = 30f;

    public void InitializeOrbit(
        Transform newAttractor,
        float newGravity,
        Vector3 controllerDirection)
    {
        attractor = newAttractor;
        gravity = newGravity;

        Vector3 radial =
            transform.position - attractor.position;

        float distance = radial.magnitude;
        Vector3 radialDirection = radial.normalized;

        // Keep the component of the controller direction
        // tangent to the orbit.
        Vector3 tangent =
            Vector3.ProjectOnPlane(
                controllerDirection,
                radialDirection
            ).normalized;

        if (tangent.sqrMagnitude < 0.001f)
        {
            tangent =
                Vector3.Cross(
                    radialDirection,
                    Vector3.up
                ).normalized;
        }

        float orbitalSpeed =
            Mathf.Sqrt(gravity / distance);

        velocity = tangent * orbitalSpeed;
    }

    void Update()
    {
        if (attractor != null)
        {
            Vector3 offset =
                transform.position - attractor.position;

            float distance = offset.magnitude;

            if (distance > 0.001f)
            {
                Vector3 acceleration =
                    -gravity * offset /
                    Mathf.Pow(distance, 3f);

                velocity +=
                    acceleration * Time.deltaTime;
            }
        }

        transform.position +=
            velocity * Time.deltaTime;

        lifetime -= Time.deltaTime;

        if (lifetime <= 0f)
            Destroy(gameObject);
    }
}