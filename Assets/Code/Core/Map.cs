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
        FillWithEmptyTiles();
        
    }

    void FillWithEmptyTiles()
    {
        Tile empty = GameObject.Find("Empty").GetComponent<Tile>();
        for (int y = 0; y < m_mapSize; y++)
        {
            for (int x = 0; x < m_mapSize; x++)
            {
                m_levelMap[x, y] = empty;
            }
        }
    }

    public void SetUpMap()
    {
        //put actor in map
        //print(m_levelMap[0, 0].m_name);
        Actor player = GetComponent<MapGenerator>().m_player;
        //print(player.m_name);
        m_levelMap[0, 0].m_occupant = player;
        //print(m_levelMap[0, 0].m_occupant.m_name);
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
        //print("Moved actor");
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
                //first we remove the actor from his previous position!
                //print(m_levelMap[(int)GetActorLocation(actor).x, (int)GetActorLocation(actor).y]);
                //print("at: " + (int)GetActorLocation(actor).x + ":" + (int)GetActorLocation(actor).y);
                Vector2 actorLocation = GetActorLocation(actor.GetInstanceID());
                m_levelMap[(int)actorLocation.x, (int)actorLocation.y].m_occupant = null;
                m_levelMap[newX, newY].m_occupant = actor;

                actorLocation = GetActorLocation(actor.GetInstanceID());
                print(m_levelMap[(int)actorLocation.x, (int)actorLocation.y].m_occupant);
                print("at: " + (int)actorLocation.x + ":" + (int)actorLocation.y);
                print("should be at: " + newX + ":" + newY);

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

    public Vector2 GetActorLocation(int actorID)
    {
        //print("Got actor's location");
        for(int y = 0; y < m_mapSize; y++)
        {
            for (int x = 0; x < m_mapSize; x++)
            {
                //print(m_levelMap[x, y].m_name);
                //print(m_levelMap[x, y].m_occupant);
                if (m_levelMap[x, y].m_occupant != null)
                {
                    if (m_levelMap[x, y].m_occupant.GetInstanceID() == actorID)
                    {
                        //print(m_levelMap[x, y].m_occupant + "at:");
                        //print(x + "-" + y);

                        return new Vector2(x, y);
                    }
                }
            }
        }
        print("Actor not found");
        return new Vector2(-1, -1);
    }
}
