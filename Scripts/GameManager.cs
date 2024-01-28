
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public float respawnTime = 3.0f;
    public int lives = 3;

    public int score = 0;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        if (asteroid.size < 0.75f) {
            this.score += 100;
        }  else if (asteroid.size < 1.0f) {
            this.score += 50;
        } else {
            this.score += 25;
        }
    }

    public void PlayerDied()
    {
        this.lives--;

        if (this.lives < 0){
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }
        
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.SetActive(true);
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);

    }

}
