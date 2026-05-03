using UnityEngine;

public class Morcego : MonoBehaviour{

public enum Estado {Inicial, Indo, Voltando}
    Estado EstadoAtual = Estado.Inicial;

    public Rigidbody2D Body;
    public Transform Jogador;
    public float Detector = 4f;

    [Header("Velocidade")]
    public float Ida = 4f;
    public float Volta = 3f;

    public Vector2 Teto;
    public bool Caverna = false;

    public float DistanciaJogador;

    void Start(){
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
                if (Caverna == true && DistanciaJogador < Detector){
                    EstadoAtual = Estado.Indo;
                }
            break;

            case Estado.Indo:
                if (Caverna == false || DistanciaJogador > Detector){
                    Body.linearVelocity = Vector2.zero;
                    EstadoAtual = Estado.Voltando;
                    break;
                }
                Vector2 Direcao = (Jogador.position - transform.position).normalized;
                Body.linearVelocity = Direcao * Ida;
            break;
            
            case Estado.Voltando:
                Body.linearVelocity = Vector2.zero;
                transform.position = Vector2.MoveTowards(transform.position, Teto, Volta * Time.deltaTime);

                if (Vector2.Distance(transform.position, Teto) < 0.1f){
                    EstadoAtual = Estado.Inicial;
                }
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Caverna")){Caverna = true;}
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Caverna")){Caverna = false;}
    }
}