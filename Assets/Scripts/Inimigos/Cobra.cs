using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Video;
using Unity.VisualScripting;

public class Cobra : Inimigo{
    
    private SpriteRenderer Sprite1;
    private Animator Animacao;
    public Transform A;
    public Transform B;
    private Transform Alvo;
    public float Velocidade;

    void Start(){
        Sprite1 = GetComponent<SpriteRenderer>();
        Animacao = GetComponent<Animator>();
        Alvo = A;
        Animacao.Play("Cobra_Andando");
    }
    void FixedUpdate(){
        if(Derrotado == true){
            return;
        }
        Movimentar();
    }

    public void Movimentar(){
        if(Alvo.position.x > transform.position.x){
            Sprite1.flipX = true;
        }
        else
        Sprite1.flipX = false;

        transform.position = Vector2.MoveTowards(transform.position, Alvo.position, Velocidade * Time.deltaTime);
        if(Vector2.Distance(transform.position, Alvo.position) < Velocidade * Time.deltaTime){
            if(Alvo == A)
                Alvo = B;
            else
            Alvo = A;
        }
    }

    protected override void Morrer(){
        Animacao.Play("Cobra_Derrotada");
        base.Morrer();
        StartCoroutine(Desativar());
    }  
}
