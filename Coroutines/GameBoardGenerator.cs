using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameBoardGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject squarePrefab1;
    [SerializeField]
    private GameObject squarePrefab2;
    [SerializeField]
    [Range(2,20)]
    private int size = 8;
    private List<GameObject> boardPieces = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(BuildBoard(size));
    }

    [Button]
    private void GenerateBoard()
    {
        ClearBoard();
        StartCoroutine(BuildBoard(size));
    }

    [Button]
    private void ClearBoard()
    {
        foreach (GameObject gameObject in boardPieces)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BuildBoard(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    GameObject go = Instantiate(squarePrefab1,
                        new Vector3(i, 0, j),
                        Quaternion.identity);
                    boardPieces.Add(go);
                    go.transform.SetParent(this.transform);
                }
                else
                {
                    GameObject go = Instantiate(squarePrefab2,
                        new Vector3(i, 0, j),
                        Quaternion.identity);
                    boardPieces.Add(go);
                    go.transform.SetParent(this.transform);
                }

                yield return new WaitForSeconds(0.1f);
            }
        }
    }


}
