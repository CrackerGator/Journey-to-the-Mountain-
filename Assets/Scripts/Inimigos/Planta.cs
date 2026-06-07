using UnityEngine;

public class Planta : MonoBehaviour{
    public int Dano = 1;
    private Animator Animacao;
    public Detector_Ataque Detector;

    void Start(){
        Animacao = GetComponent<Animator>();
        Animacao.Play("Planta_Idle");
    }
    void Update(){
        if (Detector.JogadorNoAlcance){
            Animacao.Play("Planta_Ataque");
        }
        else
        Animacao.Play("Planta_Idle");
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Jogador")){
            Jogador J = collider.GetComponent<Jogador>();
            if(J != null){J.TomarDano(Dano, transform.position);}
        }
    }
}