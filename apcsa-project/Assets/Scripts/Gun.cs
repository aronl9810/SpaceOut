using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public int Ammo;
    private int startingAmmo;
    public float reloadTime;
    private float currentReloadTime;
    private bool isreloading;
    public float FireCooldown;
    public bool Automatic;
    public ParticleSystem muzzleFlash;
    private float CurrentCooldown;
    
    void Start()
    {
        CurrentCooldown = FireCooldown;
        currentReloadTime = reloadTime;
        startingAmmo = Ammo;
        isreloading = false;
    }

    void Update()
    {
        if(Ammo > 0){
            if(!isreloading){
                if(Automatic){
                    if(Input.GetMouseButton(0)){
                        if(CurrentCooldown <= 0f){
                            OnGunShoot?.Invoke();
                            muzzleFlash.Play();
                            Ammo--;
                            // Debug.Log("Shooting automatic");
                            CurrentCooldown = FireCooldown;
                        }
                    }
                } else {
                    if(Input.GetMouseButtonDown(0)){
                        if(CurrentCooldown <= 0f){
                            OnGunShoot?.Invoke();
                            muzzleFlash.Play();
                            Ammo--;
                            // Debug.Log("Shooting semiautomatic");
                            CurrentCooldown = FireCooldown;
                        }
                    }
                }
            }
        }
        CurrentCooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R)){
            if(Ammo != startingAmmo){
                Reload();
            }
        }

        if(isreloading){
            reloadTime -= Time.deltaTime;
        }

        if(reloadTime <= 0f){
            FinishReload();
        }
    }

    public void Reload(){
        isreloading = !isreloading;
        reloadTime = currentReloadTime;
    }

    public void FinishReload(){
        Ammo = startingAmmo;
        isreloading = false;
        reloadTime = currentReloadTime;
    }

    public int getAmmo(){
        return Ammo;
    }

}
