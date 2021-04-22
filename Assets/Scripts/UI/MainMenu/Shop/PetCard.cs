using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetCard : ShopCard
{
    public Pet pet;
    

    public void TryToBuy(){
        ItemManager.instance.TryBuyPet(pet);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUse(){
        ItemManager.instance.TryEquipPet(pet);
        shopScreen.ReloadCurrentTab();
    }
    public void Setup(){
        if (ItemManager.instance.TryGetPetData(pet, out ItemData<Pet> data)){
            SetButtonActive(data.itemState);
            buyText.SetText(data.coinCost.ToString());
            nameText.SetText(data.item.ToString());
        }
    }
}

