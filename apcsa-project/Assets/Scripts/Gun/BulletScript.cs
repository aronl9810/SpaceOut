using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public ParticleSystem bulletParticle;
    [Header("Audio")]
    public AudioSource getAudio;
    public AudioClip sfx1;
    public Crosshair getCrosshair;

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
            getAudio.clip = sfx1;
            getAudio.Play();
            getCrosshair.hitEnemy();          
        }
        Destroy(gameObject);
        bulletParticle.transform.position = position;
        bulletParticle.Play();
    }
}