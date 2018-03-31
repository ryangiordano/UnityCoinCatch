using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coin_Catch.Assets.Scripts.utility
{
    public enum LaunchType
    {
        Coin,
        Bomb,
        JuggleCoin
    }
    public abstract class Launchable
    {
        public LaunchType LaunchType;
        public int Score{get;set;}
        public float Intensity;
        public float Angle;
        public Vector3 LaunchPoint{get;set;}

        public Launchable(int score, Vector3 launchPoint)
        {
            this.Score = score;
            this.LaunchPoint = launchPoint;
        }
    }
    public class Coin : Launchable{
        public Coin(int score, Vector3 launchPoint):base(score, launchPoint){
            this.LaunchType = LaunchType.Coin;
        }
    }
    public class Bomb : Launchable{
        public Bomb(int score, Vector3 launchPoint): base(score, launchPoint){
            this.LaunchType = LaunchType.Bomb;
        }
    }
    public abstract class LaunchFactory<T> where T: Launchable{
        public abstract T CreateLaunchable(int score, Vector3 launchPoint);
    }

    public class CoinFactory : LaunchFactory<Coin>
    {
        public override Coin CreateLaunchable(int score, Vector3 launchPoint)
        {
            if(launchPoint == null){
               launchPoint = new Vector3(0,0,0);
            }
            return new Coin(score, launchPoint);
            

        }
    }
    public class BombFactory : LaunchFactory<Bomb>
    {
        public override Bomb CreateLaunchable(int score, Vector3 launchPoint)
        {

            return new Bomb(score, launchPoint);
        }
    }
}