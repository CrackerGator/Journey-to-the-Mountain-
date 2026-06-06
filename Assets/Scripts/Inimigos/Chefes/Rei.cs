using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Rei : Inimigo{ 
    private SpriteRenderer Sprite1;
    private Animator Animacao;
    public Transform Jogador;

    [Header("Ataque")]
    public GameObject ColliderDano;
    public GameObject Ataque_Esquerda;
    public GameObject Ataque_Direita;
    public GameObject ColliderDash;

    [Header("Cooldown")]
    public float Cooldown = 2f;
    private float CooldownAtual;

    [Header("Dash")]
    public float DashVelocidade = 8f;
    public float DashDuracao = 1.5f;
    public float DashChance = 0.5f;

    [Header("Verificadores")]
    public bool Atacando;
    public float Preparando = 0.8f;
    public Detector_Ataque Detector;

    void Start(){
        Sprite1 = GetComponent<SpriteRenderer>();
        Animacao = GetComponent<Animator>();

        Ataque_Direita.SetActive(false);
        Ataque_Esquerda.SetActive(false);
        ColliderDash.SetActive(false);

        Animacao.Play("King_Idle");
    }

    void Update(){
        if (Derrotado){return;}
        if (Jogador == null){return;}

        if (CooldownAtual > 0){
            CooldownAtual -= Time.deltaTime;
            return;
        }

        if(Atacando){return;}

        float Distancia = Vector2.Distance(transform.position, Jogador.position);

        if(Jogador.position.x > transform.position.x){
            Sprite1.flipX = true;
        }
        else
        Sprite1.flipX = false;

        if (Detector.JogadorNoAlcance){
            StartCoroutine(Ataque());
            return;
        }
        if(Random.value < DashChance * Time.deltaTime){
            StartCoroutine(Dash());
            return;
        }
    }

    IEnumerator Ataque(){
        Atacando = true;
        yield return StartCoroutine(Preparar("Mordida"));

        if (Derrotado){yield break;}

        Animacao.Play("Rei_Mordida");

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

        if (Derrotado){yield break;}

        float T0 = 0f;
        Vector2 Direcao = (Jogador.position - transform.position).normalized;
        Direcao.y = 0;
        Direcao = Direcao.normalized;

        Animacao.Play("Rei_Dash");
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
            Animacao.Play("Preparar_Mordida");
        }
        else if (NomeAtaque == "Dash"){
            Animacao.Play("Preparar_Dash");
        }
        yield return new WaitForSeconds(Preparando);

        if (Derrotado){yield break;}
    }

    void TerminarAtaque(){
        if (Derrotado){return;}
        Atacando = false;
        Body.linearVelocity = Vector2.zero;
        Animacao.Play("Rei_Idle");
        CooldownAtual = Cooldown;
    }

    protected override void Morrer(){
        base.Morrer();

        StopAllCoroutines();

        if (Body != null){
            Body.linearVelocity = Vector2.zero;
        }
        Animacao.Play("Rei_Derrotado");
        StartCoroutine(Desativar());
    }
}