using System.Collections.Generic;
using UnityEngine;

public class Sequencia_Caixas : MonoBehaviour{

    [System.Serializable]
    public class CaixaDialogo{
        public GameObject Caixa;
    }

    public List<CaixaDialogo> ListaCaixas;
    private int Indice = 0;

    private void OnEnable(){
        Interagir();
    }

    public void Interagir(){
        if(Indice >= ListaCaixas.Count){return;}

        ListaCaixas[Indice].Caixa.SetActive(true);

        if(Indice < ListaCaixas.Count - 1){Indice++;}
    }
    
    public void Fechar(){gameObject.SetActive(false);}
}