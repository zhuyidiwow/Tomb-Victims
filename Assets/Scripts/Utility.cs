using UnityEngine;

public class Utility {


    public static GameManager GetGameManager() {
        return GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public static Player GetPlayer() {
        return GameObject.Find("Player").GetComponent<Player>();
    }
}
