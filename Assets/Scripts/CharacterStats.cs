using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{

	public Text Health;

	public Text Charge;

	public Text Lives;

	private int playerHealth = 500;

	private int chargeCount = 3;

	private int lifeCount = 0;

	public PlayerMovement player;

	GameObject healthPoints; 




	public void GameOver()
	{

		//plays gameover screen


	}

	public void characterHit(int hitPoints)
    {
		Debug.Log("Player hit.");
		playerHealth -= hitPoints;
		Health.text = playerHealth + "";
		player.animator.SetBool("isHit", true);
		if (playerHealth <= 0)
        {
			playerHealth = 0;
			player.animator.SetBool("isDead", true);
			//characterDeath(lifeCount);
        }

	}

	public void characterDeath(int lives)
	{
		//checks if player has no lives 

		if (lives <= 0)
		{
			GameOver();

		}

		revive(lives);

	}

	private void revive(int lives)
	{
		lives--;
		//revive the player 


	}

	void Update()
	{
		//Debug.Log("Update is called.");
		//Debug.Log(playerHealth);
		Charge.text = chargeCount + "";
		Lives.text = lifeCount + "";

	}

	void afterHit()
    {
		player.animator.SetBool("isHit", false);
    }

    private void Start()
    {
		playerHealth = 500;
		Health.text = playerHealth + "";
		healthPoints = GameObject.FindGameObjectWithTag("CharacterStats");
		Health = healthPoints.GetComponent<Text>();
		

    }

}