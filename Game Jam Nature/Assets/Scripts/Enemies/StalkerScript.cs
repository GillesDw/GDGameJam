using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

public class StalkerScript : MonoBehaviour
{

    [Header("Enemy")]
    [Header("Moving")]
    [SerializeField] private float _moveSpeed = 3f;
    [Header("Attack")]
    [SerializeField] private float _maxRaycastDistance = 100f;
    [SerializeField] private float _attackRange = 6f;
    [SerializeField] private LayerMask _targetLayerMask;
    [Header("Audio")]
    [SerializeField] private Animator animator;

    [SerializeField] Transform player;
    List<Vector3> playerLocations = new();

    public bool HitByLight = false;
    private Coroutine _shootingCoroutine;
    private bool _isChargingShot;

    private float time;
    private float delay = 2f;
    private float trackTimer;
    private float trackDelay = 1f;
    [SerializeField] private int trackIndex;

    // PRIVATE
    void Start()
    {
    }

    void Update()
    {
        TrackTarget();

        LookAtTarget();

        DetectTarget();

        LightHit(); 
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
        Vector3 playerLocation = playerLocations[trackIndex];

        Vector3 toTarget = playerLocation - transform.position;
        transform.position += _moveSpeed * Time.deltaTime * toTarget.normalized;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (toTarget.magnitude <= 1.1f)
        {
            trackIndex++;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = UnityEngine.Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _maxRaycastDistance);
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    private void TrackTarget()
    {
        if(trackTimer >= trackDelay)
        {
            playerLocations.Add(player.transform.position);
            trackTimer = 0;
        }
        trackTimer += Time.deltaTime;
    }

    private void LightHit()
    {
        if(HitByLight == true)
        {
            if((trackIndex-=5) < 0)
            {
                trackIndex = 0;
            }
            else
                trackIndex = trackIndex -5;
            HitByLight = false;
        }
    }
}
