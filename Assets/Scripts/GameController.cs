using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float SCREENHEIGHT = 10.0f;

    public static bool gameRunning = false;
    public BoardController board;
    public PetController pet;

    public LevelManager levelManager;
    public DataManager dataManager;
    public PlayerManager playerManager;
    public ItemManager itemManager;

    public const int TARGETFRAMERATE = 60;
    const string PETPATH = "Pets/";

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = TARGETFRAMERATE;
        levelManager?.Setup();
        itemManager?.Setup();
        playerManager?.Setup();
        dataManager?.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (board != null && pet != null && gameRunning){
            pet.UpdatePhysics();
            board.UpdatePhysics();
        }
    }
    void LoadPet(){
        switch(dataManager.playerData.currentPet){
            case Pet.Cat:
                LoadPet("Cat");
                break;
            case Pet.Dog:
                LoadPet("Dog");
                break;
            default:
                LoadPet("Cat");
                break;
        }
    }
    void LoadPet(string petName){
        GameObject petPrefab = Resources.Load<GameObject>(PETPATH+petName);
        GameObject petObject = Instantiate(petPrefab);
        pet = petObject.GetComponent<PetController>();
        board.pet = pet;
    }
}
