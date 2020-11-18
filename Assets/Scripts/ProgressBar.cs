using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
	public Transform Boss;
	public int EnemiesKilled;
	private int EnemyTotal = 10;

	public Slider slider;

	public void SetMaxEnemy(int totalEnemies)
	{
		slider.maxValue = totalEnemies;

	}

	void Start()
	{
		SetMaxEnemy(EnemyTotal);
	}

	public void SetProgress(int EnemiesKilled)
	{
		slider.value = EnemiesKilled;
		if (EnemiesKilled >= EnemyTotal)
		{
			Instantiate(Boss, Boss.position, Boss.rotation);

		}

	}

	public int GetProgress()
	{

		return EnemiesKilled;

	}



}