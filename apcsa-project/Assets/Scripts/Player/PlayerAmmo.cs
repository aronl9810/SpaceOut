using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        playerUI.UpdateText("Ammo: ??");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
