using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public ParticleSystem bulletParticle;

    void Update(){
        Physics.IgnoreLayerCollision(7,8);
    } 

    void OnCollisionEnter(Collision collision){
        Transform hitTransform = collision.transform;
        ContactPoint contact = collision.contacts[0];
        Vector3 position = contact.point;
        // Debug.Log(position);
        if(hitTransform.CompareTag("Enemy")){
            hitTransform.GetComponent<Enemy>().TakeDamage(20);
        }
        Destroy(gameObject);
        bulletParticle.transform.position = position;
        bulletParticle.Play();
    }
}