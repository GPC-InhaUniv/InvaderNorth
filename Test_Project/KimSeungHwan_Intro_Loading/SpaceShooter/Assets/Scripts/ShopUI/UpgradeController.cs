using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeController : MonoBehaviour
{
    private int gearLevel;
    private int playerResource;

    public int GearUpgradeMaxLevel;
    public int LevelResourceNum;

    private int changedNum01; //배열로 만들면 어떨까.
    private int changedNum02;
    private int changedNum03;

    public Image UpgradeButton;

    public Text LevelText;
    public Text LevelResourceText;
    public Text PlayerResourceText;

    public GameObject ChangedImage01;
    public GameObject ChangedImage02;
    public GameObject ChangedImage03;
    public GameObject ChangedImage04;

    private void Start()
    {
        changedNum01 = 5;
        changedNum02 = 10;
        changedNum03 = 15;
    }

    public void ChangeGear()
    {
        playerResource = Int32.Parse(PlayerResourceText.text);

        if (playerResource >= LevelResourceNum)
        {
            if (gearLevel < GearUpgradeMaxLevel)
            {
                LevelResourceText.text = "<color=#ffffff>" + LevelResourceNum + "</color>";

                playerResource = playerResource - LevelResourceNum;
                gearLevel++;
                LevelResourceNum = LevelResourceNum + 500;

                LevelText.text = gearLevel.ToString();
                LevelResourceText.text = LevelResourceNum.ToString();
                PlayerResourceText.text = playerResource.ToString();
            }

            if (gearLevel < changedNum01)
            {
                ChangedImage01.SetActive(true);
            }

            if (gearLevel == changedNum01)
            {
                ChangedImage02.SetActive(true);
                ChangedImage01.SetActive(false);
            }

            if (gearLevel == changedNum02)
            {
                ChangedImage03.SetActive(true);
                ChangedImage02.SetActive(false);
            }
            if (gearLevel == changedNum03)
            {
                ChangedImage04.SetActive(true);
                ChangedImage03.SetActive(false);
            }

            if (gearLevel == GearUpgradeMaxLevel)
            {
                LevelResourceText.text = "-";
                UpgradeButton.enabled = false;
            }
        }
        else
        {
            LevelResourceText.text = "<color=#ff0000>" + LevelResourceNum + "</color>";
        }
    }
}