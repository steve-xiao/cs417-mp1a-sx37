using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileSpawner : MonoBehaviour
{
    public InputActionReference action;
    public GameObject projectilePrefab;
    public GameObject particlePrefab;
    public GameObject soundPrefab;
    public Transform controller;
    public float projectileSpeed = 5f;

    public Transform attractor;
    public float gravity = 2f;

    void Start()
    {
        action.action.Enable();
        action.action.performed += OnSpawn;
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

        Instantiate(
            particlePrefab,
            spawnPosition,
            Quaternion.identity
        );

        Instantiate(
            soundPrefab,
            spawnPosition,
            Quaternion.identity
        );

        ProjectileMovement movement =
            projectile.GetComponent<ProjectileMovement>();

        movement.InitializeOrbit(
            attractor,
            gravity,
            controller.forward
        );
    }
}