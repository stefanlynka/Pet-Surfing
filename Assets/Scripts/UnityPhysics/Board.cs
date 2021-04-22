using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Board : MonoBehaviour
{
    public BoxCollider2D myCollider;
    public Pet pet;
    public Rigidbody2D petRigidBody;
    public Rigidbody2D boardRigidBody;


    const string petTag = "Pet";
    const float buffer = 0.4f;
    const float speedToForceRatio = 250.0f;
    const float surfBoardMaxHeight = 6.0f;
    const float surfBoardMinHeight = 0.0f;


    float previousHeight = 0.0f;
    float maxMomentum = 600.0f;
    float currentMomentum = 0.0f;
    float boardHeight = 0.0f;





    void Awake()
    {
        boardHeight = myCollider.size.y * transform.localScale.y;
        if (pet.TryGetComponent(out Rigidbody2D body)){
            petRigidBody = body;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdateMomentum();
        UpdatePetPosition();
    }






    void UpdatePosition(){
        float newHeight = Mathf.Min(GetMouseHeight(), surfBoardMaxHeight);
        newHeight = Mathf.Max(newHeight, surfBoardMinHeight);
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }
    void UpdateMomentum(){
        currentMomentum = transform.position.y - previousHeight;
        previousHeight = transform.position.y;
    }
    void UpdatePetPosition(){
        if (pet != null && pet.GetBottomPos() < GetBoardTop()-buffer){
            //print("reset pet position");
            pet.SetHeightFromBottom(GetBoardTop());
            petRigidBody.velocity = new Vector2(0.0f, Mathf.Max(0.0f,petRigidBody.velocity.y));
        }
        AddForceToPet();
    }

    void AddForceToPet(){
        if (IsPetOnBoard()){
            float force = Mathf.Max(0.0f,currentMomentum * speedToForceRatio);
            force = Mathf.Min(force, maxMomentum);
            petRigidBody.AddForce(new Vector2(0.0f, force), ForceMode2D.Force);
            //print("force: "+force);
        }
    }
    float GetBoardTop(){
        return transform.position.y + boardHeight/2;
    }
    float GetMouseHeight(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos.y;
    }
    bool IsPetOnBoard(){
        return Vector3.Distance(transform.position, pet.transform.position) < (boardHeight/2 + pet.petHeight/2 + buffer);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == petTag){
            //print("enter collision");
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        //print("collision");
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == petTag){
            //print("exit collision");
        }
    }
}
*/