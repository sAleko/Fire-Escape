using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    private Vector3 target;
    private NavMeshAgent agent;
    private Animator wolfAnim;
    private Health playerHealth;
    private Rigidbody wolfRb;
    private bool playerDied = false;
    private bool biting = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wolfAnim = GetComponent<Animator>();
        playerHealth = player.GetComponent<Health>();
        wolfRb = GetComponent<Rigidbody>();

        target = player.position;
        wolfAnim.CrossFade("Run", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && playerHealth.dying)
        {
            target = transform.position;
            if (!playerDied)
            {
                playerDied = true;
                wolfAnim.CrossFade("Sit", 0.1f);
                agent.isStopped = true;
            }
        } else
        {
            target = player.position;
        }
        agent.destination = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!playerDied && !biting)
                StartCoroutine(BitePlayer());
        }
    }

    IEnumerator BitePlayer()
    {
        target = transform.position;

        wolfAnim.CrossFade("Idle", 0.1f);

        agent.isStopped = true;

        biting = true;

        yield return new WaitForSeconds(4f);

        biting = false;

        target = player.position;

        agent.isStopped = false;

        if (!playerDied)
            wolfAnim.CrossFade("Run", 0.1f);

    }
}
