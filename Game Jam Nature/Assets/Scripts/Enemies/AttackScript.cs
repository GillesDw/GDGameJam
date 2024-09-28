using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] float damage = 0;
    [SerializeField] float range = 0;
    [SerializeField] Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        AimAtTarget();
    }

    private void AimAtTarget()
    {    
        Vector3 playerLocation = player.transform.position;
        Vector3 toTarget = playerLocation - transform.position;
        if(toTarget.magnitude < range)
        {
            Attack();
        }
        Debug.Log(toTarget.magnitude);
    }

    private void Attack()
    {

    }
}
