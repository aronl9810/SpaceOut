using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float healthAmount = 100f;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(healthAmount <= 0) 
        // {
        //     SceneManager.LoadScene(Application.LoadScene);
        // }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Heal(5);   
        }
        Debug.Log(healthAmount);
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal (float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0 , 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
