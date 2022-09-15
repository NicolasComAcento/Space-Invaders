using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour
{

public Text GameOver;
 private void Start()
{
  GameOver.enabled = false;
  Time.timeScale=1;
}
 public void NewGame()
 {
  if(GameOver.enabled == true && (Input.anyKeyDown))
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
 }

 // Função para que o jogo termine quando o invader chegar no chão.
 private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        { GameOver.enabled = true;
        Time.timeScale=0;
        }
    }
}
