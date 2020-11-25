using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreAndGameOver : MonoBehaviour
{
 
    public TMP_Text ScoreText;
    public PublicVariables Variables;
    public GameObject DeathParticle;
    public CircleCollider2D PlayerCollider;
    private float Multiplier, Score;
    private bool GameOver = false;

    private void Start()
    {
        SetScoreMultiplyer();
    }

    private void Update()
    {
        Score += Time.deltaTime * Multiplier;
        ScoreText.text = "Score: " + Mathf.Round(Score);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (GameOver == false)
            {
                Variables.SetScore(Score);
                ExplosiveDeath();
                GameOver = true;
                this.enabled = false;
                Invoke("ChangeScene", 3f);
            }

        }
    }

    private void SetScoreMultiplyer()
    {
        switch (Variables.GetDifficulty())
        {
            case 0:
                Multiplier = 0.5f;
                break;
            case 1:
                Multiplier = 1f;
                break;
            case 2:
                Multiplier = 1.5f;
                break;
        }

    }

    private void ExplosiveDeath()
    {
        PlayerCollider.enabled = false;
        float Xpos, Ypos;
        Xpos = this.transform.position.x;
        Ypos = this.transform.position.y;
        for (int i = 0; i < Variables.GetDeathParticles(); i++)
        {
            Rigidbody2D Rb;
            GameObject a = Instantiate(DeathParticle) as GameObject;
            Rb = a.GetComponent<Rigidbody2D>();
            a.transform.position = new Vector2(Xpos + Random.Range(-1, 1), Ypos + Random.Range(-1, 1));
            Rb.AddForce(new Vector2(Random.Range(-10000, 10000), Random.Range(-10000, 10000)));
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
}
