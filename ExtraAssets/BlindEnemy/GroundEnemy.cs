using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundEnemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private float _health = 10f;
    [SerializeField] private GameObject visual;
    [Header("Moving")]
    [SerializeField] private float _moveSpeed = 3f;
    [Header("Attack")]
    [SerializeField] private float _speedReduction;
    [SerializeField] private int _damage;
    [SerializeField] private float _maxRaycastDistance = 100f;
    [SerializeField] private float _attackRange = 6f;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private GameObject _onDeathParticle;
    [Header("Audio")]
    [SerializeField] private AudioPlayer deathEnemy;
    [SerializeField] private Animator animator;

    private SoulWagon _soulWagon;
    private Coroutine _shootingCoroutine;
    private bool _isChargingShot;
    private float _cooldownTimeElapsed = 99f;
    private bool _isStunned;
    private int _amountOfSouls;
    private SoulsManager _soulsManager;

    private float trainRight = -2.2f;
    private float trainLeft = 2.2f;

    private float time;
    private float delay = 2f;


    // PRIVATE
    void Start()
    {
        _soulWagon = FindAnyObjectByType<SoulWagon>();
        _amountOfSouls = Random.Range(0, 4);

        visual.SetActive(false);

        _isStunned = true;
        Invoke(nameof(EndOfStun), 1.5f);
        Invoke(nameof(EnableVisual), 1f);
    }

    private void EnableVisual()
    {
        visual.SetActive(true);
    }

    void Update()
    {
        if (_isStunned) { return; }
        LookAtTarget();

        DetectTarget();
        CheckDistance();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(transform.position, _soulWagon.transform.position);
        if (distance > _soulWagon._maxDistanceToSoulsWagon)
        {
            DestroySelf();
        }
    }

    private void LookAtTarget()
    {
        Vector3 target = _soulWagon.transform.position;
        target.y = 0;
        transform.LookAt(target);
    }

    private void DetectTarget()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxRaycastDistance, _targetLayerMask))
        {
            if (hit.collider != null)
            {
                // Target in range
                if (Vector3.Distance(transform.position, hit.collider.transform.position) <= _attackRange)
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
                    if (time > +delay)
                    {
                        MoveToTarget();
                    }
                }
            }
        }

        time += Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            DeathWithSound();
        }
    }

    private void DeathWithSound()
    {
        deathEnemy.Play();
        Death();
    }

    private void Death()
    {
        if (!_isStunned)
        {
            animator.SetTrigger("Death");

            _soulsManager = FindObjectOfType<SoulsManager>();
            _soulsManager.AddSouls(1f * _amountOfSouls);
        }

        GetComponent<Rigidbody>().isKinematic = true;

        DestroySelf();
    }

    public void DestroySelf()
    {
        _isStunned = true;

        GameObject movingObject = GameObject.FindGameObjectWithTag("MovingObject");
        GameObject onDeath = Instantiate(_onDeathParticle, transform.position, Quaternion.identity, movingObject.transform);
        Destroy(onDeath, 5f);
        Destroy(gameObject, 2f);
    }

    public void Stun()
    {
        if (_isStunned) { return; }

        _isStunned = true;

        Invoke(nameof(EndOfStun), 1f);
    }

    private void EndOfStun()
    {
        _isStunned = false;
    }

    private void Shoot()
    {
        animator.SetTrigger("Attack");
        _soulWagon.TakeDamage(_damage, _speedReduction);

        Invoke(nameof(EndShoot), 1.25f);
    }

    private void EndShoot()
    {
        time = 0;
    }

    private void MoveToTarget()
    {
        Vector3 wagonLocation = _soulWagon.transform.position;
        if (transform.position.x < 0)
        {
            wagonLocation.x = trainRight - Random.Range(0f, .25f);
        }
        else
        {
            wagonLocation.x = trainLeft + Random.Range(0f, .25f);
        }

        Vector3 toTarget = wagonLocation - transform.position;
        transform.position += _moveSpeed * Time.deltaTime * toTarget.normalized;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _maxRaycastDistance);
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            DestroySelf();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            DestroySelf();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            DestroySelf();
        }
    }
}
