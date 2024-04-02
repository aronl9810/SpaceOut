using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAmmo : MonoBehaviour
{

    public Gun grabGun;
    [SerializeField]
    private TextMeshProUGUI guntext;
    private int currentammo;
    private string field;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentammo = grabGun.getAmmo();
        field = "Ammo: " + currentammo + "";
        guntext.text = field;
    }
}
