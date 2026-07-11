using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour{
    public static UI Instancia;
    
    public TextMeshProUGUI VidaUI;
    public GameObject TelaPause;
    public GameObject TelaGameOver;
    public GameObject ChaveUI;

    void Awake(){
        Instancia = this;
    }
    public void AtualizarVida(int Vida){
        VidaUI.text = "x"+Vida;
    }
    public void AtivarPause(bool Estado){
        TelaPause.SetActive(Estado);
    }
    public void AtivarGameOver(){
        TelaGameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void AtualizarChave(int Atuais, int Maximo, bool Bugado){
        if(Bugado){
            return;
        }
        else if(Atuais >= Maximo){
            ChaveUI.SetActive(true);
        }
    }
}