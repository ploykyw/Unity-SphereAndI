using UnityEngine;
using System.Collections;

public class genTarangV2 : MonoBehaviour {

	//block 4 color
    public Transform brick;
    public Transform brick2;
	public Transform brick3;
	public Transform brick4;

    private int blockStatus;
	public float tallerBoxPosition;

    private float x, y, z;
    private int i, j;
    private Vector3[,] spawnGrid = new Vector3[8, 8];
    private int[,] spawnGridStatus = new int[8, 8];

    //private Vector3[][] spawnGrid;
    // Use this for initialization
    void Start () {
        SpawnGrid();
    }

        // Update is called once per frame
        void Update () {
	
	    }


        void SpawnGrid()
        {

        /* 
        //create blocks 8*8 area == 64 blocks

        for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    {
                            Debug.Log("leon");
                            spawnGrid[i, j] = new Vector3(x, 0f, z);
                            Instantiate(brick, spawnGrid[i,j], Quaternion.identity);
                            z -= 1;                             
                    }

                    x += 1;
                    z = 0f; //gives original value back to Z.
                }
         */

        spawnGrid[0, 0] = new Vector3(0, 0f, 0);
        Instantiate(brick, spawnGrid[0, 0], Quaternion.identity);

		//spawnGrid[0, 1] = new Vector3(0, tallerBoxPosition, 1);
        //Instantiate(brick2, spawnGrid[0, 1], Quaternion.identity);

        spawnGrid[0, 2] = new Vector3(0, 0f, 1);
        Instantiate(brick2, spawnGrid[0, 2], Quaternion.identity);

		spawnGrid[0, 0] = new Vector3(0, 0f, 2);
		Instantiate(brick, spawnGrid[0, 0], Quaternion.identity);


		//spawnGrid[1, 2] = new Vector3(1, tallerBoxPosition, 2);
        //Instantiate(brick2, spawnGrid[1, 2], Quaternion.identity);
    }


        

}
