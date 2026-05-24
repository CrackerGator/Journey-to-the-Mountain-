using System.Collections.Generic;
using UnityEngine;

public class Sequencia_Caixas : MonoBehaviour{

    [System.Serializable]
    public class CaixaDialogo{
        public GameObject Caixa;
    }

    public List<CaixaDialogo> ListaCaixas;
    public int Indice = 0;

    private void OnEnable(){
        Interagir();
    }

    public void Interagir(){
        if(Indice >= ListaCaixas.Count){return;}
        ListaCaixas[Indice].Caixa.SetActive(true);
    }
    
    public void Fechar(){
        ListaCaixas[Indice].Caixa.SetActive(false);
        if(Indice < ListaCaixas.Count - 1){Indice++;}
        gameObject.SetActive(false);
    }
}