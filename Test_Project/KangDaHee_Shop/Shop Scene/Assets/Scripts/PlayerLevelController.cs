using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelController : MonoBehaviour
{
    public Text PlayerLevelText;

    public Text HeartLevel;
    public Text ShotLevel;
    public Text CriticalLevel;

    private int heartnum;
    private int shotnum;
    private int criticalnum;

    public void ChangePlayerLevel()
    {
        heartnum = Int32.Parse(HeartLevel.text);
        shotnum = Int32.Parse(ShotLevel.text);
        criticalnum = Int32.Parse(CriticalLevel.text);

        PlayerLevelText.text = (heartnum + shotnum + criticalnum).ToString();
    }
}