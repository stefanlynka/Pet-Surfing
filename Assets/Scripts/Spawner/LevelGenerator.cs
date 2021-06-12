using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public LevelSpawner spawner;

    Level currentLevel;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        int worldNum = PlayerPrefs.GetInt("World");
        int levelNum = PlayerPrefs.GetInt("Level");
        Level level = MakeLevel(worldNum, levelNum);
        if (level != null){
            LevelManager.instance.currentLevel = level;
            spawner?.SpawnLevel(level);
        }
        
    }

    Level MakeLevel(int world, int level){
        switch (world){
            case 1:
            switch(level){
                case 1:
                return MakeLevel1();
                case 2:
                return MakeLevel2();
                case 3:
                return MakeLevel3();
                case 4:
                return MakeLevel4();
                case 5:
                return MakeLevel5();
                case 6:
                return MakeLevel6();
                case 7:
                return MakeLevel7();
                case 8:
                return MakeLevel8();
            }
            break;
            case 2:
            break;
        }
        return null;
    }




    Level MakeLevel1(){
        Level newLevel = new Level(0.08f);

        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        //newLevel.AddObstacle(15, 3, typeof(Cactus));
        newLevel.AddObstacle(15, 2, typeof(MeteorBig));
        newLevel.AddObstacle(15, 5, typeof(MeteorSmall));
        /*
        newLevel.AddObstacle(20, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(24, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(28, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(44, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(48, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(52, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(56, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(60, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(76, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(77, 2, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(78, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(79, 4, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(80, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(81, 6, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(82, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(90, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        */
        return newLevel;
    }
    Level MakeLevel2(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevel3(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevel4(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevel5(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevel6(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevel7(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevel8(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }
        
        return newLevel;
    }
    Level MakeLevelDefault(){
        Level newLevel = new Level(0.04f);
        
        for(int i =0; i< 10; i++){
            newLevel.AddObstacle(20, i, typeof(Coin));
        }

        return newLevel;
    }

/*
    Level MakeLevel2(){
        Level newLevel = new Level(200, 0.1f);


        newLevel.AddObstacle(30, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(31, 4, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(32, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(34, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(76, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(77, 2, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(78, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(79, 4, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(80, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(81, 6, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(82, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(109, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(110, 6, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(111, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(112, 6, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(113, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(139, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(140, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(141, 9, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(142, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(143, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });



        newLevel.AddObstacle(170, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }


    Level MakeLevel3(){
        Level newLevel = new Level(200, 0.1f);


        newLevel.AddObstacle(30, 3, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });



        newLevel.AddObstacle(60, 2, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(60, 5, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(90, 1, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(90, 4, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(90, 2, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(90, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(120, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(120, 2, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(120, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(135, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(135, 4, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(135, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(150, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(150, 2, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(150, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(175, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });

        return newLevel;
    }
    
    Level MakeLevel4(){
        Level newLevel = new Level(200, 0.1f);


        newLevel.AddObstacle(30, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(32, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(34, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(60, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(62, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(64, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(62, 4, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(62, 5, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(90, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(92, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(94, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(92, 1, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(92, 2, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(92, 3, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(92, 4, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(92, 5, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(122, 10, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(122, 9, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(122, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(122, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(122, 6, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(152, 10, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 9, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 6, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 5, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 4, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 3, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 2, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(152, 1, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(180, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }
    Level MakeLevel5(){
        Level newLevel = new Level(200, 0.1f);

        //middle block
        if(true){
            newLevel.AddObstacle(30, 4, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
            });
            newLevel.AddObstacle(32, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(34, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(36, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(38, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(40, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(42, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(44, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(46, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(48, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(50, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(52, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(54, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(56, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(58, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(60, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(62, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(64, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(66, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(68, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(70, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(72, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(74, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(76, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(78, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(80, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(82, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(84, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(86, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(88, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(90, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(92, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(94, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(96, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(98, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(100, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(102, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(104, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(106, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(108, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(110, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(112, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(114, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(116, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(118, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(120, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(122, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(124, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(126, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(128, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(130, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(132, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(134, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(136, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(138, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(140, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(144, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(146, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(148, 4, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });

        }

        //high path
        if(true){
            newLevel.AddObstacle(34, 7, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(34, 6, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(34, 5, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });


            newLevel.AddObstacle(56, 5, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(54, 5, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(55, 6, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(55, 7, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(54, 8, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(56, 8, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });

            

            newLevel.AddObstacle(72, 5, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(72, 6, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });


            newLevel.AddObstacle(92, 5, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(92, 6, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(92, 7, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            

            newLevel.AddObstacle(102, 5, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(102, 6, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(102, 7, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });

            newLevel.AddObstacle(122, 5, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(122, 6, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(122, 7, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(122, 8, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });

            newLevel.AddObstacle(142, 5, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 6, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 7, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 8, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 9, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 10, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
        }
        
        //low path
        if (true){
            newLevel.AddObstacle(34, 2, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
            });
            newLevel.AddObstacle(64, 1, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(64, 2, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(64, 3, () => {
                Coin obs = (Coin)GenerateObstacle(typeof(Coin));
                obs?.Setup();
                return obs;
            });

            newLevel.AddObstacle(82, 1, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(90, 3, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(98, 1, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });


            newLevel.AddObstacle(110, 0, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(110, 1, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(118, 2, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(118, 3, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(124, 0, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(124, 1, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });

            newLevel.AddObstacle(134, 0, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(134, 2, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 1, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(142, 3, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(150, 0, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
            newLevel.AddObstacle(150, 1, () => {
                Rock obs = (Rock)GenerateObstacle(typeof(Rock));
                obs?.Setup();
                return obs;
            });
        }
        

        


        

        

        newLevel.AddObstacle(170, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }
    Level MakeLevel6(){
        Level newLevel = new Level(200, 0.1f);


        newLevel.AddObstacle(50, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }
    Level MakeLevel7(){
        Level newLevel = new Level(200, 0.1f);


        newLevel.AddObstacle(50, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }
    Level MakeLevel8(){
        Level newLevel = new Level(200, 0.1f);


        newLevel.AddObstacle(50, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }

    */
}



