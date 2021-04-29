using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCard : ShopCard
{
    public Pet pet;
    

    public void TryToBuy(){
        ItemManager.instance.TryBuyItem(pet);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUse(){
        ItemManager.instance.TryEquipItem(pet);
        shopScreen.ReloadCurrentTab();
    }
    public void Setup(ShopScreen screen){
        if (ItemManager.instance.TryGetData(pet, out ItemData<Pet> data)){
            SetButtonActive(data.itemState);
            buyText.SetText(data.coinCost.ToString());
            nameText.SetText(data.item.ToString());
        }
        shopScreen = screen;
    }
}

