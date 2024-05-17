using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer;
    public override void Enter()
    {

    }
    public override void Perform()
    {
        // Debug.Log("Perform activated : PatrolState");
        PatrolCycle();
        if(enemy.CanSeePlayer()){
            stateMachine.changeState(new AttackState());
        }
    }
    public override void Exit()
    {
    
    }
    public void PatrolCycle()
    {
        //implement our patrol logic.
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer > 3)
            {
                if(waypointIndex < enemy.path[enemy.randomNum].waypoints.Count - 1)
                    waypointIndex++;
                else
                    waypointIndex = 0;
                enemy.Agent.SetDestination(enemy.path[enemy.randomNum].waypoints[waypointIndex].position);
                waitTimer = 0;
            }
            
        }
    }
}
