using UnityEngine;

public class Shoot : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Vector2 initialShotVelocity = Vector2.zero;
    [SerializeField] private Transform LeftSpawn;
    [SerializeField] private Transform RightSpawn;
    [SerializeField] private Projectile projectilePrefab = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (initialShotVelocity == Vector2.zero)
        {
            initialShotVelocity = new Vector2(10f, 0f);
            Debug.LogWarning("Initial shot velocity not set. Using default value: " + initialShotVelocity);
        }

        if (LeftSpawn == null || RightSpawn == null || projectilePrefab == null)
        {
            Debug.LogError("Spawn point or projectile prefab not set. Please assign LeftSPawn and RightSpawn in the inspector.");
        }
    }

    public void Fire()
    {
        Projectile curProjectile;
        if (!sr.flipX)
        {
            curProjectile = Instantiate(projectilePrefab, RightSpawn.position, Quaternion.identity);
            curProjectile.SetVelocity(initialShotVelocity);
        }
        else
        {
            curProjectile = Instantiate(projectilePrefab, LeftSpawn.position, Quaternion.identity);
            curProjectile.SetVelocity(new Vector2(-initialShotVelocity.x, initialShotVelocity.y));

        }
    }
}
