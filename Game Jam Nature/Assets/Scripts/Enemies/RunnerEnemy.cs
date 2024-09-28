using System.Collections;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

public class RunningEnemy : MonoBehaviour
{
    [Header("Enemy")]
    [Header("Moving")]
    [SerializeField] private float _moveSpeed = 3f;
    [Header("Attack")]
    [SerializeField] private float _maxRaycastDistance = 100f;
    [SerializeField] private float _attackRange = 6f;
    [SerializeField] private LayerMask _targetLayerMask;
    //[SerializeField] private Animator animator;

    [SerializeField] private Transform player;

    private Coroutine _shootingCoroutine;
    private bool _isChargingShot;

    private float time;
    private float delay = 2f;
    private Vector3 startPos;
    private Vector3 playerLocation;

    void Start()
    {
        // Set the start position to where the enemy starts
        startPos = transform.position;
        playerLocation = startPos;  // Initialize playerLocation to the start position
    }

    void Update()
    {
        LookAtTarget();   // Rotate the enemy to face the player
        DetectTarget();   // Detect the player and decide whether to attack or move
    }

    private void LookAtTarget()
    {
        // Ensure the enemy looks towards the player, but ignore y-axis for horizontal rotation
        Vector3 target = player.transform.position;
        target.y = 0;  // Neutralize vertical rotation
        transform.LookAt(target);
    }

    private void DetectTarget()
    {
        // Raycast to detect if the player is within line of sight and in range
        RaycastHit hit;
        Vector3 rayPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Debug.DrawRay(rayPos, transform.forward, UnityEngine.Color.red);

        if (Physics.Raycast(rayPos, transform.forward, out hit, _maxRaycastDistance, _targetLayerMask))
        {
            if (hit.collider != null)
            {
                // Check if the player is within the attack range
                if (Vector3.Distance(rayPos, hit.collider.transform.position) <= _attackRange)
                {
                    if (time >= delay)  // Attack only if enough time has passed since the last attack
                    {
                        Shoot();
                        time = 0;  // Reset time for the next attack
                    }
                }
                else
                {
                    MoveToTarget();  // Move towards the player if not in range
                }
            }
        }

        time += Time.deltaTime;  // Increment time for cooldown calculation
    }

    private void Shoot()
    {
        // Placeholder for attacking (you can trigger an attack animation here)
        //animator.SetTrigger("Attack");

        // Simulate end of attack with a delay
        Invoke(nameof(EndShoot), 1.25f);
    }

    private void EndShoot()
    {
        time = 0;  // Reset time after the attack has finished
    }

    private void MoveToTarget()
    {
        // Calculate direction to move toward the player
        Vector3 toTarget = playerLocation - transform.position;

        // Check if the player is hiding or too far (>50 units)
        if (PlayerMovementTutorial.IsHiding == true || (player.transform.position - transform.position).magnitude > 50)
        {
            playerLocation = startPos;  // Move back to the start position if player is hiding or too far
        }
        else
        {
            playerLocation = player.transform.position;  // Update target to player's current position
        }

        // Debugging: Log distance to the player
        Debug.Log((player.transform.position - transform.position).magnitude);

        // Move toward the target position (player or start position)
        transform.position += _moveSpeed * Time.deltaTime * toTarget.normalized;

        // Keep the enemy grounded (ensure y-axis is always 0)
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the attack range and raycast range in the editor
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _maxRaycastDistance);  // Max detection range
        Gizmos.DrawWireSphere(transform.position, _attackRange);         // Attack range
    }
}
