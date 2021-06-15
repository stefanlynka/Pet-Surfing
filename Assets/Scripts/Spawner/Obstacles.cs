using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public abstract class Obstacle : MonoBehaviour{
    public bool touched = false;
    public static float obstacleZ = 0.0f;

    protected Vector3 collisionPosition = new Vector3(0.0f,0.0f,obstacleZ);
    protected float levelSpeed = 0.0f;
    protected bool active = false;
    protected string prefabPath = "Obstacles/";

    public virtual void Update()
    {
        if(active && GameController.gameRunning){
            //transform.Translate(new Vector3(-levelSpeed, 0.0f, 0.0f));
            ShiftX(-levelSpeed);
        }
    }
    protected void ShiftX(float x){
        Vector3 oldPos = transform.localPosition;
        oldPos.x += x;
        transform.localPosition = oldPos;
    }
    //public virtual void Setup(){}
    public virtual void Startup(float x, float y, float newSpeed){
        levelSpeed = newSpeed;
        SetPosition(x, y);
        collisionPosition = new Vector3(x, y, obstacleZ);
        active = true;
    }
    public void SetPosition(float x, float y){
        transform.position = new Vector3(x,y,obstacleZ);
    }
    public void SetCollisionPosition(float x, float y){
        collisionPosition = new Vector3(x,y,obstacleZ);
    }
    public virtual void Touch(PetController pet){
        touched = true;
    }
}






public class Coin: Obstacle{
    int coinValue = 1;
    public override void Touch(PetController pet){
        if (!touched){
            LevelManager.instance.CollectCoins(coinValue);
        }
        base.Touch(pet);
        Destroy(gameObject);
    }
}
public class DamageObstacle : Obstacle{
    protected int damage = 1;
    public override void Touch(PetController pet){
        base.Touch(pet);
        pet.TakeDamage(damage);
    }
}
public class Rock: DamageObstacle{
}
public class Shark: DamageObstacle{
}
public class Cactus: DamageObstacle{
}
public class Seagull: DamageObstacle{
    //Faster to left
    float speed = 0.05f;
    public override void Update(){
        base.Update();
        if(active && GameController.gameRunning){
            Vector3 oldPos = transform.localPosition;
            oldPos.x -= speed;
            transform.localPosition = oldPos;
        }
    }
    public override void Startup(float x, float y, float newSpeed){
        base.Startup(x, y, newSpeed);
        float distance = (x * (levelSpeed + speed))/levelSpeed;
        ShiftX(distance - x);
    }
}

public class FieryBat: DamageObstacle{
    // Left and right
    float leftSpeed = -0.01f;
    float rightSpeed = 0.13f;
    bool movingLeft = true;
    int switchTimer = 0;
    int timerMax = 60;
    public override void Update(){
        base.Update();
        if(active && GameController.gameRunning){
            switchTimer++;
            if (switchTimer >= timerMax){
                switchTimer = 0;
                movingLeft = !movingLeft;
            }
            Vector3 oldPos = transform.localPosition;
            oldPos.x += movingLeft ? leftSpeed : rightSpeed;
            transform.localPosition = oldPos;
        }
    }
}
public class Vulture: DamageObstacle{
    // Up and down
    float upSpeed = 0.04f;
    float downSpeed = -0.04f;
    bool movingUp = true;
    int switchTimer = 0;
    int timerMax = 60;
    public override void Update(){
        base.Update();
        if(active && GameController.gameRunning){
            switchTimer++;
            if (switchTimer >= timerMax){
                switchTimer = 0;
                movingUp = !movingUp;
            }
            Vector3 oldPos = transform.localPosition;
            oldPos.y += movingUp ? upSpeed : downSpeed;
            transform.localPosition = oldPos;
        }
    }
}


public class Meteor: DamageObstacle{
    protected List<Sprite> sprites = new List<Sprite>();
    float rotationSpeed = 1.0f;
    protected const string SPRITEFOLDER = "Assets/Resources/Obstacles/Sprites/";
    const string DEFAULTSUBFOLDER = "BigMeteor";
    public override void Startup(float x, float y, float newSpeed){
        base.Startup(x,y,newSpeed);
        rotationSpeed -= 2 * rotationSpeed * Random.Range(0,2);
        //GetSprites(DEFAULTSUBFOLDER);
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer renderer)){
            renderer.sprite = GetRandomSprite();
        }
    }
    public virtual void GetSprites(string subFolder){
        //Sprite mySprite = Resources.Load<Sprite>("meteorGrey_big1");
        foreach (string file in System.IO.Directory.GetFiles(SPRITEFOLDER+subFolder)){
            string resourceFile = file.Replace("Assets/Resources/","");
            resourceFile = resourceFile.Replace(@"\","/");
            resourceFile = resourceFile.Replace(".png","");
            Sprite newSprite = Resources.Load<Sprite>(resourceFile);
            if(newSprite != null){
                sprites.Add(newSprite);
            }
        }
    }
    Sprite GetRandomSprite(){
        int randInt = Random.Range(0,sprites.Count);
        if (sprites[randInt] != null){
            return sprites[randInt];
        }
        return null;
    }
    public override void Update(){
        Rotate();
        base.Update();
        //transform.RotateAroundLocal() (new Vector3(0.0f, 0.0f, rotationSpeed));
    }
    void Rotate(){
        Vector3 currentRot = transform.localEulerAngles;
        currentRot.z += rotationSpeed;
        transform.localEulerAngles = currentRot;
        //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90.0f);
    }
}
public class MeteorBig: Meteor{
    const string SUBFOLDER = "MeteorBig";
    public override void Startup(float x, float y, float newSpeed){
        GetSprites(SUBFOLDER);
        base.Startup(x,y,newSpeed);
    }
}
public class MeteorSmall: Meteor{
    const string SUBFOLDER = "MeteorSmall";
    public override void Startup(float x, float y, float newSpeed){
        GetSprites(SUBFOLDER);
        base.Startup(x,y,newSpeed);
    }
}
public class LevelEnd: Obstacle{
    public override void Touch(PetController pet){
        if (!touched){
            LevelManager.instance.FinishLevel();
        }
        base.Touch(pet);
    }
}
public class Beach: LevelEnd{
    public float xOffset = 15.0f;
    public float yOffset = 5.88f;
    public override void Startup(float x, float y, float newSpeed){
        base.Startup(x,y,newSpeed);
        SetPosition(x+xOffset, y+yOffset);
    }
    public override void Touch(PetController pet){
        base.Touch(pet);
    }
}