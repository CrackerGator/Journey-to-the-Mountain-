using System.Collections;
using UnityEngine;

public class Porta_Bugada : Porta_Trancada{
    public string FaseBugada;
    public bool Bugado;
    public GameObject Chave;
    public SpriteRenderer SpriteChave;
    public Sprite SpriteNormal;
    public Sprite SpriteBugado;
    public GameObject DialogoBugado1;
    public GameObject DialogoBugado2;
    public Transform Porta;
    public GameObject Explosao;

    public override void AdcionarChave(bool ChaveBugada){
        ChavesColetadas++;
        if(ChaveBugada){Bugado = true;}
        UI.Instancia.AtualizarChave(
            ChavesColetadas,
            Chaves.Length,
            Bugado
        );
        if(ChavesColetadas >= Chaves.Length){
            Chave.SetActive(true);

            if(Bugado){
                SpriteChave.sprite = SpriteBugado;
            }
            else{
                SpriteChave.sprite = SpriteNormal;
            }
        }
    }

     public override void Interagir1(){
        if(Perto && Input.GetKeyDown(Input1) && !Caixa_Dialogo.Ativa){
            if(Aberta){
                if(Bugado){
                    Geral.Instancia.FaseAtual = FaseBugada;
                    ProximaCena = FaseBugada;
                }
                else{
                    Geral.Instancia.FaseAtual = ProximaFase;
                }
                SaveManager.Instancia.Salvar();
                Fade.Instancia.TrocarCena(ProximaCena);

                return;
            }

            if(ChavesColetadas >= Chaves.Length && !Aberta){
                if(Bugado){
                    StartCoroutine(SequenciaBugada());
                }
                else{
                    DialogoAbrindo.SetActive(true);
                    AbrirPorta();
                }
            }
            else{
                DialogoSemChave.SetActive(true);
            }
        }
    }
    IEnumerator SequenciaBugada(){
        DialogoBugado1.SetActive(true);

        yield return new WaitUntil(() => Caixa_Dialogo.Ativa == false);
        
        while(Vector2.Distance(Chave.transform.position, 
            Porta.position) > 0.1f){

                Chave.transform.position = Vector2.MoveTowards(
                    Chave.transform.position,
                    Porta.position, 10f * Time.deltaTime);

            yield return null;
        }
        Chave.SetActive(false);

        Explosao.SetActive(true);
        AbrirPorta();
        yield return new WaitForSeconds(1f);
        DialogoBugado2.SetActive(true);
    }
}