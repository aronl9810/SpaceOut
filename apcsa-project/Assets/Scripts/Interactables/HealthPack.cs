using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Interactable
{

    [SerializeField]    
    private HealthManager getHealthManagerScript;
    public int healthSize;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = getHealthManagerScript.getMaxHealth();
    }

    protected override void Interact(){
        /*
        0 or any number : Small Healthkit (Restores 20% of your hp)
        1 : Medium Healthkit (Restores 50% of your hp)
        2 : Large Healthkit (Restores your entire hp)
        */
        switch(healthSize){
            default:
            getHealthManagerScript.Heal(maxHealth * (float).2);
            break;
            case 1:
            getHealthManagerScript.Heal(maxHealth * (float).5);
            break;
            case 2:
            getHealthManagerScript.Heal(maxHealth);
            break;
        }
    }

}
