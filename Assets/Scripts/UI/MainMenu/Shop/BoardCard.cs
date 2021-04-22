using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCard : ShopCard
{
    public Board board;
    

    public void TryToBuy(){
        ItemManager.instance.TryBuyBoard(board);
        shopScreen.ReloadCurrentTab();
    }
    public void TryUse(){
        ItemManager.instance.TryEquipBoard(board);
        shopScreen.ReloadCurrentTab();
    }
    public void Setup(){
        print("loading board");
        print("item mananger:" + ItemManager.instance.name);
        if (ItemManager.instance.TryGetBoardData(board, out ItemData<Board> data)){
            SetButtonActive(data.itemState);
            buyText.SetText(data.coinCost.ToString());
            nameText.SetText(data.item.ToString());
        }
    }
}
