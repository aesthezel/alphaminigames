using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AES
{
    public class SnakeGM : MonoBehaviour
    {
        public Transform cameraHolder;

        public int maxHeight = 15;
        public int maxWidth = 17;

        public Color col1; // Color of grid "a"
        public Color col2; // Color of grid "b"
        public Color playerColor; // Player color
        public Color energyColor;

        SpriteRenderer mapRenderer;

        GameObject mapObj;
        GameObject playerObj;
        GameObject energyObj;

        SnakeNode playerNode;
        SnakeNode energyNode;

        SnakeNode[,] grid;
        List<SnakeNode> theNodes = new List<SnakeNode>();

        bool up, down, left, right;
        // bool playerMoving; // DEPRECATED

        public float moveRate = 0.5f;
        float timer;

        Dir curDir;
        public enum Dir
        {
            up, down, left, right
        }

        #region Init
        void Start()
        {
            DrawMap();
            SetPlayer();
            SetCamera();
            SpawnEnergy();
            curDir = Dir.right;
        }

        void DrawMap()
        {
            mapObj = new GameObject("Map");
            mapRenderer = mapObj.AddComponent<SpriteRenderer>();

            grid = new SnakeNode[maxWidth, maxHeight];

            Texture2D txt = new Texture2D(maxWidth, maxHeight);
            for (int a = 0; a < maxWidth; a++)
            {
                for (int b = 0; b < maxHeight; b++)
                {
                    Vector3 pp = Vector3.zero; // Esto significa la posición del jugador "pp"
                    pp.x = a;
                    pp.y = b;

                    SnakeNode n = new SnakeNode(){
                        x = a,
                        y = b,
                        mapPos = pp
                    };
                    grid[a, b] = n;

                    theNodes.Add(n);

                    #region Visual 2x2
                    if (a % 2 != 0)
                    {
                        if (b % 2 != 0)
                        {
                            txt.SetPixel(a, b, col1);
                        }
                        else
                        {
                            txt.SetPixel(a, b, col2);
                        }
                    } 
                    else
                    {
                        if (b % 2 != 0)
                        {
                            txt.SetPixel(a, b, col2);
                        }
                        else
                        {
                            txt.SetPixel(a, b, col1);
                        }
                    }
                    #endregion 
                }
            }
            txt.filterMode = FilterMode.Point;
            txt.Apply();

            Rect rect = new Rect(0, 0, maxWidth, maxHeight);
            Sprite sprite = Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);
            mapRenderer.sprite = sprite;
        }

        void SetPlayer()
        {
            playerObj = new GameObject("Player");
            SpriteRenderer playerRender = playerObj.AddComponent<SpriteRenderer>();
            playerRender.sprite = CreateSprite(playerColor);
            playerRender.sortingOrder = 1;

            playerNode = GetNode(3, 3);
            playerObj.transform.position = playerNode.mapPos;

        }

        void SpawnEnergy()
        {
            energyObj = new GameObject("Energy");
            SpriteRenderer energyRenderer = energyObj.AddComponent<SpriteRenderer>();
            energyRenderer.sprite = CreateSprite(energyColor);
            RandomEnergy();
        }

        void SetCamera()
        {
            SnakeNode n = GetNode(maxWidth / 2, maxHeight / 2);
            Vector3 p = n.mapPos;
            p += Vector3.one * .5f;
            cameraHolder.position = p;
        }
        #endregion

        #region Update
        private void Update() 
        {
            GetInput();
            SetDir();

            timer += Time.deltaTime;
            if(timer > moveRate) // Automatic movement by direction
            {
                timer = 0;
                Movement();
            }
        }

        void GetInput()
        {
            up = Input.GetButtonDown("Up");
            down = Input.GetButtonDown("Down");
            left = Input.GetButtonDown("Left");
            right = Input.GetButtonDown("Right");
        }

        void SetDir()
        {
            if(up)
            {
                curDir = Dir.up;
                // playerMoving = true;
            }
            else if(down)
            {
                curDir = Dir.down;
                // playerMoving = true;
            }
            else if(left)
            {
                curDir = Dir.left;
                // playerMoving = true;
            }
            else if(right)
            {
                curDir = Dir.right;
                // playerMoving = true;
            }
        }

        void Movement()
        {
            // if (!playerMoving)
            //     return;

            // playerMoving = false;

            int x = 0;
            int y = 0;

            switch (curDir)
            {
                case Dir.up:
                    y = 1;
                    break;
                case Dir.down:
                    y = -1;
                    break;
                case Dir.left:
                    x = -1;
                    break;
                case Dir.right:
                    x = 1;
                    break;
            }

            SnakeNode targetNode = GetNode(playerNode.x + x, playerNode.y + y);
            if (targetNode == null)
            {
                // Lose
            }
            else
            {
                bool isScore = false;

                if(targetNode == energyNode)
                {
                    isScore = true;
                }

                theNodes.Remove(playerNode);
                playerObj.transform.position = targetNode.mapPos;
                playerNode = targetNode;
                theNodes.Add(playerNode);

                if (isScore) // Tail
                {
                    if (theNodes.Count > 0)
                    {
                        RandomEnergy();
                    }
                    else
                    {
                        // Won
                    }
                }
            }
        }
        #endregion

        #region Utils
        SnakeNode GetNode(int x, int y)
        {
            if(x < 0 || x > maxWidth - 1 || y < 0 || y > maxHeight - 1)
                return null;

            return grid[x, y];
        }

        Sprite CreateSprite(Color targetColor)
        {
            Texture2D txt = new Texture2D(1, 1);
            txt.SetPixel(0, 0, targetColor);
            txt.Apply();
            txt.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, 1, 1);
            return Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);
        }
        #endregion

        #region Env
        void RandomEnergy()
        {
            int r = Random.Range(0, theNodes.Count);
            SnakeNode n = theNodes[r];
            energyObj.transform.position = n.mapPos;
            energyNode = n;
        }
        #endregion
    }
}

