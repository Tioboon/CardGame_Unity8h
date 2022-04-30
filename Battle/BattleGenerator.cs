using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gera um ambiente de batalha
public class BattleGenerator : MonoBehaviour
{
    //Informações do player
    public BattleCharacter player;
    //Informações dos inimigos
    public List<BattleCharacter> enemies;

    //Ponto de spawn dos objetos
    public GameObject playerPivot;
    public List<GameObject> enemiesPivot;

    void Start()
    {
        GenerateBattle(player, enemies); //Chama a geração dos personagens
    }

    private void GenerateBattle(BattleCharacter player, List<BattleCharacter> enemies){
        //Instancia o jogador a na posição do pivot
        GameObject newPlayer = Instantiate(player.go, playerPivot.transform.position, Quaternion.identity);
        
        //Para cada inimigo, instancia o inimigo em questão.
        for(int i = 0; i < enemies.Count; i++){
            GameObject newEnemy = Instantiate(enemies[i].go,  enemiesPivot[i].transform.position, Quaternion.identity);
        }
    }
}
