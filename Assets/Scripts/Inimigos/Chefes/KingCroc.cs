using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class KingCroc : Inimigo{ 
    public Transform Jogador;
    public float Velocidade = 3f;

    [Header("Ataque")]
    public GameObject ColliderAtaque;
    public float Range = 2f;

    [Header("Cooldown")]
    public float CooldownAtaque = 2f;
    private float CooldownTempo;

    [Header("Dash")]
    public float DashVelocidade = 10f;
    public float DashDuracao = 1f;
    public float DashChance = 0.2f;

    public bool Atacando;
    public float Preparando = 0.6f;

    [Header("Debug Visual")]
    public SpriteRenderer SpriteBoss;
    public SpriteRenderer SpriteAtaque;

    public Color CorNormal = Color.green;
    public Color CorPreparando = Color.yellow;
    public Color CorMordida = Color.red;
    public Color CorDash = Color.blue;

    void Start(){
        SetCor(CorNormal);
    }

    void Update(){
        if (Jogador == null){return;}

        if (CooldownTempo > 0){
            CooldownTempo -= Time.deltaTime;
            return;
        }

        if(Atacando){return;}

        float Distancia = Vector2.Distance(transform.position, Jogador.position);

        if(Random.value < DashChance * Time.deltaTime){
            StartCoroutine(Dash());
            return;
        }

        if (Distancia <= Range){
            StartCoroutine(Ataque());
            return;
        }

        Mover();
    }

    void SetCor(Color cor){
        if (SpriteBoss != null)
            SpriteBoss.color = cor;

        if (SpriteAtaque != null)
            SpriteAtaque.color = cor;
    }

    void Mover(){
        Vector2 Direcao = (Jogador.position - transform.position).normalized;
        Direcao.y = 0;
        Direcao = Direcao.normalized;
        Body.linearVelocity = Direcao * Velocidade;
    }

    IEnumerator Antecipar(string NomeAtaque){
        Debug.Log("Preparando: "+ NomeAtaque);

        // Animação, Cor, Som

        SetCor(CorPreparando);

        if (NomeAtaque == "Mordida"){
            //Animacao.Play("Preparando_Mordida");
            
        }
        else if (NomeAtaque == "Dash"){
            //Animacao.Play("Preparando_Mordida");
            
        }

        yield return new WaitForSeconds(Preparando);
    }

    IEnumerator Ataque(){
        Atacando = true;
        yield return StartCoroutine(Antecipar("Mordida"));

        SetCor(CorMordida);

        ColliderAtaque.SetActive(true);
        //Animacao.Play("Ataque_Mordida");
        yield return new WaitForSeconds(0.3f);
        ColliderAtaque.SetActive(false);

        SetCor(CorNormal);

        TerminarAtaque();
    }

    IEnumerator Dash(){
        Atacando = true;
        yield return StartCoroutine(Antecipar("Dash"));

        SetCor(CorDash);

        float T0 = 0f;
        Vector2 Direcao = (Jogador.position - transform.position).normalized;
        Direcao.y = 0;
        Direcao = Direcao.normalized;

        while(T0 < DashDuracao){
            Body.linearVelocity = Direcao * DashVelocidade;
            T0 += Time.deltaTime;
            yield return null;
        }
        Body.linearVelocity = Vector2.zero;

        SetCor(CorNormal);

        TerminarAtaque();
    }

    void TerminarAtaque(){
        Atacando = false;
        CooldownTempo = CooldownAtaque;
    }

    protected override void Morrer(){
        base.Morrer();

        StopAllCoroutines();

        if (Body != null){
            Body.linearVelocity = Vector2.zero;
        }
        Debug.Log("Quinou");

        this.enabled = false;
    }   
}