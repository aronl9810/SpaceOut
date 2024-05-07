using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    void Update(){
        Physics.IgnoreLayerCollision(7,8);
    }
    
    private void OnCollisionEnter(Collision collision){
        Transform hitTransform = collision.transform;
        if(hitTransform.CompareTag("Player")){
            Debug.Log("Hit Player");
            hitTransform.GetComponent<HealthManager>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
