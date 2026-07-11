using System.Collections;
using UnityEngine;

public class Porta_Trancada : Interagir{
    public GameObject[] Chaves;
    public int ChavesColetadas = 0;
    
    public string ProximaCena;
    public string ProximaFase;

    public SpriteRenderer Sprite1;
    public Sprite SpriteAberta;

    public GameObject DialogoSemChave;
    public GameObject DialogoAbrindo;

    protected bool Aberta = false;

    public virtual void  AdcionarChave(bool Bugado){
        ChavesColetadas++;
        UI.Instancia.AtualizarChave(
            ChavesColetadas,
            Chaves.Length,
            false
        );
    }
    public override void Interagir1(){
        if(Perto && Input.GetKeyDown(Input1) && !Caixa_Dialogo.Ativa){
            if(Aberta){
                Geral.Instancia.FaseAtual = ProximaFase; 
                SaveManager.Instancia.Salvar();
                Fade.Instancia.TrocarCena(ProximaCena);
                return;
            }
            if(ChavesColetadas >= Chaves.Length && !Aberta){
                DialogoAbrindo.SetActive(true);
                AbrirPorta();
            }
            else{
                DialogoSemChave.SetActive(true);
            } 
        }
    }
    protected virtual void AbrirPorta(){
        Aberta = true;
        Sprite1.sprite = SpriteAberta;
    }
}