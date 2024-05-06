using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private StateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;
    private Vector3 lastKnowPos;
    public UnityEngine.AI.NavMeshAgent Agent { get => agent;}
    public Path path;
    public GameObject Player { get => player; }
    public Vector3 LastKnowPos { get => lastKnowPos ; set => lastKnowPos = value; }
    [Header("Sight Values")]
    //just for debugging purposes
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight = 0.7f;
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f,10f)]
    public float fireRate;
    [SerializeField]
    private string currentState;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Intialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        // Debug.Log(player);
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer(){
        if(player != null){
            // Is this player close enough to be seen
            // if blocked, set tag to ignore raycast or sphere collider
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance){
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView){
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray , out hitInfo , sightDistance)){
                        if(hitInfo.transform.gameObject == player){
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
