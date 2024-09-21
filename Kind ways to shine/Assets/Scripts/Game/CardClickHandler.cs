using UnityEngine;
using UnityEngine.UI;

public class CardClickHandler : MonoBehaviour
{
    public Transform[] dropZones;

    public void OnCardClicked()
    {
        foreach (var dropZone in dropZones)
        {
            if (dropZone.childCount == 0)
            {
                transform.SetParent(dropZone);
                transform.localPosition = Vector3.zero;
                break;
            }
        }
    }
}
