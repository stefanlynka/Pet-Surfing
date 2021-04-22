using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryCard : ShopCard
{
    public Accessory accessory;
    

    public void TryToBuy(){
        ItemManager.instance.TryBuyAccessory(accessory);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUse(){
        ItemManager.instance.TryEquipAccessory(accessory);
        shopScreen.ReloadCurrentTab();
    }
    public void Setup(){
        if (ItemManager.instance.TryGetAccessoryData(accessory, out ItemData<Accessory> data)){
            SetButtonActive(data.itemState);
            buyText.SetText(data.coinCost.ToString());
            nameText.SetText(data.item.ToString());
        }
    }
}
