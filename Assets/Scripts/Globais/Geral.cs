using UnityEngine;

public enum TipoAnimal{
    Nenhum,
    Crocodilo,
    Jacaré
}

public class Geral : MonoBehaviour{
    public static Geral Instancia;

    public string NomeJogador = "??????";
    public string FaseAtual;
    public int Mortes = 0;
    public TipoAnimal A = TipoAnimal.Nenhum;
    public int Chaves = 0;
    public bool atalho;

    private void Awake(){
        if (Instancia == null){
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        Destroy(gameObject);
    }

    //Eu só preciso disso pra testar as fases sem reiniciar o jogo
    //O GameObject Geral se cria automaticamente
    [RuntimeInitializeOnLoadMethod]
    static void Init(){
        if (Instancia == null){
            GameObject Teste = new GameObject("Geral");
            Teste.AddComponent<Geral>();
        }
    }
}