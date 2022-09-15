using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
public float speed = 1.0f;
public Text GameOver;

public AudioSource Music;

private void Start()
{
  GameOver.enabled = false;
  Time.timeScale=1;
  Music.Play();
}

private void Update()
 {
  // Inputs de movimento e a função de NewGame, que tira os textos da tela e
  // reseta a cena.
    NewGame();
    if(Input.GetKey(KeyCode.A))
   {
    transform.position += transform.right * -speed * Time.deltaTime;
   } else if(Input.GetKey(KeyCode.D)){ 

    transform.position += transform.right * speed * Time.deltaTime;
   }
 }
 public void NewGame()
 {
  if(GameOver.enabled == true && (Input.anyKeyDown))
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Music.Play();
  }
 }

 // Usando novamente um OnTrigger para que o tank morra ao entrar em contato
 // com o invader ou o míssil.
 private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        { 
        GameOver.enabled = true;
        Time.timeScale=0;
        Music.Stop();
        }
    }
}
