using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManger : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CombatManger combatManager;

    public string MessageSent;
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Change button Color here");
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Revert button Color here");
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        combatManager.SendMessage(MessageSent);

        if (combatManager == null)
        {
            trashManagerScript.instance.SendMessage("Sell");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
