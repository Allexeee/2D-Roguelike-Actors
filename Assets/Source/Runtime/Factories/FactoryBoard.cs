//Framework version:24.04.2019
using UnityEngine;
using Pixeye.Framework;
using System.Collections.Generic;

///<summary>
/// Фабрика для создания доски (карты)
///</summary>
[CreateAssetMenu(fileName = "FactoryBoard", menuName = "Factory/FactoryBoard")]
public class FactoryBoard : Factory
{
    [System.Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public static FactoryBoard Instance;

    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);

    public GameObject exit;                                         //Prefab to spawn for exit.
    public GameObject[] floorTiles;                                 //Array of floor prefabs.
    public GameObject[] wallTiles;                                  //Array of wall prefabs.
    public GameObject[] foodTiles;                                  //Array of food prefabs.
    public GameObject[] enemyTiles;                                 //Array of enemy prefabs.
    public GameObject[] outerWallTiles;								//Array of outer tile prefabs.


    private List<Vector3> gridPositions = new List<Vector3>();	//Список возможных мест для размещения тайлов

    public FactoryBoard()
    {
        Instance = this;
    }

    public static void Spawn(int level = 3)
    {
        //Creates the outer walls and floor.
        Instance.BoardSetup();

        //Reset our list of gridpositions.
        Instance.InitialiseList();

        //Instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
        Instance.LayoutObjectAtRandom(Instance.wallTiles, Instance.wallCount.minimum, Instance.wallCount.maximum, Models.ModelCollider);

        //Instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
        Instance.LayoutObjectAtRandom(Instance.foodTiles, Instance.foodCount.minimum, Instance.foodCount.maximum);

        //Determine number of enemies based on current level number, based on a logarithmic progression
        int enemyCount = (int)Mathf.Log(level, 2f);

        //Instantiate a random number of enemies based on minimum and maximum, at randomized positions.
        Instance.LayoutObjectAtRandom(Instance.enemyTiles, enemyCount, enemyCount, Models.ModelPlayer);

        var act = Actor.Create(Instance.exit, Models.ModelCollider);
        act.transform.position = new Vector3(Instance.columns - 1, Instance.rows - 1, 0f);
    }

    ///<summary>
    ///Очищает список gridPosition и готовит его для создания новой доски
    ///</summary>
    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    ///<summary>
    /// Настройка внешних стен и пола (фона) игрового поля
    ///</summary>
    void BoardSetup()
    {
        var boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = -1; x < columns + 1; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = -1; y < rows + 1; y++)
            {
                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    var actor = Actor.Create(outerWallTiles[Random.Range(0, outerWallTiles.Length)], Models.ModelCollider);
                    actor.transform.position = new Vector3(x, y, 0f);
                    actor.transform.SetParent(boardHolder);
                }
                else
                {
                    GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                    Transform tr = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity).transform;
                    tr.SetParent(boardHolder);
                }
            }
        }

    }

    ///<summary>
    ///Возвращает случайную позицию из спсиска gridPosition
    ///</summary>
    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);

        Vector3 randomPosition = gridPositions[randomIndex];

        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }

    ///<summary>
    ///Генерирует случайное количество объектов в диапазоне от min да max из массива
    ///</summary>
    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum, HandleEntityComposer model = null)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];

            if (model == null)
                Instantiate(tileChoice, randomPosition, Quaternion.identity);
            else
            {
                var act = Actor.Create(tileChoice, model);
                act.transform.position = randomPosition;
            }
        }
    }
}