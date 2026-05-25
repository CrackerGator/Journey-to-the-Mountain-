using UnityEngine;

public class Porta_Trancada : Interagir{
    public int ChavesNecessarias;
    public string ProximaCena;
    public string ProximaFase;

    public SpriteRenderer Sprite1;
    public Sprite SpriteAberta;

    public GameObject DialogoSemChave;
    public GameObject DialogoComChave;
    public GameObject Dialogo1Chave;
    public GameObject DialogoAbrindo;

    private bool Aberta = false;

    protected override void Update(){
        if(Perto && Input.GetKeyDown(Input1) && !Caixa_Dialogo.Ativa){
            if(Aberta){
                Geral.Instancia.FaseAtual = ProximaFase;
                SaveManager.Instancia.Salvar();
                Fade.Instancia.TrocarCena(ProximaCena);
            }
            if(Geral.Instancia.Chaves >= ChavesNecessarias){
                DialogoAbrindo.SetActive(true);
                AbrirPorta();
            }
            else{
                int Faltam = ChavesNecessarias - Geral.Instancia.Chaves;
                if(Faltam == ChavesNecessarias){
                    DialogoSemChave.SetActive(true);
                }
                else if(Faltam == 1){
                Dialogo1Chave.SetActive(true);
                }
                else if(Faltam < ChavesNecessarias){
                    DialogoComChave.SetActive(true);
                }  
            } 
        }
    }
    void AbrirPorta(){
        Aberta = true;
        Sprite1.sprite = SpriteAberta;
    }
}
