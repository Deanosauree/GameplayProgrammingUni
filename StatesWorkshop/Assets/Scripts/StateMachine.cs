using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static State;
public class StateMachine : MonoBehaviour

{

    private NavMeshAgent agent;

    private State currentState;

    [SerializeField] List<Transform> waypoints;


    void Start()

    {

        agent = GetComponent<NavMeshAgent>();

        // Initialize the guard's starting state

        ChangeState(new PatrolState(this, agent, waypoints));

    }


    void Update()

    {

        currentState?.Execute();

    }


    public void ChangeState(State newState)

    {

        currentState = newState;

    }

    void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("Player") && !(currentState is ChaseState))

        {

            ChangeState(new ChaseState(this, agent, other.transform));

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && (currentState is ChaseState))

        {

            ChangeState(new PatrolState(this, agent, waypoints));

        }
    }
}
