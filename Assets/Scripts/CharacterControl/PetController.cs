using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public float petHeight = 0.0f;
    public BoxCollider2D myCollider;
    public float forceOfGravity = 0.08f;
    public float verticalVelocity = 0.0f;
    public int collectedCoins = 0;
    private int health = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        petHeight = myCollider.size.y * transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePhysics(){
        ApplyGravity();
        ApplyMovement();
    }

    void ApplyGravity(){
        verticalVelocity -= forceOfGravity;
    }
    void ApplyMovement(){ 
        float newHeight = Mathf.Min(transform.position.y + verticalVelocity, GameController.SCREENHEIGHT);
        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }

    public float GetBottomPos(){
        return transform.position.y - petHeight/2;
    }
    public void SetHeightFromBottom(float bottomHeight){
        transform.position = new Vector3(transform.position.x, bottomHeight+petHeight/2, transform.position.z);
    }
    public void SetVelocity(float newVel){
        verticalVelocity = newVel;
    }
    public float GetVelocity(){
        return verticalVelocity;
    }
    public void CollectCoins(int coinCount){
        collectedCoins += coinCount;
        //PlayerManager.AddCoins()
    }
    public void TakeDamage(int damage){
        LevelManager.instance.timesHitOnThisLevel++;
        health -= damage;
        if(health <= 0){
            LoseLevel();
        }
    }
    private void LoseLevel(){
        LevelManager.instance.LoseLevel();
        print("Level Lost");
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle"){
            Obstacle obs = (Obstacle) other.gameObject.GetComponent<Obstacle>();
            if(obs != null && !obs.touched){
                obs.Touch(this);
            }
        }
    }
}
