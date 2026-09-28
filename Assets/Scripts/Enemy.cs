using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100.0f;
    private float disToPlayer;
    private bool isInPursueRange = false;
    private bool isInAttackRange = false;
    public Transform player;
    float pursueDistance = 5f;
    float attackDistance = 1f;
    float speed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        disToPlayer = Vector3.Distance(transform.position, player.position);
        //Debug.Log(disToPlayer);
    }

    // Update is called 
    void FixedUpdate()
    {
        disToPlayer = Vector3.Distance(transform.position, player.position);
        transform.LookAt(player.position);
        isInPursueRange = disToPlayer < attackDistance;
        if (isInPursueRange)
        {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        
    }

    public void TakeDamage(float dmg)
    {
        //Debug.Log($"Perdi {dmg} hp");
        hp -= dmg;
        if (hp <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}


