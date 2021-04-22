using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    public Dictionary<Pet, ItemData<Pet>> GenerateDefaultPetData(){
        Dictionary<Pet, ItemData<Pet>> petData = new Dictionary<Pet, ItemData<Pet>>();
        petData.Add(Pet.Cat , new ItemData<Pet>(Pet.Cat , 0, ItemState.Equipped));
        petData.Add(Pet.Dog , new ItemData<Pet>(Pet.Dog , 0, ItemState.Unbought));
        return petData;
    }
    public Dictionary<Board, ItemData<Board>> GenerateDefaultBoardData(){
        Dictionary<Board, ItemData<Board>> boardData = new Dictionary<Board, ItemData<Board>>();
        boardData.Add(Board.Blue , new ItemData<Board>(Board.Blue , 0, ItemState.Equipped));
        boardData.Add(Board.Magma, new ItemData<Board>(Board.Magma , 0, ItemState.Unbought));
        boardData.Add(Board.Ice , new ItemData<Board>(Board.Ice , 0, ItemState.Unbought));
        boardData.Add(Board.Lightning , new ItemData<Board>(Board.Lightning , 0, ItemState.Unbought));
        boardData.Add(Board.Rose , new ItemData<Board>(Board.Rose , 0, ItemState.Unbought));
        boardData.Add(Board.Galactic , new ItemData<Board>(Board.Galactic , 0, ItemState.Unbought));
        return boardData;
    }
    public Dictionary<Accessory, ItemData<Accessory>> GenerateDefaultAccessoryData(){
        Dictionary<Accessory, ItemData<Accessory>> accessoryData = new Dictionary<Accessory, ItemData<Accessory>>();
        return accessoryData;
    }
    public bool TryGetPetData(Pet pet, out ItemData<Pet> data){
        if (DataManager.instance.playerData.petDict.TryGetValue(pet, out ItemData<Pet> foundPet)){
            data = foundPet;
            return true;
        }
        data = new ItemData<Pet>();
        return false;
    }
    public void TryBuyPet(Pet pet){
        if (TryGetPetData(pet, out ItemData<Pet> data) && data.itemState == ItemState.Unbought){
            int coinCost = data.coinCost;
            if (DataManager.instance.playerData.coins >= coinCost){
                DataManager.instance.playerData.coins -= coinCost;
                data.itemState = ItemState.Bought;
                DataManager.instance.playerData.petDict[pet] = data;
            }
        }
    }
    public void TryEquipPet(Pet pet){
        if (TryGetPetData(pet, out ItemData<Pet> data) && data.itemState == ItemState.Bought){
            data.itemState = ItemState.Equipped;
            DataManager.instance.playerData.petDict[pet] = data;
        }
    }
    public bool TryGetBoardData(Board board, out ItemData<Board> data){
        print("boardDict: "+DataManager.instance.playerData.boardDict);
        if (DataManager.instance.playerData.boardDict.TryGetValue(board, out ItemData<Board> foundBoard)){
            data =  foundBoard;
            return true;
        }
        data = new ItemData<Board>();
        return false;
    }
    public void TryBuyBoard(Board board){
        if (TryGetBoardData(board, out ItemData<Board> data) && data.itemState == ItemState.Unbought){
            int coinCost = data.coinCost;
            if (DataManager.instance.playerData.coins >= coinCost){
                DataManager.instance.playerData.coins -= coinCost;
                data.itemState = ItemState.Bought;
                DataManager.instance.playerData.boardDict[board] = data;
            }
        }
    }
    public void TryEquipBoard(Board board){
        if (TryGetBoardData(board, out ItemData<Board> data) && data.itemState == ItemState.Bought){
            data.itemState = ItemState.Equipped;
            DataManager.instance.playerData.boardDict[board] = data;
        }
    }
    public bool TryGetAccessoryData(Accessory accessory, out ItemData<Accessory> data){
        if (DataManager.instance.playerData.accessoryDict.TryGetValue(accessory, out ItemData<Accessory> foundAccessory)){
            data = foundAccessory;
            return true;
        }
        data = new ItemData<Accessory>();
        return false;
    }
    public void TryBuyAccessory(Accessory accessory){
        if (TryGetAccessoryData(accessory, out ItemData<Accessory> data) && data.itemState == ItemState.Unbought){
            int coinCost = data.coinCost;
            if (DataManager.instance.playerData.coins >= coinCost){
                DataManager.instance.playerData.coins -= coinCost;
                data.itemState = ItemState.Bought;
                DataManager.instance.playerData.accessoryDict[accessory] = data;
            }
        }
    }
    public void TryEquipAccessory(Accessory accessory){
        if (TryGetAccessoryData(accessory, out ItemData<Accessory> data) && data.itemState == ItemState.Bought){
            data.itemState = ItemState.Equipped;
            DataManager.instance.playerData.accessoryDict[accessory] = data;
        }
    }
}

[System.Serializable]
public enum ItemState{
    Unbought,
    Bought,
    Equipped
}

[System.Serializable]
public enum Pet {
    Cat,
    Dog,
    Rabbit
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