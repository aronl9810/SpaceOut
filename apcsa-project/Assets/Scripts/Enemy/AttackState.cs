using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    // Start is called before the first frame update

    private float moveTimer;
    private float losePlayerTimer;

    public override void Enter(){

    }
    
    public override void Exit(){

    }

    public override void Perform(){
        // Debug.Log("Perform activated : Attackstate");
        if(enemy.CanSeePlayer()){
            // Debug.Log("Attack State can see player");
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3,7)){
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        } else {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8){
                // Change to search state
                stateMachine.changeState(new PatrolState());
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
