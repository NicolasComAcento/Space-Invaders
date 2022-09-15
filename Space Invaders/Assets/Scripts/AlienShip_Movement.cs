using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip_Movement : MonoBehaviour
{
float speed = 4;
int direction = 1;
public AlienShip alienShip;

  
  private void Start()
  {
     Invoke("ChangeDirection", 5.3f);
     alienShip = FindObjectOfType<AlienShip>();
  }
  // Aqui temos o movimento da nave vermelha, que depois de spawnar se move até um canto do mapa
  // e depois volta por onde veio, para isso usei um int com a direção, que após 5.3 segundos
  // (tempo que leva para ela chegar até o canto esquerdo) é mudada, o que faz com que a nave
  // mude direção.
  private void Update()
  {
    Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 1f, 0, LayerMask.GetMask("Shot"));
    if(box != null){
      Destroy(box.gameObject);
      Destroy(gameObject);
      for(int i = 0; i < 10; i++){ 
      alienShip.SetScore();
      }
    }
    
    if(direction == 1)
    {
       transform.position += transform.right * -speed * Time.deltaTime;
    }else
    {
      transform.position += transform.right * speed * Time.deltaTime;
    }
       if (transform.position.x >= 20f)
    {
        Destroy(gameObject);
    } 
}  
 private void ChangeDirection()
 {
   direction = 2;
 }

    
  } 

