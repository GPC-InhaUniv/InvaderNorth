using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelController : MonoBehaviour
{
    [Header("PlyaerTotalLevel")]
    [SerializeField]
    private Text PlayerLevelText;

    [Header("Gear Level")]
    [SerializeField]
    private Text HeartLevelText;

    [SerializeField]
    private Text ShotLevelText;

    [SerializeField]
    private Text CriticalLevelText;

    private int heartnum;
    private int shotnum;
    private int criticalnum;

    private void ChangePlayerLevel()
    {
        heartnum = Int32.Parse(HeartLevelText.text);
        shotnum = Int32.Parse(ShotLevelText.text);
        criticalnum = Int32.Parse(CriticalLevelText.text);
        PlayerLevelText.text = (heartnum + shotnum + criticalnum).ToString();
    }

    public void OnClickEvent()
    {
        ChangePlayerLevel();
    }

    private void Start()
    {
        ChangePlayerLevel();
    }
}