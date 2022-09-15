using UnityEngine;
public class Shot_Movement : MonoBehaviour
{
    float speed = 20f;
    // Como o outro script era para spawnar o projétil nesse aqui temos o movimento do mesmo
    // e ele se destruir quando estiver fora da tela ou entrar em contato com o Bunker.
    private void Update()
    {
      transform.position += transform.up * speed * Time.deltaTime;
      if (transform.position.y >= 11){
        Destroy(gameObject);
      }
    Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 0.5f, 0.9f, LayerMask.GetMask("Bunker"));
     if(box != null)
     {
      Destroy(gameObject);
     }
    }

   
  
    
}
