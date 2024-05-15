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
        // Debug.Log(hitTransform);
        if(hitTransform.CompareTag("Player")){
            hitTransform.GetComponent<HealthManager>().TakeDamage(10);
        }
        Destroy(gameObject);
    }
}
