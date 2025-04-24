using UnityEditor.Timeline;
using UnityEngine;

public class GameMannagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    int[,] map;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = new int[,] {

            { 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0 },

        };
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


    //int GetPlayerIndex()
    //{
    //    // playerがいる位置の保存变数の宣言
    //    int playerIndex = -1;
    //    // playerの位置の検索
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        if (map[i] == 1)
    //        {
    //            playerIndex = i;
    //            break;
    //        }
    //    }
    //    // playerの位置を返す 
    //    return playerIndex;
    //}

/////<summary>
/////移動メソッド
/////</summary>
/////<param name="number">移動する数字</param>
/////<prarm name="moveFrom">移動元の位置</param>
/////<prarm name="moveTo">移動先の位置</param>


//    bool MoveNumber(int number, int moveFrom, int moveTo)
//    {
//        //移動先が左端よりさき、まだは右端よりさきにいっているか?
//        if (moveTo < 0 || moveTo >= map.Length)
//        {
//            return false;
//        }
//        // 移動先に箱がいたら
//        if (map[moveTo] == 2)
//        {
//            //　移動方向的算出
//            int velcity = moveTo - moveFrom;

//            //playerの移動先に箱があるので、ｐぁいぇｒの移動先から箱をどかす
//            // 箱はplayerの移動先になってしまっているので、playerの移動方向に合わせて
//            //一つ動けるか確認する。動けたかどうかはsuccessに返却される
//            bool sccess = MoveNumber(2,moveTo,moveTo + velcity);
//            if (!sccess){ return false;}
//        }


//            map[moveTo] = number;
//            map[moveFrom] = 0;

//        return true;
//    }
}

