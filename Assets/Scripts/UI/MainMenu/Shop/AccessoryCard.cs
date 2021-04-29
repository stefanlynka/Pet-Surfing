using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryCard : ShopCard
{
    public Accessory accessory;
    

    public void TryToBuy(){
        ItemManager.instance.TryBuyItem(accessory);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUse(){
        ItemManager.instance.TryEquipItem(accessory);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUnequip(){
        ItemManager.instance.UnequipCurrentItem(accessory);
        shopScreen.ReloadCurrentTab();
    }
    public void Setup(ShopScreen screen){
        if (ItemManager.instance.TryGetData(accessory, out ItemData<Accessory> data)){
            SetButtonActive(data.itemState);
            buyText.SetText(data.coinCost.ToString());
            nameText.SetText(data.item.ToString());
        }
        shopScreen = screen;
    }
}
