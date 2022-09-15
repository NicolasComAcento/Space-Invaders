using UnityEngine.UI;
using UnityEngine;

public class AlienShip : MonoBehaviour
{
   public Text scoreText;
   public int score = 0;
   public GameObject alienShip;
   public float speed = 2f;
   // Essas 3 variáveis são para gerenciar o tempo de Spawn da nave vermelha.
   public float instantiateTime = 0f;
   public float interval = 10f;
   public float variation = 0.5f;
   public bool stopSpawn = false;


   private void Update()
   {
   // Aqui temos a condição dentro do Update para ver se a Nave pode spawnar
   // dentro do if tem as cordenadas que a nave pode spawnar e depois o tempo
   // para o spawn que pode variar.
   if(Time.time > instantiateTime && !stopSpawn)
   {
        GameObject obj = Instantiate(alienShip , new Vector3(12, 8.8f, 0),Quaternion.identity);
        instantiateTime = Time.time + Random.Range(interval - variation, interval + variation);
   }

   }
   public void SetScore()
    {
    // Defini o aumento do score aqui, eu ia fazer um GameManager pra deixar mais
    // organizado mas não ia ter muita coisa nele então fiz por aqui mesmo.
      score += 20;
      scoreText.text = score.ToString().PadLeft(2, '0');
    }
}
