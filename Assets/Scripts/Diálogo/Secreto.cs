using System.Collections;
using UnityEngine;

public class Secreto : Interagir{
    public float TempoNecessario;
    private float TempoAtual;
    public float AlturaSubida;
    public float VelocidadeSubida;
    private bool Revelado;
    private Vector2 PosicaoInicial;
    private Animator Animacao;

    void Start(){
        Animacao = GetComponent<Animator>();

        PosicaoInicial = transform.position;

        Icone.SetActive(false);

        if (Interacao != null){Interacao.SetActive(false);}
    }

    protected override void Update(){
        if (!Revelado){
            if (Perto){
                TempoAtual += Time.deltaTime;

                if (TempoAtual >= TempoNecessario){
                    StartCoroutine(Revelar());
                }
            }
            else{
                TempoAtual = 0f;
            }
            return;
        }
        base.Update();
        Animacao.Play("Limossauro");
    }

    IEnumerator Revelar(){
        Revelado = true;

        Vector2 Destino = PosicaoInicial + Vector2.up * AlturaSubida;

        while (Vector2.Distance(transform.position, Destino) > 0.05f){
            transform.position = Vector2.MoveTowards(
                transform.position,
                Destino,
                VelocidadeSubida * Time.deltaTime
            );
            yield return null;
        }

        transform.position = Destino;
        Icone.SetActive(true);
    }

    protected override void OnTriggerEnter2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Perto = true;
            if (Revelado){Icone.SetActive(true);}
        }
    }
    protected override void OnTriggerExit2D(Collider2D collider){
        if (collider.CompareTag("Jogador")){
            Perto = false;
            if (Revelado){Icone.SetActive(false);}
        }
    }
}