using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake: DamageObstacle{
    public Animator animator;
    //int timerMax = 30;
    public int timer = 0;

    public override void Startup(float x, float y, float newSpeed){
        base.Startup(x,y,newSpeed);
        //animator = GetComponent<Animator>();
    }
    public override void Update(){
        base.Update();
        if(active && GameController.gameRunning){
            timer++;
            animator.SetInteger("Timer", timer);
        }
    }
    public void FinishedAttacking(){
        timer = 0;
    }
}
