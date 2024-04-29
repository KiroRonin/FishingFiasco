using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovered;

    private Item heldItem;

    private Color opaque = new Color(1,1,1,1);
    private Color transparent = new Color(1,1,1,0);

    private UnityEngine.UI.Image thisSlotImage;

    public void inistializeSlot(){
        thisSlotImage = gameObject.GetComponent<UnityEngine.UI.Image>();
        thisSlotImage.sprite = null;
        thisSlotImage.color = transparent;
        setItem(null);
    }

    public void setItem(Item item){

    }

    public Item getItem(){
        return heldItem;
    }

    public void OnPointerEnter(PointerEventData pointerEventData){
        hovered = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData){
        hovered = false;
    }
}
