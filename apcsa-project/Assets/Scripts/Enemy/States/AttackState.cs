using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    // Start is called before the first frame update

    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;

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
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if(shotTimer > enemy.fireRate){
                Shoot();
            }
            if (moveTimer > Random.Range(3,7)){
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        } else {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8){
                // Change to search state
                stateMachine.changeState(new SearchState());
            }
        }
    }

    public void Shoot(){
        Debug.Log("Shoot");
        // Store reference to gun barrel
        Transform gunbarrel = enemy.gunBarrel;
        // Create new Bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Enemy Bullet") as GameObject, gunbarrel.position, enemy.transform.rotation);
        // Calculate direction to the player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        // Add force rigidbody of the bullet
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f), Vector3.up) * shootDirection * 80;
        shotTimer = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
