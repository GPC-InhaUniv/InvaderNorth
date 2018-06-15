using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelController : MonoBehaviour
{
    public Text PlayerLevelText;

    public Text HeartLevelText;
    public Text ShotLevelText;
    public Text CriticalLevelText;

    private int heartnum;
    private int shotnum;
    private int criticalnum;

    public void ChangePlayerLevel()
    {
        heartnum = Int32.Parse(HeartLevelText.text);
        shotnum = Int32.Parse(ShotLevelText.text);
        criticalnum = Int32.Parse(CriticalLevelText.text);

        PlayerLevelText.text = (heartnum + shotnum + criticalnum).ToString();
    }
}