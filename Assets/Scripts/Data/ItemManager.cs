using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public void Setup()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    public List<ItemData<Pet>> GenerateDefaultPetData(){
        List<ItemData<Pet>> petData = new List<ItemData<Pet>>();
        petData.Add(new ItemData<Pet>(Pet.Cat , 0, ItemState.Equipped));
        petData.Add(new ItemData<Pet>(Pet.Bunny , 50, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Dog , 50, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Fox , 50, ItemState.Unbought));

        
        petData.Add(new ItemData<Pet>(Pet.Raccoon , 100, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Wolf , 100, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Goat , 100, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Elephant , 100, ItemState.Unbought));

        petData.Add(new ItemData<Pet>(Pet.Lion , 150, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Panda , 150, ItemState.Unbought));

        petData.Add(new ItemData<Pet>(Pet.Unicorn , 200, ItemState.Unbought));
        petData.Add(new ItemData<Pet>(Pet.Dragon , 200, ItemState.Unbought));
        
        return petData;
    }
    public List<ItemData<Board>> GenerateDefaultBoardData(){
        List<ItemData<Board>> boardData = new List<ItemData<Board>>();
        boardData.Add(new ItemData<Board>(Board.Blue , 0, ItemState.Equipped));
        boardData.Add(new ItemData<Board>(Board.Ice , 50, ItemState.Unbought));
        boardData.Add(new ItemData<Board>(Board.Lightning , 50, ItemState.Unbought));
        boardData.Add(new ItemData<Board>(Board.Rose , 50, ItemState.Unbought));
        boardData.Add(new ItemData<Board>(Board.Magma , 100, ItemState.Unbought));
        boardData.Add(new ItemData<Board>(Board.Galactic , 100, ItemState.Unbought));
        return boardData;
    }
    public List<ItemData<Accessory>> GenerateDefaultAccessoryData(){
        List<ItemData<Accessory>> accessoryData = new List<ItemData<Accessory>>();
        accessoryData.Add(new ItemData<Accessory>(Accessory.Crown, 200, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.Monocle, 0, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.Moustache, 25, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.PartyHat, 25, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.PirateHat, 100, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.Shades, 0, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.Sombrero, 100, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.Tiara, 200, ItemState.Unbought));
        accessoryData.Add( new ItemData<Accessory>(Accessory.TopHat, 75, ItemState.Unbought));
        return accessoryData;
    }
    private List<ItemData<T>> GetList<T>(T item){
        List<ItemData<T>> itemList = new List<ItemData<T>>();
        if (item is Pet) {
            return DataManager.instance.playerData.petList.Cast<ItemData<T>>().ToList();
        }
        else if (item is Board){
            return DataManager.instance.playerData.boardList.Cast<ItemData<T>>().ToList();
        }
        else if (item is Accessory){
            return DataManager.instance.playerData.accessoryList.Cast<ItemData<T>>().ToList();
        }
        return null;
    }

    public void TryBuyItem<T>(T item){
        if (TryGetData(item, out ItemData<T> data) && data.itemState == ItemState.Unbought){
            int coinCost = data.coinCost;
            if (DataManager.instance.playerData.coins >= coinCost){
                DataManager.instance.playerData.coins -= coinCost;
                UnequipItems(item);
                data.itemState = ItemState.Equipped; 
                TrySetData(data);
            }
        }
    }
    public void UnequipItems<T>(T item){
        if (!(item is Accessory)){
            List<ItemData<T>> itemList = GetList(item);
            if (itemList != null){
                for(int i = 0; i < itemList.Count; i++){
                    ItemData<T> itemData = itemList[i];
                    if (itemData.itemState == ItemState.Equipped){
                        itemData.itemState = ItemState.Bought;
                        itemList[i] = itemData;
                        TrySetData(itemData);
                    }
                }
            }
        }
    }
    public void UnequipCurrentItem<T>(T item){
        if (item is Accessory){
            List<ItemData<T>> itemList = GetList(item);
            if (itemList != null){
                for(int i = 0; i < itemList.Count; i++){
                    ItemData<T> itemData = itemList[i];
                    if (EqualityComparer<T>.Default.Equals(itemData.item, item) && itemData.itemState == ItemState.Equipped){
                        itemData.itemState = ItemState.Bought;
                        itemList[i] = itemData;
                        TrySetData(itemData);
                    }
                }
            }
        }
    }
    public void TryEquipItem<T>(T item){
        if (TryGetData(item, out ItemData<T> data) && data.itemState == ItemState.Bought){
            UnequipItems(item);
            data.itemState = ItemState.Equipped;
            TrySetData(data);
        }
    }
    public bool TryGetData<T>(T entry, out ItemData<T> data){
        List<ItemData<T>> itemList = GetList(entry);
        if (itemList != null){
            foreach(ItemData<T> itemData in itemList){
                if(EqualityComparer<T>.Default.Equals(itemData.item, entry)){
                    data = itemData;
                    return true;
                }
            }
        }
        
        data = new ItemData<T>();
        return false;
    }
    public bool TrySetData<T>(ItemData<T> data){
        T desiredItem = data.item;
        if (desiredItem is Pet){
            List<ItemData<T>> itemList = DataManager.instance.playerData.petList.Cast<ItemData<T>>().ToList();
            for(int i = 0; i < itemList.Count; i++){
                ItemData<T> itemData = itemList[i];
                if (EqualityComparer<T>.Default.Equals(itemData.item, desiredItem)){
                    DataManager.instance.playerData.petList[i] = (ItemData<Pet>)(object)data;
                    DataManager.instance.SavePlayerData();
                    return true;
                }
            }
        }
        if (desiredItem is Board){
            List<ItemData<T>> itemList = DataManager.instance.playerData.boardList.Cast<ItemData<T>>().ToList();
            for(int i = 0; i < itemList.Count; i++){
                ItemData<T> itemData = itemList[i];
                if (EqualityComparer<T>.Default.Equals(itemData.item, desiredItem)){
                    DataManager.instance.playerData.boardList[i] = (ItemData<Board>)(object)data;
                    DataManager.instance.SavePlayerData();
                    return true;
                }
            }
        }
        if (desiredItem is Accessory){
            List<ItemData<T>> itemList = DataManager.instance.playerData.accessoryList.Cast<ItemData<T>>().ToList();
            for(int i = 0; i < itemList.Count; i++){
                ItemData<T> itemData = itemList[i];
                if (EqualityComparer<T>.Default.Equals(itemData.item, desiredItem)){
                    DataManager.instance.playerData.accessoryList[i] = (ItemData<Accessory>)(object)data;
                    DataManager.instance.SavePlayerData();
                    return true;
                }
            }
        }
        return false;
    }
    public Pet GetCurrentPet(){
        foreach(ItemData<Pet> petData in DataManager.instance.playerData.petList){
            if (petData.itemState == ItemState.Equipped) return petData.item;
        }
        return new Pet();
    }
    public Board GetCurrentBoard(){
        foreach(ItemData<Board> boardData in DataManager.instance.playerData.boardList){
            if (boardData.itemState == ItemState.Equipped) return boardData.item;
        }
        return new Board();
    }
    public List<Accessory> GetCurrentAccessories(){
        List<Accessory> accessories = new List<Accessory>();
        foreach(ItemData<Accessory> accessoryData in DataManager.instance.playerData.accessoryList){
            if (accessoryData.itemState == ItemState.Equipped){
                accessories.Add(accessoryData.item);
            }
        }
        return accessories;
    }

    public void UnlockEverything(){
        for(int i = DataManager.instance.playerData.petList.Count-1; i>=0; i--){
            ItemData<Pet> petData = DataManager.instance.playerData.petList[i];
            TrySetData(new ItemData<Pet>(petData.item, 0, ItemState.Bought));
        }
        for(int i = DataManager.instance.playerData.boardList.Count-1; i>=0; i--){
            ItemData<Board> boardData = DataManager.instance.playerData.boardList[i];
            TrySetData(new ItemData<Board>(boardData.item, 0, ItemState.Bought));
        }
        for(int i = DataManager.instance.playerData.accessoryList.Count-1; i>=0; i--){
            ItemData<Accessory> accessoryData = DataManager.instance.playerData.accessoryList[i];
            TrySetData(new ItemData<Accessory>(accessoryData.item, 0, ItemState.Bought));
        }
    }
    /*
    public bool TrySetData(ItemData<Pet> data){
        Pet desiredItem = data.item;
        ref List<ItemData<Pet>> itemList = ref DataManager.instance.GetPetList();
        for(int i = 0; i < itemList.Count; i++){
            if (desiredItem == itemList[i].item){
                itemList[i] = data;
                return true;
            }
        }
        return false;
    }
    public bool TrySetData(ItemData<Board> data){
        Board desiredItem = data.item;
        ref List<ItemData<Board>> itemList = ref DataManager.instance.GetBoardList();
        for(int i = 0; i < itemList.Count; i++){
            if (desiredItem == itemList[i].item){
                itemList[i] = data;
                return true;
            }
        }
        return false;
    }
    public bool TrySetData(ItemData<Accessory> data){
        Accessory desiredItem = data.item;
        ref List<ItemData<Accessory>> itemList = ref DataManager.instance.GetAccessoryList();
        for(int i = 0; i < itemList.Count; i++){
            if (desiredItem == itemList[i].item){
                itemList[i] = data;
                return true;
            }
        }
        return false;
    }
    */
}

[System.Serializable]
public enum ItemState{
    Unbought,
    Bought,
    Equipped
}

[System.Serializable]
public enum Pet {
    Bunny,
    Cat,
    Dog,
    Dragon,
    Elephant,
    Fox,
    Goat,
    Lion,
    Panda,
    Raccoon,
    Unicorn,
    Wolf
}
[System.Serializable]
public enum Board{
    Blue,
    Lightning,
    Magma,
    Ice,
    Rose,
    Galactic
}
[System.Serializable]
public enum Accessory{
    Shades,
    Moustache,
    Monocle,
    PirateHat,
    TopHat,
    Sombrero,
    PartyHat,
    Tiara,
    Crown,
}