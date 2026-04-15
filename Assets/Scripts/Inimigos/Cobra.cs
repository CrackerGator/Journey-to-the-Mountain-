using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Video;
using Unity.VisualScripting;

public class Cobra : MonoBehaviour{
    
    public Transform A;
    public Transform B;
    private Transform Alvo;
    public float Velocidade;

    void Start(){
        Alvo = A;
    }
    void FixedUpdate(){
        movimentar();
        if(GetComponent<Inimigo>().Derrotado){
            this.enabled = false;
        }
    }

    public void movimentar(){
        transform.position = Vector2.MoveTowards(transform.position, Alvo.position, Velocidade * Time.deltaTime);
        if(Vector2.Distance(transform.position, Alvo.position) < Velocidade * Time.deltaTime){
            if(Alvo == A)
                Alvo = B;
            else
            Alvo = A;
        }
    }
}
