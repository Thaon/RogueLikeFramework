using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    public Tile m_ground;
    public Tile m_wall;
    public Actor m_player;

	void Start ()
    {
        Map map = GetComponent<Map>();
        for (int y = 0; y < map.m_mapSize; y++)
        {
            for (int x = 0; x < map.m_mapSize; x++)
            {
                if (x == 0 || x == map.m_mapSize - 1 || y == 0 || y == map.m_mapSize - 1)
                {
                    //print(x + ", " + y);
                    map.m_levelMap[x, y] = m_wall;
                }
                else
                {
                    map.m_levelMap[x, y] = m_ground;
                }
            }
        }
        map.SetUpMap();
        map.MoveActor(m_player, new Vector2(9, 9));
        print(map.GetActorLocation(m_player.GetInstanceID()));
	}
}
