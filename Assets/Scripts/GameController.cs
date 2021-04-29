using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    const string BOARDPATH = "Boards/";
    const string ACCESSORYPATH = "Accessories/";
    const string MAINMENUSCENENAME = "MainMenu";

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = TARGETFRAMERATE;
        levelManager?.Setup();
        itemManager?.Setup();
        playerManager?.Setup();
        dataManager?.Setup();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != MAINMENUSCENENAME){
            PlayerSetup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (board != null && pet != null && gameRunning){
            pet.UpdatePhysics();
            board.UpdatePhysics();
        }
    }
    public void PlayerSetup(){
        BoardSetup();
        PetSetup();
        AccessorySetup();
    }
    void PetSetup(){
        Pet currentPet = ItemManager.instance.GetCurrentPet();
        LoadPet(currentPet);
    }
    public void BoardSetup(){
        Board currentBoard = ItemManager.instance.GetCurrentBoard();
        LoadBoard(currentBoard);
    }
    public void AccessorySetup(){
        List<Accessory> currentAccessories = ItemManager.instance.GetCurrentAccessories();
        LoadAccessories(currentAccessories);
    }
    void LoadPet(Pet petType){
        string petName = petType.ToString();
        print("Pet Name: " + petName); 
        GameObject petPrefab = Resources.Load<GameObject>(PETPATH+petName);
        GameObject petObject = Instantiate(petPrefab);
        pet = petObject.GetComponent<PetController>();
        board.pet = pet;
    }
    void LoadBoard(Board boardType){
        string boardName = boardType.ToString();
        print("Board Name: "+ boardName); 
        GameObject boardPrefab = Resources.Load<GameObject>(BOARDPATH + boardName);
        GameObject boardObject = Instantiate(boardPrefab);
        board = boardObject.GetComponent<BoardController>();
    }
    void LoadAccessories(List<Accessory> accessories){
        foreach(Accessory accessory in accessories){
            string accessoryName = accessory.ToString();
            GameObject accessoryPrefab = Resources.Load<GameObject>(ACCESSORYPATH + accessoryName);
            if (accessoryPrefab != null){
                GameObject accessoryObject = Instantiate(accessoryPrefab, pet.transform);
                if (accessoryObject.TryGetComponent<AccessoryObject>(out AccessoryObject accessoryScript)){
                    pet.accessories.Add(accessoryScript);
                }
            }
            
        }
    }
}
