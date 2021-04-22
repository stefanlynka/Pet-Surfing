using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public PlayerData playerData;
    

    string playerDataPath;
    string levelDataPath;
    const string PLAYERDATAFILENAME = "PlayerData.txt";


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

        playerDataPath = Path.Combine(Application.persistentDataPath, PLAYERDATAFILENAME);
        print("DataManager Setup");
        if (!TryLoadPlayerData(out playerData)){
            playerData = PlayerManager.instance.MakeNewPlayerData();
            playerData.levelDict = LevelManager.instance.GenerateDefaultLevelData();
            playerData.petDict = ItemManager.instance.GenerateDefaultPetData();
            playerData.boardDict = ItemManager.instance.GenerateDefaultBoardData();
            playerData.accessoryDict = ItemManager.instance.GenerateDefaultAccessoryData();
            SavePlayerData();
        }
    }


    public void ChangeCoinCount(int coinCount){
        playerData.coins += coinCount;
        SavePlayerData();
    }
    public bool TryGetLevel(int worldNum, int levelNum, out LevelData levelData){
        if (playerData.levelDict.ContainsKey((worldNum, levelNum))){
            levelData = playerData.levelDict[(worldNum, levelNum)];
            return true;
        }
        Debug.LogWarning($"DataManager.cs: World {worldNum} Level {levelNum} not found");
        levelData = new LevelData();
        return false;
    }
    public bool HasLevel(int worldNum, int levelNum){
        return playerData.levelDict.ContainsKey((worldNum, levelNum));
    }
    public void SetLevelData(int worldNum, int levelNum, LevelData newData){
        if (playerData.levelDict.ContainsKey((worldNum, levelNum))){
            playerData.levelDict[(worldNum, levelNum)] = newData;
        }
        else {
            playerData.levelDict.Add((worldNum, levelNum), newData);
        }
    }
    public void SavePlayerData(){
        SaveData(playerDataPath, playerData);
    }
    public bool TryLoadPlayerData(out PlayerData outputData) {
        outputData = LoadData<PlayerData>(playerDataPath);
        return outputData != null;
    }
    void SaveData<T>(string path, T data){
        using (Stream stream = File.OpenWrite(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }
    static T LoadData<T>(string path) where T : class{
        if (!File.Exists(path)){
            return null;
        }

        using (Stream stream = File.OpenRead(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object loadedObject = formatter.Deserialize(stream);
            if (loadedObject is T){
                return loadedObject as T;
            }
            else {
                return null;
            }
        }
    }
}


[System.Serializable]
public class PlayerData{
    public int coins = 0;
    public Pet currentPet;
    public Dictionary<(int,int),LevelData> levelDict = new Dictionary<(int, int), LevelData>();
    public Dictionary<Pet, ItemData<Pet>> petDict = new Dictionary<Pet, ItemData<Pet>>();
    public Dictionary<Board, ItemData<Board>> boardDict = new Dictionary<Board, ItemData<Board>>();
    public Dictionary<Accessory, ItemData<Accessory>> accessoryDict = new Dictionary<Accessory, ItemData<Accessory>>();
}

[System.Serializable]
public struct ItemData<T> {
    public T item;
    public int coinCost;
    public ItemState itemState;
    public ItemData(T item, int coinCost, ItemState itemState){
        this.item = item;
        this.coinCost = coinCost;
        this.itemState = itemState;
    }
}


[System.Serializable]
public struct LevelData{
    public int world;
    public int level;
    public bool unlocked;
    public bool beat;
    public int stars;
    public LevelData(int worldNum, int levelNum, bool isUnlocked){
        world = worldNum;
        level = levelNum;
        unlocked = isUnlocked;
        beat = false;
        stars = 0;
    }
}