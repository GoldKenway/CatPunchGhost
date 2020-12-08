using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
	public Transform Boss;
	public int EnemiesKilled;
	public int EnemyTotal = 9;

	public int CalltoGlobal;

	public Slider slider;

	public void SetMaxEnemy(int totalEnemies)
	{
		slider.maxValue = totalEnemies;
	}

	void Start()
	{
		SetMaxEnemy(EnemyTotal);
		CalltoGlobal = EndCard.OverallDead;
	}

	public void SetProgress(int EnemiesKilled)
	{
		slider.value = EnemiesKilled;
		if (EnemiesKilled == EnemyTotal)
		{
			Instantiate(Boss, Boss.position, Boss.rotation);

		}

		CalltoGlobal = CalltoGlobal + EnemiesKilled;

	}

	public int GetProgress()
	{

		return EnemiesKilled;

	}



}