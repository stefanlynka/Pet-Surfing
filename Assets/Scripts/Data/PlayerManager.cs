using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public void Setup(){
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public PlayerData MakeNewPlayerData(){
        PlayerData playerData = new PlayerData();
        return playerData;
    }

    public void AddCoins(int coinChange){
        DataManager.instance.playerData.coins += coinChange;
        DataManager.instance.SavePlayerData();
    }
    public int GetPlayerCoins(){
        return DataManager.instance.playerData.coins;
    }
}

