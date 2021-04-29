using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCard : ShopCard
{
    public Board board;
    

    public void TryToBuy(){
        ItemManager.instance.TryBuyItem(board);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUse(){
        ItemManager.instance.TryEquipItem(board);
        shopScreen.ReloadCurrentTab();
    }
    public void Setup(ShopScreen screen){
        if (ItemManager.instance.TryGetData(board, out ItemData<Board> data)){
            SetButtonActive(data.itemState);
            buyText.SetText(data.coinCost.ToString());
            nameText.SetText(data.item.ToString());
        }
        shopScreen = screen;
    }
}
