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
        ContactPoint contact = collision.contacts[0];
        Vector3 position = contact.point;
        // Debug.Log(position);
        Destroy(gameObject);
        bulletParticle.transform.position = position;
        bulletParticle.Play();
    }
}