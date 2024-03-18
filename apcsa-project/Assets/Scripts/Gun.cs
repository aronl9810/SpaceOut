using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public float FireCooldown;
    public bool Automatic;
    public ParticleSystem muzzleFlash;
    private float CurrentCooldown;
    
    void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    void Update()
    {
        if(Automatic){
            if(Input.GetMouseButton(0)){
                if(CurrentCooldown <= 0f){
                    OnGunShoot?.Invoke();
                    muzzleFlash.Play();
                    // Debug.Log("Shooting automatic");
                    CurrentCooldown = FireCooldown;
                }
            }
        } else {
            if(Input.GetMouseButtonDown(0)){
                if(CurrentCooldown <= 0f){
                    OnGunShoot?.Invoke();
                    muzzleFlash.Play();
                    // Debug.Log("Shooting semiautomatic");
                    CurrentCooldown = FireCooldown;
                }
            }
        }
        CurrentCooldown -= Time.deltaTime;
    }
}
