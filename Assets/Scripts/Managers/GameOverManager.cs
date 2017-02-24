using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;


    Animator anim;

	bool gameRunning = true;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
		if (Input.GetKeyDown (KeyCode.R) && playerHealth.currentHealth <= 0) {
			playerHealth.RestartLevel ();
		}
		if (Input.GetKeyDown (KeyCode.Escape) && playerHealth.currentHealth > 0) {
			SwitchGameState ();
		}
    }

	void SwitchGameState() {
		if (gameRunning) {
			Time.timeScale = 0;
			gameRunning = false;
		} else {
			Time.timeScale = 1;
			gameRunning = true;
		}

	}

}
