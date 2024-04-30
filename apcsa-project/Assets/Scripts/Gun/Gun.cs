using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{

    // Gun Stuff
    public UnityEvent OnGunShoot;
    public int Ammo;
    private int startingAmmo;
    public float reloadTime;
    private float currentReloadTime;
    private bool isreloading;
    public float FireCooldown;
    public bool Automatic;
    public AudioSource getAudio;
    public AudioClip sfx1;
    public ParticleSystem muzzleFlash;
    private float CurrentCooldown;

    // Bullet Stuff
    public GameObject Bullet;
    public Camera fpsCamera;
    public Transform attackPoint;
    public float shootForce, upwardForce;

    // Charging Handle
    [SerializeField]
    public GameObject charginghandle;
    private bool currentlyfiring;
    
    void Start()
    {
        CurrentCooldown = FireCooldown;
        currentReloadTime = reloadTime;
        startingAmmo = Ammo;
        isreloading = false;
    }

    void Update()
    {
        currentlyfiring = false;
        charginghandle.GetComponent<Animator>().SetBool("isFiring", currentlyfiring);
        if(Ammo > 0){
            if(!isreloading){
                if(Automatic){
                    if(Input.GetMouseButton(0)){
                        if(CurrentCooldown <= 0f){
                            currentlyfiring = true;
                            charginghandle.GetComponent<Animator>().SetBool("isFiring", currentlyfiring);
                            Ray ray = fpsCamera.ViewportPointToRay(new Vector3(0.5f , 0.5f , 0));
                            RaycastHit hit;
                            
                            Vector3 targetPoint;
                            if(Physics.Raycast(ray, out hit)){
                                targetPoint = hit.point;
                            } else {
                                targetPoint = ray.GetPoint(75);
                            }

                            Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

                            GameObject currentBullet = Instantiate(Bullet , attackPoint.position, Quaternion.identity);

                            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce , ForceMode.Impulse);
                            currentBullet.GetComponent<Rigidbody>().AddForce(fpsCamera.transform.up * upwardForce, ForceMode.Impulse);
                            Physics.IgnoreLayerCollision(6,7);
                            OnGunShoot?.Invoke();
                            muzzleFlash.Play();
                            getAudio.clip = sfx1;
                            getAudio.Play();
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

    public float getReloadTime(){
        return reloadTime;
    }

}
