using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float healthAmount;
    private float initalHealthAmount;
    public Image healthBar;
    [SerializeField]
    private TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        initalHealthAmount = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "" + healthAmount + "/" + initalHealthAmount;
        if(healthAmount <= 0) 
        {
            SceneManager.LoadScene("Defeat");
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(20);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Heal(5);   
        }
        // Debug.Log(healthAmount);
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("QuitMenu");
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / initalHealthAmount;
    }

    public void Heal (float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0 , initalHealthAmount);

        healthBar.fillAmount = healthAmount / initalHealthAmount;
    }

    public float getMaxHealth(){
        return initalHealthAmount;
    }
}
