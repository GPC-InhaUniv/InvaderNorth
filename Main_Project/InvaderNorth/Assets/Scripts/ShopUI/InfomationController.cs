using UnityEngine;

public class InfomationController : MonoBehaviour
{
    [Header("InformationBox")]
    [SerializeField]
    private GameObject informationBox;

    public void PopInformation()
    {
        if (informationBox.activeSelf == false)
        {
            informationBox.SetActive(true);
        }
        else if (informationBox.activeSelf == true)
        {
            informationBox.SetActive(false);
        }
    }
}