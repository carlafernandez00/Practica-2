using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// IPointerEnterHandler and IPointerExitHandler supply methods for when the pointer enters and exits the GameObject
public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model; //Reference to the mesh render that need its color change
    public Color normalColor;  //Default color
    public Color hoverColor;   //Color we want to apply

    // Start is called before the first frame update
    void Start()
    {
        model.material.color = normalColor;
    }

    // When the pointer enters to the game object -> change its color
    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    //  When the pointer exits to the game object -> change its color to the normal one
    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColor;
    }
}
