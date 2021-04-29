using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Animator animator;
    public float petHeight = 0.0f;
    public BoxCollider2D myCollider;
    public float forceOfGravity = 0.08f;
    public float verticalVelocity = 0.0f;
    public bool isJumping = false;
    public List<AccessoryObject> accessories = new List<AccessoryObject>();

    const float HEADBOBHEIGHT = 2.1f;
    public Vector3 JUMPOFFSET = new Vector3(0.0f, 0.0f, 0.0f);
    const float VERTICALSPEEDTOANGLE = 100.0f;
    const int INVINCIBILITYFRAMES = 120;
    const float PETSIZEBUFFER = 0.6f;
    int health = 2;
    int framesSinceDamage = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        petHeight = myCollider.size.y * transform.localScale.y + PETSIZEBUFFER;

    }

    // Update is called once per frame
    void Update()
    {
        framesSinceDamage++;
        UpdateDamageTimer();
        UpdateAngle();
    }

    void UpdateDamageTimer(){
        animator.SetBool("DamagedRecently", framesSinceDamage <= INVINCIBILITYFRAMES);
    }
    void UpdateAngle(){
        if (isJumping){
            Vector3 oldRot = animator.transform.eulerAngles;
            animator.transform.eulerAngles = new Vector3(oldRot.x, oldRot.y, GetVelocity() * VERTICALSPEEDTOANGLE);
        }
        else {
            Vector3 oldRot = animator.transform.eulerAngles;
            animator.transform.eulerAngles = new Vector3(oldRot.x, oldRot.y, 0.0f);
        }
        //-0.3,0.3
        //-45,45
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
    public void TakeDamage(int damage){
        LevelManager.instance.timesHitOnThisLevel++;
        health -= damage;
        framesSinceDamage = 0;
        if(health <= 0){
            LoseLevel();
        }
    }
    public void SetJumping(bool petIsJumping){
        isJumping = petIsJumping;
        animator.SetBool("PetIsJumping",petIsJumping);
    }

    
    private void LoseLevel(){
        LevelManager.instance.LoseLevel();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle"){
            Obstacle obs = (Obstacle) other.gameObject.GetComponent<Obstacle>();
            if(obs != null && !obs.touched){
                obs.Touch(this);
            }
        }
    }
    public void SetHeadHeight(int stage){
        foreach(AccessoryObject accessoryObject in accessories){
            accessoryObject.SetBobPosition((float)stage * HEADBOBHEIGHT);
        }
    }
    public void SetJumpOffset(){
        foreach(AccessoryObject accessoryObject in accessories){
            accessoryObject.SetJumpOffset(JUMPOFFSET);
        }
    }
}
