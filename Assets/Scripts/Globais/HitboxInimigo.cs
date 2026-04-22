using UnityEngine;

public class HitboxInimigo : MonoBehaviour{
   public int Dano = 1;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Jogador")){
            Jogador J = collider.GetComponent<Jogador>();

            if(J != null){
                J.TomarDano(Dano, transform.position);
            }
        }
    }
}
