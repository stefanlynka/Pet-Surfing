using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCard : MonoBehaviour
{
    public GameObject buyButton;
    public GameObject useButton;
    public GameObject currentButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI buyText;
    protected ShopScreen shopScreen;


    protected void SetButtonActive(ItemState itemState){
        switch(itemState){
            case ItemState.Unbought:
                buyButton.SetActive(true);
                useButton.SetActive(false);
                currentButton.SetActive(false);
                break;
            case ItemState.Bought:
                buyButton.SetActive(false);
                useButton.SetActive(true);
                currentButton.SetActive(false);
                break;
            case ItemState.Equipped:
                buyButton.SetActive(false);
                useButton.SetActive(false);
                currentButton.SetActive(true);
                break;
        }
    }
}
