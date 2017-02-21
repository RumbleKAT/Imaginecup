using UnityEngine;
using System.Collections;

public class genertor : MonoBehaviour {
    [System.Serializable]
    public class Cell{
        public GameObject obj;
    }

    public int xsize = 5;
    public int zsize = 5;
    public float cubeScale = 1;

    public GameObject Cube;
    private GameObject CubeHolder;

    public Renderer mate;


    public Cell[] Cells;
    // Use this for initialization
    void Start () {
        CreateCube();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateCube()
    {
        Vector3 myPos;
        Vector3 InitPos = new Vector3(cubeScale / 2, 0, cubeScale / 2);
        GameObject tempCube;
        CubeHolder = new GameObject();
        CubeHolder.name = "Cube";
        float a = 0;

        /*
        for (int i = 0; i<xsize; i++)
        {
            for(int j =0; j<zsize; j++)
            {
                a = 0;

                if (j % 2 == 1)
                {
                    a = cubeScale / 2;
                }


                myPos = InitPos + new Vector3(cubeScale * i +a , Random.Range(0,4) , cubeScale * j);
                tempCube = Instantiate(Cube, myPos, Quaternion.identity) as GameObject;
                mate = tempCube.GetComponent<Renderer>();
                mate.material.color = new Vector4(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f),1.0f);
                tempCube.transform.parent = CubeHolder.transform;
            }
        }
        */


        for (int i=0; i<xsize; i++)
        {
            
            for (int j = 0; j < zsize ; j++)
            {
                a = 0;
                /*
                if (j%2 == 1)
                {
                    a = cubeScale / 2;
                }*/
                myPos = InitPos + new Vector3(cubeScale * i + a,0, (cubeScale * j) );
                tempCube = Instantiate(Cube, myPos, Quaternion.identity) as GameObject;
                tempCube.transform.parent = CubeHolder.transform;
            }  
        }

        createCell();
    }

    void createCell()
    {
        int totalCell = xsize * zsize;
        Cells = new Cell[xsize * zsize];
        int children = CubeHolder.transform.childCount;
        GameObject[] allCube;
        allCube = new GameObject[children];
        for(int i = 0; i< children; i++)
        {
            allCube[i] = CubeHolder.transform.GetChild(i).gameObject;


        }

        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i].obj = allCube[i];


        }
        

    }

}
