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
    private float initialHealthAmount;
    
    public UnityEngine.AI.NavMeshAgent Agent { get => agent;}
    [Header("Pathes")]
    public Path[] path;
    public int randomNum;
    public EnemyManager getManager;
    public GameObject Player { get => player; }
    public Vector3 LastKnowPos { get => lastKnowPos ; set => lastKnowPos = value; }
    [Header("Health")]
    public float healthAmount;
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
        randomNum = Mathf.RoundToInt(Random.Range(0f,path.Length-1));
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Intialise();
        player = GameObject.FindGameObjectWithTag("Player");
        if(healthAmount <= 0){
            Debug.Log("Heads up! Your enemy health cannot be below or exactly 0! Defaulting to 100");
            healthAmount = 100;
        }
        initialHealthAmount = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        // Debug.Log(player);
        currentState = stateMachine.activeState.ToString();
        if(healthAmount <= 0){
            getManager.killed();
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damagevalue){
        healthAmount -= damagevalue;
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
