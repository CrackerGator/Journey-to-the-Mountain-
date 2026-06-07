using UnityEngine;

public class Planta : MonoBehaviour{
    public int Dano = 1;
    private Animator Animacao;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Jogador")){
            Jogador J = collider.GetComponent<Jogador>();

            if(J != null){
                Animacao.Play("Planta_Ataque");
                J.TomarDano(Dano, transform.position);
            }
        }
    }
}
