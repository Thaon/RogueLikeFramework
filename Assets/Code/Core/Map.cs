using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour{

    [SerializeField]
    public Tile[,] m_levelMap;
    public int m_mapSize;
    private float m_tileSize;

	void Start ()
    {
        m_levelMap = new Tile[m_mapSize, m_mapSize];
        float worldToPixels = (Camera.main.orthographicSize / (Screen.height / 2.0f));
        m_tileSize = (GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2);// * worldToPixels);// / worldToPixels;
        //print(m_tileSize);
    }

    public void SetUpMap()
    {
        for (int y = 0; y < m_mapSize; y++)
        {
            for (int x = 0; x < m_mapSize; x++)
            {
                GameObject tile = new GameObject();
                tile.AddComponent<SpriteRenderer>();
                //print(m_levelMap[x, y].m_name);
                tile.GetComponent<SpriteRenderer>().sprite = m_levelMap[x, y].m_spriteRenderer.sprite;
                tile.GetComponent<SpriteRenderer>().color = m_levelMap[x, y].m_spriteRenderer.color;
                tile.transform.position = new Vector2(x * m_tileSize, y * m_tileSize);
            }
        }
    }

    public void MoveActor(Actor actor, Vector2 newPosition)
    {
        int newX = (int)newPosition.x;
        int newY = (int)newPosition.y;
        //print(newX + " : " + newY);
        if (!m_levelMap[newX, newY].m_isBlocking)
        {
            if(m_levelMap[newX, newY].m_occupant != null) //if there is an actor on the tile
            {
                BattleSystem.PerformBattleAction(actor, m_levelMap[newX, newY].m_occupant);
            }
            else
            {
                m_levelMap[newX, newY].m_occupant = actor;
                if (actor.m_isPlayer)
                {
                    Camera.main.transform.position = new Vector3(newX * m_tileSize, newY * m_tileSize, -10);
                }
                actor.gameObject.transform.position = new Vector2(newX * m_tileSize, newY * m_tileSize);
            }
        }
    }

    public void DropItem(Item item, Vector2 position)
    {
        int newX = (int)position.x;
        int newY = (int)position.y;
        m_levelMap[newX, newY].m_itemsInTile.Add(item);
    }

    public Vector2 GetActorLocation(Actor actor)
    {
        for(int y = 0; y < m_mapSize; y++)
        {
            for (int x = 0; x < m_mapSize; x++)
            {
                if (m_levelMap[x, y].m_occupant != null)
                {
                    if (m_levelMap[x, y].m_occupant == actor)
                    {
                        print(m_levelMap[x, y].m_occupant + "at:");
                        print(x + "-" + y);

                        return new Vector2(x, y);
                    }
                }
            }
        }
        return new Vector2(0, 0);
    }
}
