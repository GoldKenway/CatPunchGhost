using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{

	public Slider slider;

	public void SetMaxEnemy(int totalEnemies)
	{
		slider.maxValue = totalEnemies;

	}


	public void SetProgress(int EnemyKilled)
	{
		slider.value = EnemyKilled;

	}



}