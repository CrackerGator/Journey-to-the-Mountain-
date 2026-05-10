using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Jogador : MonoBehaviour{

    public int Vida;
    public int VidaTotal;
    
    private Rigidbody2D Body;
    private SpriteRenderer Sprite1;
    private Animator Animacao;

    [Header("Movimento")]
    public float X;
    public float Velocidade;
    public float Altura;
    public bool PuloDuplo;

    [Header("Verificadores")]
    public bool NoChao;
    public Transform Verificador;
    public float RaioVerificador;
    public LayerMask Ground;
    public bool Atacando = false;
    private float TempoAtaque = 0.2f;
    
    [Header("Ataque")]
    public GameObject AtaqueDireita;
    public GameObject AtaqueEsquerda;

    [Header("Knockback")]
    public bool Knockbacked = false;
    public float ForcaKnock;
    public float TempoKnock;
    public bool Invencivel = false;
    public float TempoInvencivel;
    
    void Start(){
        Body = GetComponent<Rigidbody2D>();
        Sprite1 = GetComponent<SpriteRenderer>();
        Animacao = GetComponent<Animator>();

        foreach (Transform Objetos in transform){
            Objetos.gameObject.SetActive(false);
        }
    }
    void Update(){   
        X = Input.GetAxis("Horizontal");
        
        Animar();
        Pular();
        Atacar();

        if(Vida <= 0){
            this.enabled = false;
            Game_Over.Instancia.Perdeu();
            Geral.Instancia.Mortes++;
        }
    }
    void FixedUpdate(){
        Movimentar();
    }
    
    public void Movimentar(){
        if(Knockbacked == true){
            return;
        }
        Body.linearVelocity = new Vector2(X * Velocidade, Body.linearVelocity.y);
    }

    public void Pular(){
        NoChao = Physics2D.OverlapCircle(Verificador.position, RaioVerificador, Ground);
        if(NoChao == true){
            PuloDuplo = true;
        }
        if (Input.GetKeyDown(KeyCode.Z)){
            if(NoChao == true){
                Body.linearVelocity = new Vector2(Body.linearVelocity.x, Altura);
            }
            else if (PuloDuplo == true){
                Body.linearVelocity = new Vector2(Body.linearVelocity.x, Altura);
                PuloDuplo = false;            
            }
        }
    }

    public void Atacar(){
        if (Input.GetKeyDown(KeyCode.X)){
            StartCoroutine(ativar());
        }   
    }
    private System.Collections.IEnumerator ativar(){
        Atacando = true;

        if(X > 0){
            AtaqueDireita.SetActive(true);
            //Animacao.Play("Jogador_Ataque");
            yield return new WaitForSeconds(TempoAtaque);
            AtaqueDireita.SetActive(false);
        }
        else if(X < 0){
            AtaqueEsquerda.SetActive(true);
            //Animacao.Play("Jogador_Ataque");
            yield return new WaitForSeconds(TempoAtaque);
            AtaqueEsquerda.SetActive(false);
        }
        else{
            if(Sprite1.flipX == false){
                AtaqueDireita.SetActive(true);
                //Animacao.Play("Jogador_Ataque");
                yield return new WaitForSeconds(TempoAtaque);
                AtaqueDireita.SetActive(false);
            }
            else
            AtaqueEsquerda.SetActive(true);
            //Animacao.Play("Jogador_Ataque");
            yield return new WaitForSeconds(TempoAtaque);
            AtaqueEsquerda.SetActive(false);
        }

        Atacando = false;
    }

    public void TomarDano(int Dano, Vector2 DirecaoInimigo){
        if(Invencivel == true){
            return;
        }
        
        Vida -= Dano;
        Debug.Log("Jogador tomou dano! Vida atual: " + Vida);

        Vector2 Direcao = ((Vector2)transform.position - DirecaoInimigo).normalized;
        StartCoroutine(Knockback(Direcao));
        StartCoroutine(InvencivelTempo());
    }

    private IEnumerator Knockback(Vector2 Direcao){
        Knockbacked = true;
        Body.linearVelocity = Vector2.zero;
        Body.linearVelocity = Direcao * ForcaKnock;
        yield return new WaitForSeconds(TempoKnock);
        Body.linearVelocity = new Vector2(0f, Body.linearVelocity.y);
        Knockbacked = false; 
    }

    private IEnumerator InvencivelTempo(){
        Invencivel = true;
        Animacao.Play("player_jump");
        yield return new WaitForSeconds(TempoInvencivel);
        Invencivel = false;
    }

    public void Animar(){
        if (X == 0 && NoChao == true){
            Animacao.Play("player_idle");
        }
        else if (X != 0 && NoChao == true){
            Animacao.Play("player_walk");
        }
        else if (NoChao == false){
            Animacao.Play("player_jump");
        }

        if (X > 0){Sprite1.flipX = false;}
        else if (X < 0){Sprite1.flipX = true;}
    }   
}