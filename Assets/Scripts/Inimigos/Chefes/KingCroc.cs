using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class KingCroc : Inimigo{ 
    private SpriteRenderer Sprite1;
    private Animator Animacao;
    public Transform Jogador;
    

    [Header("Ataque")]
    public GameObject ColliderDano;
    public GameObject Ataque_Esquerda;
    public GameObject Ataque_Direita;
    public GameObject ColliderDash;
    public float Range = 2f;

    [Header("Cooldown")]
    public float CooldownAtaque = 2f;
    private float CooldownTempo;

    [Header("Dash")]
    public float DashVelocidade = 10f;
    public float DashDuracao = 1f;
    public float DashChance = 0.2f;

    [Header("Dash")]
    public bool Atacando;
    public float Preparando = 0.6f;

    void Start(){
        Sprite1 = GetComponent<SpriteRenderer>();
        Animacao = GetComponent<Animator>();

        Ataque_Direita.SetActive(false);
        Ataque_Esquerda.SetActive(false);
        ColliderDash.SetActive(false);

        Animacao.Play("King_Idle");
    }

    void Update(){
        if (Jogador == null){return;}

        if (CooldownTempo > 0){
            CooldownTempo -= Time.deltaTime;
            return;
        }

        if(Atacando){return;}

        float Distancia = Vector2.Distance(transform.position, Jogador.position);

        if(Jogador.position.x > transform.position.x){
            Sprite1.flipX = true;
        }
        else
        Sprite1.flipX = false;

        if(Random.value < DashChance * Time.deltaTime){
            StartCoroutine(Dash());
            return;
        }

        if (Distancia <= Range){
            StartCoroutine(Ataque());
            return;
        }
    }

    IEnumerator Ataque(){
        Atacando = true;
        yield return StartCoroutine(Preparar("Mordida"));

        Animacao.Play("Ataque_Mordida");

        if(Sprite1.flipX == true){
            Ataque_Direita.SetActive(true);
        }
        else
        Ataque_Esquerda.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        Ataque_Esquerda.SetActive(false);
        Ataque_Direita.SetActive(false);

        TerminarAtaque();
    }

    IEnumerator Dash(){
        Atacando = true;
        yield return StartCoroutine(Preparar("Dash"));

        float T0 = 0f;
        Vector2 Direcao = (Jogador.position - transform.position).normalized;
        Direcao.y = 0;
        Direcao = Direcao.normalized;

        Animacao.Play("King_Dash");
        while(T0 < DashDuracao){
            ColliderDano.SetActive(false);
            ColliderDash.SetActive(true);

            Body.linearVelocity = Direcao * DashVelocidade;
            
            T0 += Time.deltaTime;
            yield return null;

            
        }
        ColliderDash.SetActive(false);
        ColliderDano.SetActive(true);
        Body.linearVelocity = Vector2.zero;

        TerminarAtaque();
    }

    IEnumerator Preparar(string NomeAtaque){
        if (NomeAtaque == "Mordida"){
            Animacao.Play("Preparando_Mordida");
        }
        else if (NomeAtaque == "Dash"){
            Animacao.Play("Preparando_Mordida");
        }
        yield return new WaitForSeconds(Preparando);
    }

    void TerminarAtaque(){
        Atacando = false;
        Body.linearVelocity = Vector2.zero;
        Animacao.Play("King_Idle");
        CooldownTempo = CooldownAtaque;
    }

    protected override void Morrer(){
        base.Morrer();

        StopAllCoroutines();

        if (Body != null){
            Body.linearVelocity = Vector2.zero;
        }
        Animacao.Play("King_Derrotado");
        StartCoroutine(Desativar());
    }
}