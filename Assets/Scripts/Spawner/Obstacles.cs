using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            transform.Translate(new Vector3(-levelSpeed, 0.0f, 0.0f));
        }
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
public class Rock: Obstacle{
    int damage = 1;
    public override void Touch(PetController pet){
        base.Touch(pet);
        pet.TakeDamage(damage);
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