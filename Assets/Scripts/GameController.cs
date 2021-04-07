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

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
        levelManager?.Setup();
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
}
