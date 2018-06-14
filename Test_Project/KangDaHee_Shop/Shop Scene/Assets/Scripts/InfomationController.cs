using UnityEngine;

public class InfomationController : MonoBehaviour
{
    public GameObject informationBox;

    public void PopInformation()
    {
        if (informationBox.gameObject.active == false)
        {
            informationBox.SetActive(true);
        }
        else if (informationBox.gameObject.active == true)
        {
            informationBox.SetActive(false);
        }
    }
}