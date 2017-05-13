using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICtrl : MonoBehaviour {

    public GameObject player;
    public GameObject levelUpObj;

    private void Awake()
    {
        levelUpObj.SetActive(false);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Level: " + playerCtrl.playerLevel );
        GUI.Label(new Rect(10, 30, 100, 20), "XP: " + playerCtrl.currentXP + "/" + playerCtrl.requiredXP);
    }
}
