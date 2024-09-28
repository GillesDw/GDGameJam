using System.Collections;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundEnemy : MonoBehaviour
{
    [Header("Enemy")]
    [Header("Moving")]
    [SerializeField] private float _moveSpeed = 3f;
    [Header("Attack")]
    [SerializeField] private float _maxRaycastDistance = 100f;
    [SerializeField] private float _attackRange = 6f;
    [SerializeField] private LayerMask _targetLayerMask;
    [Header("Audio")]
    //[SerializeField] private Animator animator;

    [SerializeField] Transform player;

    private Coroutine _shootingCoroutine;
    private bool _isChargingShot;

    private float time;
    private float delay = 2f;
    private Vector3 startPos;
    private Vector3 playerLocation;



    // PRIVATE
    void Start()
    {
        startPos = transform.position;
        playerLocation = startPos;
    }

    void Update()
    {
        LookAtTarget();

        DetectTarget();
    }


    private void LookAtTarget()
    {
        Vector3 target = player.transform.position;
        target.y = 0;
        transform.LookAt(target);
    }

    private void DetectTarget()
    {  
        RaycastHit hit;
        Vector3 rayPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z); ;
        Debug.DrawRay(rayPos, transform.forward, UnityEngine.Color.red);
        if (Physics.Raycast(rayPos, transform.forward, out hit, _maxRaycastDistance, _targetLayerMask))
        {
            if (hit.collider != null)
            {
                // Target in range
                if (Vector3.Distance(rayPos, hit.collider.transform.position) <= _attackRange)
                {
                    if (time >= delay)
                    {
                        Shoot();
                        time = 0;
                    }    
                }
                // Target not in range
                else
                {
  
                        MoveToTarget();
                   
                }
            }
        }

        time += Time.deltaTime;
    }

    private void Shoot()
    {
        //animator.SetTrigger("Attack");
        

        Invoke(nameof(EndShoot), 1.25f);
    }

    private void EndShoot()
    {
        time = 0;
    }

    private void MoveToTarget()
    {
        Vector3 toTarget = playerLocation - transform.position;

        if(PlayerMovementTutorial.IsHiding == true | (player.transform.position - transform.position).magnitude > 50)
        {
            playerLocation = startPos;
        }
        else
        {
            playerLocation = player.transform.position;
        }
        Debug.Log((player.transform.position - transform.position).magnitude);

        Debug.Log(toTarget.magnitude);
        transform.position += _moveSpeed * Time.deltaTime * toTarget.normalized;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _maxRaycastDistance);
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
