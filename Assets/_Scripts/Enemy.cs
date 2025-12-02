using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 25;
    public GameObject explosion;
    public Transform[] waypoints;
    public GameObject eyeBall;

    private NavMeshAgent agent;
    private int currentDestionation;
    public bool spottedPlayer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);
        currentDestionation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //check if I can see the Player
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(eyeBall.transform.position, transform.forward, out hitInfo);

        if ((hit))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                //Debug.Log("I see you.");
                spottedPlayer = true;
                player = hitInfo.transform.gameObject;
                agent.SetDestination(hitInfo.transform.position);
            }
        }

        if (spottedPlayer)
        {
            agent.SetDestination(player.transform.position);
        }

        if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < .1f)
        {
            currentDestionation++;
            if(currentDestionation == waypoints.Length)
            {
                currentDestionation = 0;
            }
            agent.SetDestination(waypoints[currentDestionation].position);        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Took damage: " + health);
        if(health <= 0)
        {
            Instantiate(explosion, transform.position + new Vector3(0,.2f,0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
