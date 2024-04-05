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
    private float ammoUI;
    private float initialammoUI;
    private string field;
    public Image ammoCount;
    public Image reload;
    private float reloadtime;
    private float initalreloadtime;

    // Start is called before the first frame update
    void Start()
    {
        initialammoUI = (float)grabGun.getAmmo();
        initalreloadtime = grabGun.getReloadTime();
    }

    // Update is called once per frame
    void Update()
    {
        currentammo = grabGun.getAmmo();
        ammoUI = (float)currentammo;
        ammoCount.fillAmount = ammoUI / initialammoUI;
        reloadtime = grabGun.getReloadTime();
        reload.fillAmount = (initalreloadtime - reloadtime)/ initalreloadtime;
        field = "" + currentammo + "";
        guntext.text = field;
    }
}
