using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject[] m_EnemyPrefab;
    // Start is called before the first frame update
    // void Start()
    // {
    //     SpawnNewEnemy();
    // }

    // // Update is called once per frame

    // void SpawnNewEnemy(){
    //     Instantiate(m_EnemyPrefab, m_SpawnPoints[0].transform.position, Quaternion.identity);
    // }
}
