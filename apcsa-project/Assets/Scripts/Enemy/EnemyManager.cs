using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public KeyPad keypad;
    public int MaxEnemy;
    private int count;
    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("SpawnNewEnemy" , 1f , 1f);
    }


    void SpawnNewEnemy(){
        if(keypad.gameStarted() == true && count < MaxEnemy){
            count++;
            int randomNumber = Mathf.RoundToInt(Random.Range(0f,m_SpawnPoints.Length-1));
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber].transform.position, Quaternion.identity); 
        }
    }

    public void killed(){
        count--;
    }
}
