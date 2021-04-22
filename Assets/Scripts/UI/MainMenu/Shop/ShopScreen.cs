using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : Screen
{
    public GameObject petScrollView;
    public GameObject boardScrollView;
    public GameObject accessoryScrollView;
    public Image tabImage;
    public Sprite petTabSprite;
    public Sprite boardTabSprite;
    public Sprite accessoryTabSprite;
    public List<PetCard> petCards = new List<PetCard>();
    public List<BoardCard> boardCards = new List<BoardCard>();
    public List<AccessoryCard> accessoryCards = new List<AccessoryCard>();

    ShopTab currentTab = ShopTab.Pet;

    public override void OnEnter(){
        ReloadCurrentTab();
    }
    
    public void ExitShop(){
        ScreenManager.instance.popScreen();
    }
    public void LoadPetTab(){
        currentTab = ShopTab.Pet;
        petScrollView.SetActive(true);
        boardScrollView.SetActive(false);
        accessoryScrollView.SetActive(false);
        tabImage.sprite = petTabSprite;
        foreach(PetCard card in petCards){
            card.Setup();
        }
    }
    public void LoadBoardTab(){
        currentTab = ShopTab.Board;
        petScrollView.SetActive(false);
        boardScrollView.SetActive(true);
        accessoryScrollView.SetActive(false);
        tabImage.sprite = boardTabSprite;
        foreach(BoardCard card in boardCards){
            card.Setup();
        }
    }
    public void LoadAccessoryTab(){
        currentTab = ShopTab.Accessory;
        petScrollView.SetActive(false);
        boardScrollView.SetActive(false);
        accessoryScrollView.SetActive(true);
        tabImage.sprite = accessoryTabSprite;
        foreach(AccessoryCard card in accessoryCards){
            card.Setup();
        }
    }
    public void ReloadCurrentTab(){
        switch(currentTab){
            case ShopTab.Pet:
                LoadPetTab();
                break;
            case ShopTab.Board:
                LoadBoardTab();
                break;
            case ShopTab.Accessory:
                LoadAccessoryTab();
                break;
        }
    }
    enum ShopTab {
        Pet,
        Board,
        Accessory
    }
}
