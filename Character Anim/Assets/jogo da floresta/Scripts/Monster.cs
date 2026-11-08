using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class Monster : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] KnockBackEffect knockBackEffect;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = FindFirstObjectByType<Movement>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackEffect.knockback)
        {
            agent.enabled = false;
            return;
        }

        agent.enabled = true;
        agent.SetDestination(movement.transform.position);

        if (Vector2.Distance(transform.position, movement.transform.position) <= agent.stoppingDistance)
        {
            animator.SetBool("IsAttacking", true);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        else
        {
            animator.SetBool("IsAttacking", false);

        }

    }

}



