using TMPro;
using UnityEngine;

public class UI : MonoBehaviour{
    public static UI Instancia;
    
    public TextMeshProUGUI VidaUI;
    public GameObject TelaPause;
    public GameObject TelaGameOver;

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
}