using UnityEngine;
using System.IO;
using JetBrains.Annotations;

public class SaveManager : MonoBehaviour{
    public static SaveManager Instancia;
    string Caminho;

    private void Awake(){
        if (Instancia == null){
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else{Destroy(gameObject);}

        Caminho = Application.persistentDataPath + "/save.json";
    }

    public void Salvar(){
        string json = JsonUtility.ToJson(Geral.Instancia, true);

        File.WriteAllText(Caminho, json);

        Debug.Log("Jogo Salvo");
    }

    public void Carregar(){
        if (File.Exists(Caminho)){
            string json = File.ReadAllText(Caminho);

            JsonUtility.FromJsonOverwrite(json, Geral.Instancia);

            Debug.Log("Jogo Carregado");
        }
        else
            Debug.Log("Nenhum save encontrado");
    }

    //Eu só preciso disso pra testar as fases sem reiniciar o jogo
    //O GameObject SaveManager se cria automaticamente
    [RuntimeInitializeOnLoadMethod]
    static void Init(){
        if (Instancia == null){
            GameObject obj = new GameObject("SaveManager");
            obj.AddComponent<SaveManager>();
        }
    }
}