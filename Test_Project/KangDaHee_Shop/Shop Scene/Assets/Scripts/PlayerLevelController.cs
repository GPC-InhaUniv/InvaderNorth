using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelController : MonoBehaviour
{
    public Text playerLevelText;

    public Text heartLevel;
    public Text shotLevel;
    public Text criticalLevel;

    private int heartnum;
    private int shotnum;
    private int criticalnum;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void ChangePlayerLevel()
    {
        heartnum = Int32.Parse(heartLevel.text);
        shotnum = Int32.Parse(shotLevel.text);
        criticalnum = Int32.Parse(criticalLevel.text);

        playerLevelText.text = (heartnum + shotnum + criticalnum).ToString();
    }
}