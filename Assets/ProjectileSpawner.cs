using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    public InputActionReference action;

    [Header("Projectile")]
    public GameObject projectilePrefab;
    public Transform controller;
    public float projectileSpeed = 5f;

    [Header("Orbit")]
    public Transform attractor;
    public float gravity = 2f;

    [Header("Feedback")]
    public GameObject shootFeedbackPrefab;

    void Start()
    {
        action.action.Enable();
        action.action.performed += OnSpawn;
    }

    void OnDestroy()
    {
        if (action != null && action.action != null)
        {
            action.action.performed -= OnSpawn;
        }
    }

    void OnSpawn(InputAction.CallbackContext ctx)
    {
        SpawnProjectile();
    }

    void SpawnProjectile()
    {
        Vector3 spawnPosition =
            controller.position + controller.forward * 0.3f;

        GameObject projectile = Instantiate(
            projectilePrefab,
            spawnPosition,
            controller.rotation
        );

        ProjectileMovement movement =
            projectile.GetComponent<ProjectileMovement>();

        if (movement != null)
        {
            movement.InitializeOrbit(
                attractor,
                gravity,
                controller.forward
            );
        }

        if (shootFeedbackPrefab != null)
        {
            GameObject feedbackObject = Instantiate(
                shootFeedbackPrefab,
                spawnPosition,
                Quaternion.identity
            );

            FeedbackGroup feedback =
                feedbackObject.GetComponent<FeedbackGroup>();

            if (feedback != null)
            {
                feedback.PlayFeedback();
            }
        }
    }
}