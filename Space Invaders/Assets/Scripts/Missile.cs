using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5f;
    // Script para o script de tiro do invader, com a velocidade e se ele chegar
    // na posição -11 (fora da tela) é destruido para que não sejam gerados 
    // infinitos objetos.
    private void Update()
    {
      transform.position += transform.up * -speed * Time.deltaTime;
      if (transform.position.y <= -11){
        Destroy(gameObject);
      }
    }
    // Usando um OnTrigger para que o tiro sejá destruido ao entrar em contato com o Bunker.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bunker"))
        { 
          Destroy(gameObject);
        }
    }
}
