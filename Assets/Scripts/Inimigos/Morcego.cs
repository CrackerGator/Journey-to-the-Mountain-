using System.Runtime.CompilerServices;
using UnityEngine;

public class Morcego : Inimigo{

public enum Estado {Inicial, Indo, Voltando}
    Estado EstadoAtual = Estado.Inicial;
    private SpriteRenderer Sprite1;
    private Animator Animacao;
    public Transform Jogador;
    public float Detector = 4f;

    [Header("Velocidade")]
    public float Ida = 4f;
    public float Volta = 3f;

    public Vector2 Teto;
    public bool Caverna = false;

    public float DistanciaJogador;

    void Start(){
        Sprite1 = GetComponent<SpriteRenderer>();
        Animacao = GetComponent<Animator>();

        Teto = transform.position; 
    }

    void Update(){
        DistanciaJogador = Vector2.Distance(Jogador.position, transform.position);
        Perseguir();
    }

    private void Perseguir(){
        switch (EstadoAtual){
            case Estado.Inicial:
                Body.linearVelocity = Vector2.zero;
                Animacao.Play("Morcego_Idle");
                if (Caverna == true && DistanciaJogador < Detector){
                    EstadoAtual = Estado.Indo;
                }
            break;

            case Estado.Indo:
                Animacao.Play("Morcego_Andando");
                
                if (Caverna == false || DistanciaJogador > Detector){
                    Body.linearVelocity = Vector2.zero;
                    EstadoAtual = Estado.Voltando;
                    break;
                }

                if(Jogador.position.x > transform.position.x){
                    Sprite1.flipX = true;
                }
                else
                Sprite1.flipX = false;
                
                Vector2 Direcao = (Jogador.position - transform.position).normalized;
                Body.linearVelocity = Direcao * Ida;
            break;
            
            case Estado.Voltando:
                Animacao.Play("Morcego_Andando");
                Body.linearVelocity = Vector2.zero;

                if(Teto.x > transform.position.x){
                    Sprite1.flipX = true;
                }
                else
                Sprite1.flipX = false;

                transform.position = Vector2.MoveTowards(transform.position, Teto, Volta * Time.deltaTime);

                if (Vector2.Distance(transform.position, Teto) < 0.1f){
                    EstadoAtual = Estado.Inicial;
                }
            break;
        }
    }
     protected override void Morrer(){
        base.Morrer();
        Animacao.Play("Morcego_Derrotado");
        StartCoroutine(Desativar());
    } 

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Caverna")){Caverna = true;}
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Caverna")){Caverna = false;}
    }
}