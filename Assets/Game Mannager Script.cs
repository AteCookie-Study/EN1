using UnityEditor.Timeline;
using UnityEngine;

public class GameMannagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    int[,] map;
    GameObject[,] objectsMap;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameObject instance = Instantiate(
        //    playerPrefab,
        //    new Vector3(0, 0, 0),
        //    Quaternion.identity
        //    );


        map = new int[,] {

            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },

        };
        objectsMap = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
            ];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    objectsMap[x, y] =
                        Instantiate(
                           playerPrefab,
                           new Vector3(x, map.GetLength(0) - y, 0),
                           Quaternion.identity
                        );
                }
            }
        }
        PrintArry();
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        // playerがいる位置の保存变数の宣言
    //        int playerIndex = GetPlayerIndex();

    //        MoveNumber(1,playerIndex, playerIndex + 1);

    //        PrintArry();

    //    }

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        // playerがいる位置の保存变数の宣言
    //        int playerIndex = GetPlayerIndex();

    //        //playerの左側にいる？
    //        MoveNumber(1, playerIndex, playerIndex - 1);
    //        PrintArry();

    //    }
    //}
    //private

    void PrintArry()
    {
        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }
        //    for (int i = 0; i < map.Length; i++)
        //{
        //    debugText += map[i] + ",";
        //}
        Debug.Log(debugText);
    }


    Vector2Int GetPlayerIndex()
    {

        // playerの位置の検索
        for (int y = 0; y < objectsMap.GetLength(0); y++)
        {
            for(int x = 0; x < objectsMap.GetLength(1); x++)
            {
                if (objectsMap[x, y] == null)
                { continue; }
                if (objectsMap[x, y].CompareTag("Player"))
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    ///<summary>
    ///移動メソッド
    ///</summary>
    ///<param name="number">移動する数字</param>
    ///<prarm name="moveFrom">移動元の位置</param>
    ///<prarm name="moveTo">移動先の位置</param>


    bool MoveObject(Vector2 moveFrom, Vector2Int moveTo)
    {
        //移動先が左端よりさき、まだは右端よりさきにいっているか?
        if (moveTo.y < 0 || moveTo.y >= map.GetLength(0))
        {
            return false;
        }if (moveTo.x < 0 || moveTo.x >= map.GetLength(1))
        {
            return false;
        }

        objectsMap[(int)moveFrom.y, (int)moveFrom.x].transform.position =
            new Vector3(moveTo.x,map.GetLength(0) - moveTo.y, 0);
        objectsMap[moveTo.y,moveTo.x] = 
            objectsMap[(int)moveFrom.y, (int)moveFrom.x]; 
        
        objectsMap[(int)moveFrom.y, (int)moveFrom.x] = null;
        return true;

       
    }
}

