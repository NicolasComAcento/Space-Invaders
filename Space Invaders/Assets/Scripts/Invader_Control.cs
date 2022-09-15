using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Invader_Control : MonoBehaviour
{
 // Aqui tem a maior parte do código do invader, como o ataque e a movimentação entre as fileiras.
 public float speed = 5.0f;
 private Vector3 direction = Vector2.right;
 public float shotChance = 0.9f;
 public float attackRate = 3.0f;
 public Text winText;
 public GameObject missile;
 
 
 private void Start()
 {
   InvokeRepeating(nameof(MissileAttack), 2.5f, 2.5f);
   winText.enabled = false;
   Time.timeScale=1;
 }
 private void Update()
 {
   WinState();
//Aqui eu estava com dificuldade sobre como implementar para eles descerem as fileiras
// então fui procurar alguns guias pra ter umas ideias e acabei usando essa, onde é
// usado as Camera para ter como base a borda direita e esquerda, foi a parte do código
// que mais usei de um guia.
    this.transform.position += direction * this.speed * Time.deltaTime;
    Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
    Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

    foreach(Transform invader in this.transform)
    {
        if (!invader.gameObject.activeInHierarchy)
        {   
            continue;
        }
        if (direction == Vector3.right && invader.position.x >= (rightEdge.x -1.0f) )
        {
           Advance();
        }else if(direction == Vector3.left && invader.position.x <= (leftEdge.x + 1.0f)){
           Advance(); 
        }
    }
 }
 private void Advance()
 {
    direction.x *= -1.0f;

    Vector3 position = this.transform.position;
    position.y -= 1.0f;
    this.transform.position = position;
 }


// Essa é a função do ataque dos invaders, onde é chamado um valor aleátorio que tem
// que ser maior que a shotChance definida, isso faz com que eles atirem em um padrão
// aleátorio já que cada um roda esse teste separadamente.
// Além disso cada vez que a função de ataque é chamada (por meio de um InvokeRepeting no Start)
// a velocidade deles aumenta.
 private void MissileAttack()
   {
      foreach (Transform invader in transform)
      {
         if (!invader.gameObject.activeInHierarchy )
         {
            continue;
         }
         if(Random.value > shotChance )
         {
            Instantiate(missile, invader.position, Quaternion.identity);
         }
      }
      speed += 0.1f;
   }

// Aqui é feita a verificação da existência de algum invader ainda vivo
// se não tiver nenhum vivo o WinState é chamado pela função de Update.
   private void WinState()
   {
      if(GameObject.FindGameObjectsWithTag("Invader").Length == 0)
      { 
         winText.enabled = true;
         Time.timeScale=0;
         if((Input.anyKeyDown))
         {   
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         }
      }     
   }
}


