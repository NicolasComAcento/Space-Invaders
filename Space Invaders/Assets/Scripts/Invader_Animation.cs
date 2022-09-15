
using UnityEngine;

public class Invader_Animation : MonoBehaviour
{

   // Esse script é para fazer a animação dos invaders (e a colisão deles com o tiro)
   // eu preferi fazer assim em vez de usar a função de animação do Unity porque
   // já estava mais acostumado desse jeito.
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public GameObject missile;
    public AlienShip alienShip;
    
   private void Awake()
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
      alienShip = FindObjectOfType<AlienShip>();
   }
   private void Start()
   {
      InvokeRepeating(nameof(AnimatedSprite), 0.5f, 0.5f);
   }

   // Essa parte do código serve para eliminar o invader quando o laser acertar
   // fiz no script da animação porque já estava anexado aos invaders
   private void Update()
   {
      Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 1f, 0, LayerMask.GetMask("Shot"));
    if(box != null)
    {
      Destroy(box.gameObject);
      Destroy(gameObject);
      alienShip.SetScore();
    }
   
   }

   private void AnimatedSprite()
   {
     spriteIndex++;
     if(spriteIndex >= sprites.Length) {
        spriteIndex = 0;
     }
     spriteRenderer.sprite = sprites[spriteIndex];
   }

    
}
