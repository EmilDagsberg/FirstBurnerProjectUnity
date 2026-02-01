using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZombieFollow : MonoBehaviour
{
    [Header("Target")]
    public string playerTag = "Player";

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;
    public float stopDistance = 1.5f;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("ZombieFollow: No GameObject with tag 'Player' found!");
        }

        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;
        if (distance <= stopDistance) return;

        Vector3 moveDir = direction.normalized;

        // Move zombie
        Vector3 targetVelocity = moveDir * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);

        // Rotate toward player
        Quaternion targetRotation = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.fixedDeltaTime
        );
    }
}

