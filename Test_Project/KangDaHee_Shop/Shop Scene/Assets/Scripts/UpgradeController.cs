using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UpgradeController : MonoBehaviour
{
    private int gearLevel;
    public int upgradeMaxLevel;

    public int levelResourceNum;

    private int changedNum01;
    private int changedNum02;
    private int changedNum03;

    public Image upgradeButton;

    public Text levelText;
    public Text levelResourceText;

    public GameObject changedImage01;
    public GameObject changedImage02;
    public GameObject changedImage03;
    public GameObject changedImage04;

    private void Start()
    {
        changedNum01 = 5;
        changedNum02 = 10;
        changedNum03 = 15;
    }

    private void Update()
    {
    }

    public void ChangeGear()
    {
        if (gearLevel < upgradeMaxLevel)
        {
            gearLevel++;
            levelResourceNum = levelResourceNum + 500;

            levelText.text = gearLevel.ToString();
            levelResourceText.text = levelResourceNum.ToString();
        }

        if (gearLevel == changedNum01)
        {
            changedImage02.SetActive(true);
            changedImage01.SetActive(false);
        }

        if (gearLevel == changedNum02)
        {
            changedImage03.SetActive(true);
            changedImage02.SetActive(false);
        }
        if (gearLevel == changedNum03)
        {
            changedImage04.SetActive(true);
            changedImage03.SetActive(false);
        }

        if (gearLevel == upgradeMaxLevel)
        {
            levelResourceText.text = "-";
            upgradeButton.enabled = false;
        }
    }
}