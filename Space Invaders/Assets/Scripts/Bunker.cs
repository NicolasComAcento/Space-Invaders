using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    // Código só para fazer o Bunker sumir quando o invader entrar em contato
    // no começo ia fazer a parte do Bunker se desgastar aqui, mas achei muito
    // complicado a lógica para desenvolver por mim mesmo então decidi não colocar.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        { 
          Destroy(gameObject);
        }
    }
}