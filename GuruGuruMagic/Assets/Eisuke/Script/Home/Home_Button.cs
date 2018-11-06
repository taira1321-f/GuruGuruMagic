using UnityEngine;
using UnityEngine.EventSystems;

public class Home_Button : MonoBehaviour, IPointerClickHandler
{
    public void A_button_Down()
    {
        Debug.Log("やったぜ!!");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
