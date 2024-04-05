using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAmmo : MonoBehaviour
{

    public Gun grabGun;
    [SerializeField]
    private TextMeshProUGUI guntext;
    private int currentammo;
    private string field;
    public Image reload;
    private float reloadtime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentammo = grabGun.getAmmo();
        reloadtime = grabGun.getReloadTime();
        field = "" + currentammo + "";
        guntext.text = field;
    }
}
