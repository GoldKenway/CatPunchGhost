using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{

	public int EnemiesKilled;


	public Slider slider;

	public void SetMaxEnemy(int totalEnemies)
	{
		slider.maxValue = totalEnemies;

	}


	public void SetProgress(int EnemiesKilled)
	{
		slider.value = EnemiesKilled;

	}

	public int GetProgress()
	{

		return EnemiesKilled;

	}



}