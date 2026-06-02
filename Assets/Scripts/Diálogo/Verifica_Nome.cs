using Unity.VisualScripting;
using UnityEngine;

public class Verifica_Nome : MonoBehaviour{
    public GameObject NPC;
    void Start(){
        NPC.SetActive(false);
    }
    void Update(){
        if(Geral.Instancia.NomeJogador != "??????"){
            NPC.SetActive(true);
        }
    }
}
