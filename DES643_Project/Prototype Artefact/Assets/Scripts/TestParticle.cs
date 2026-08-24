using UnityEngine;

public class TestParticle : MonoBehaviour
{
    public ElectricFieldManager fieldManager;

    public float charge = 1f;
    public float mass = 1f;

    public Vector3 velocity;

    public float damping = 0.98f;   // slows particle gradually
    public float maxSpeed = 5f;     // limits speed

    public float maxDistance = 15f; // destroy if too far from origin

    void Update()
    {
        if (fieldManager == null) return;

        // 🔷 Get electric field at current position
        Vector3 E = fieldManager.CalculateField(transform.position);

        // 🔷 Compute physics
        Vector3 force = charge * E;
        Vector3 acceleration = force / mass;

        // 🔷 Update velocity
        velocity += acceleration * Time.deltaTime;

        // 🔷 Apply damping (prevents infinite acceleration)
        velocity *= damping;

        // 🔷 Clamp speed
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        // 🔷 Move particle
        transform.position += velocity * Time.deltaTime;

        // 🔷 Destroy if it goes too far (clean behavior)
        if (transform.position.magnitude > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}