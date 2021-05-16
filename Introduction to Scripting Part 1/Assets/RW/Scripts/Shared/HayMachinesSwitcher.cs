using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;


public class HayMachinesSwitcher : MonoBehaviour, IPointerClickHandler
{
    // references to the diferent machines
    public GameObject blueHayMachine;
    public GameObject yellowHayMachine;
    public GameObject redHayMachine;

    private int selectedIndex;

    // gets called when the game obj. gets clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        selectedIndex++; //increment the var so the next color gets selected
        selectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length; //always taking values 0,1,2
        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex;   // taking the machine with this color

        // disable or disable the different machine depending on the color we want to use
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                blueHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
                break;

            case HayMachineColor.Yellow:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
                break;

            case HayMachineColor.Red:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
                break;
        }
    }
}
                                                                                            