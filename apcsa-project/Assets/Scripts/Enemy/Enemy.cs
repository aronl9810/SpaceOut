using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    public UnityEngine.AI.NavMeshAgent Agent { get => agent;}
    //just for debugging purposes
    // [SerializedField]
    private string currentState;
    public Path path;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Intialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
