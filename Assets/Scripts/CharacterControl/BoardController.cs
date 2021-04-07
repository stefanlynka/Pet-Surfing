using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    public BoxCollider2D myCollider;
    public PetController pet;



    const string PETTAG = "Pet";
    const float BUFFER = 0.2f;
    const float BOARDMAXHEIGHT = 5.0f;
    const float BOARDMINHEIGHT = 0.0f;
    const float MAXVELOCITY = 0.4f;
    const float MINVELOCITYFORLAUNCH = 0.0f; //0.1f;
    const float SLOWDESCENTSPEED = -0.3f;
    public float SPEEDMULTIPLIER = 1.5f;
    
    //Pet Force Equation
    // Y = ax + b*((x*c)^2)
    // newForce = 0.7f*newForce - 0.08f*Mathf.Pow((newForce*2), 2);
    //const float PETFORCEA = 0.7f;
    //const float PETFORCEB = 0.08f;
    //const float PETFORCEC = 2.0f;

    //0.35*(x*0.75) - 0.08(x*0.75)^2
    // newForce = 0.35f*(newForce*0.75) - 0.08f*Mathf.Pow((newForce*0.75), 2);
    const float PETFORCEA = 0.35f;
    const float PETFORCEB = 0.08f;
    const float PETFORCEC = 0.75f;




    float previousHeight = 0.0f;
    float currentSpeed = 0.0f;
    float boardHeight = 0.0f;
    bool petOnBoard = false;




    float bestSpeed = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //SPEEDMULTIPLIER = DebugValueChanger.value;
    }



    void AddForceToPet(){
        float newForce = GetForceToPet();
        if (IsPetOnBoard() && newForce > MINVELOCITYFORLAUNCH){
            float newSpeed = Mathf.Min(newForce, MAXVELOCITY);
            SetPetVelocity(newSpeed);
        }
    }
    float GetForceToPet(){
        float newForce = currentSpeed * SPEEDMULTIPLIER;
        //newForce = 0.9f*newForce - 0.455f*Mathf.Pow(newForce, 2);
        // Y = ax + b*((x*c)^2)
        //newForce = 0.35f*(newForce*0.75) - 0.08f*Mathf.Pow((newForce*0.75), 2);
        // Y = a(x*c) + b*((x*c)^2)
        //newForce = PETFORCEA*(newForce*PETFORCEC) - PETFORCEB*Mathf.Pow((newForce*PETFORCEC), 2);
        newForce = Mathf.Pow(newForce * 0.1f,0.5f);
        return newForce;
    }

    public void UpdatePhysics(){
        UpdatePosition();
        UpdateMomentum();
        UpdatePetPosition();
    }

    void UpdatePosition(){
        float newHeight = Mathf.Min(GetMouseHeight(), BOARDMAXHEIGHT);
        newHeight = Mathf.Max(newHeight, BOARDMINHEIGHT);
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }
    void UpdateMomentum(){
        currentSpeed = GetMouseHeight() - previousHeight;
        if (currentSpeed > bestSpeed) bestSpeed = currentSpeed;
        previousHeight = GetMouseHeight();
    }
    void OnMouseDown()
    {
    }
    void UpdatePetPosition(){
        if (pet != null){
            if (petOnBoard && currentSpeed <=0 && currentSpeed >= SLOWDESCENTSPEED){
                PutPetOnBoard();
            }
            else {
                petOnBoard = false;
                if (pet.GetBottomPos() < GetBoardTop()){
                    PutPetOnBoard();
                    AddForceToPet();
                }
            }
        }
    }
    void PutPetOnBoard(){
        petOnBoard = true;
        pet.SetHeightFromBottom(GetBoardTop());
        AddForceToPet();
    }


    float GetBoardTop(){
        return transform.position.y + boardHeight/2;
    }
    float GetMouseHeight(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos.y;
    }
    bool IsPetOnBoard(){
        return Vector3.Distance(transform.position, pet.transform.position) < (boardHeight/2 + pet.petHeight/2 + BUFFER);
    }

    void SetPetVelocity(float newSpeed){
        if ((newSpeed >0 && newSpeed > pet.GetVelocity()) ||
        (newSpeed <0 && newSpeed < pet.GetVelocity())){
            pet.SetVelocity(newSpeed);
        }
    }

}
