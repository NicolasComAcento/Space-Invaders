using UnityEngine;

public class Wall : MonoBehaviour
{
   // Script para que quando o jogador vá até uma das extremidades ele seja teleportado
   // para a outra, não existia essa função no jogo original mas achei legal colocar.
   public Transform conexao;
   private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = other.transform.position;
        position.x = this.conexao.position.x;
        position.y = this.conexao.position.y;

        other.transform.position = position;
    }
}
