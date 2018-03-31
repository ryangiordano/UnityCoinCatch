using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Coin_Catch.Assets.Scripts.utility;

public class LaunchableTests {
	[Test]
	public void CreatesLaunchableOfCorrectType() {
		var launchPoint = new Vector3(0,0,0);
		var coinFactory = new CoinFactory();
		var bombFactory = new BombFactory();
		var bomb = bombFactory.CreateLaunchable(100,launchPoint);
		var coin = coinFactory.CreateLaunchable(100,launchPoint);
		Assert.AreEqual(LaunchType.Bomb, bomb.LaunchType);
		Assert.AreEqual(LaunchType.Coin, coin.LaunchType);
		// Use the Assert class to test conditions.
	}


}
