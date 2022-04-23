using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGenerator : MonoBehaviour
{
    public BattleCharacter player;
    public List<BattleCharacter> enemies;

    public GameObject playerPivot;
    public List<GameObject> enemiesPivot;

    void Start()
    {
        GenerateBattle(player, enemies);
    }

    private void GenerateBattle(BattleCharacter player, List<BattleCharacter> enemies){
        GameObject newPlayer = Instantiate(player.go, playerPivot.transform.position, Quaternion.identity);
        for(int i = 0; i < enemies.Count; i++){
            GameObject newEnemy = Instantiate(enemies[i].go,  enemiesPivot[i].transform.position, Quaternion.identity);
        }
    }
}
