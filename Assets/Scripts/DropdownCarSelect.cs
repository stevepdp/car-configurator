using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownCarSelect : MonoBehaviour
{
    private GameManager gameManager;
    private Basket basket;
    private Dropdown dropdownCarSelect;
    private Dropdown dropdownTiresetSelect;
    private Dropdown dropdownFrontSelect;
    private Dropdown dropdownWeaponSelect;
    private TMP_Text userSelectionsLabel;
    
    void Awake()
    {
        basket = GameObject.FindObjectOfType<Basket>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        userSelectionsLabel = GameObject.Find("LabelCurrentSelection").GetComponent<TMP_Text>();
        dropdownCarSelect = transform.GetComponent<Dropdown>();
    }

    void Start()
    {
        dropdownTiresetSelect = GameObject.Find("DropdownSelectTireset").GetComponent<Dropdown>();
        dropdownFrontSelect = GameObject.Find("DropdownSelectFront").GetComponent<Dropdown>();
        dropdownWeaponSelect = GameObject.Find("DropdownSelectWeapon").GetComponent<Dropdown>();

        // Set correct default dropdown selecton
        dropdownCarSelect.value = (int) gameManager.myCarInstance.GetCarType();

        // Set selection label default
        userSelectionsLabel.text = basket.GetBasketItemsAsString();
    }

    private void ResetDropdowns()
    {
        dropdownTiresetSelect.value = 0;
        dropdownFrontSelect.value = 0;
        dropdownWeaponSelect.value = 0;
    }

    public void ShowNextCar()
    {
        ResetDropdowns();

        // Pass the dropdown selection value as a CarType to gameManager
        gameManager.ChangeCar((CarType) dropdownCarSelect.value);

        // Change selection label
        userSelectionsLabel.text = userSelectionsLabel.text = basket.GetBasketItemsAsString();
    }
}
