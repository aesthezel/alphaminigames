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
        int tailPoint;

        public Color col1; // Color of grid "a"
        public Color col2; // Color of grid "b"
        public Color playerColor; // Player color
        public Color energyColor;

        SpriteRenderer mapRenderer;

        Sprite playerSprite;

        GameObject mapObj;
        GameObject playerObj;
        GameObject playerTail;
        GameObject energyObj;

        SnakeNode playerNode;
        SnakeNode prevPlayerNode;
        SnakeNode energyNode;

        SnakeNode[,] grid;

        List<SnakeNode> theNodes = new List<SnakeNode>();
        List<SnakeSpecial> snakeTail = new List<SnakeSpecial>();

        bool up, down, left, right;
        // bool playerMoving; // DEPRECATED

        public float moveRate = 0.5f;
        float timer;

        Dir targetDir;
        Dir currentDir;
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
            targetDir = Dir.right;
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
            playerSprite = CreateSprite(playerColor);
            playerRender.sprite = playerSprite;
            playerRender.sortingOrder = 1;
            playerNode = GetNode(3, 3);

            LocatePlayerObject(playerObj, playerNode.mapPos);
            playerObj.transform.localScale = Vector3.one * 1.2f;

            playerTail = new GameObject("Tail");

        }

        void SpawnEnergy()
        {
            energyObj = new GameObject("Energy");
            SpriteRenderer energyRenderer = energyObj.AddComponent<SpriteRenderer>();
            energyRenderer.sprite = CreateSprite(energyColor);
            energyRenderer.sortingOrder = 1; // FIX: Spawn in the same layer of player
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
            SetPlayerDir();

            timer += Time.deltaTime;
            if(timer > moveRate) // Automatic movement by direction
            {
                timer = 0;
                currentDir = targetDir;
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

        void SetPlayerDir()
        {
            if(up)
            {
                SetDir(Dir.up);
                // playerMoving = true;
            }
            else if(down)
            {
                SetDir(Dir.down);
                // playerMoving = true;
            }
            else if(left)
            {
                SetDir(Dir.left);
                // playerMoving = true;
            }
            else if(right)
            {
                SetDir(Dir.right);
                // playerMoving = true;
            }
        }

        void SetDir(Dir d)
        {
            if(!isOpp(d))
            {
                targetDir = d;
            }

        }

        void Movement()
        {
            // if (!playerMoving)
            //     return;

            // playerMoving = false;

            int x = 0;
            int y = 0;

            switch (currentDir)
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
                if(isBitedByYourself(targetNode))
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

                    SnakeNode prevNode = playerNode;
                    theNodes.Add(prevNode);

                    if (isScore)
                    {
                        tailPoint++;
                        snakeTail.Add(CreateTailNode(prevNode.x, prevNode.y));
                        theNodes.Remove(prevNode);
                    }

                    MoveTail();

                    LocatePlayerObject(playerObj, targetNode.mapPos);
                    playerNode = targetNode;
                    theNodes.Remove(playerNode);

                    if (isScore)
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
        }

        void MoveTail()
        {
            SnakeNode prevNode = null;

            for (int t = 0; t < snakeTail.Count; t++)
            {
                SnakeSpecial s = snakeTail[t];
                theNodes.Add(s.node);

                if (t == 0)
                {
                    prevNode = s.node;
                    s.node = playerNode;
                }
                else
                {
                    SnakeNode prevAlt = s.node;
                    s.node = prevNode;
                    prevNode = prevAlt;
                }

                theNodes.Remove(s.node);
                LocatePlayerObject(s.superObj, s.node.mapPos);
            }
        }
        #endregion

        #region Env
        void LocatePlayerObject(GameObject obj, Vector3 loc)
        {
            loc += Vector3.one * .5f;
            obj.transform.position = loc;
        }

        void RandomEnergy()
        {
            int r = Random.Range(0, theNodes.Count);
            SnakeNode n = theNodes[r];
            LocatePlayerObject(energyObj, n.mapPos);
            energyNode = n;
        }
        #endregion

        #region Conditionals
        bool isOpp(Dir d)
        {
            switch (d)
            {
                default:
                case Dir.up:
                    if(currentDir == Dir.down)
                        return true;
                    else
                        return false;
                case Dir.down:
                    if(currentDir == Dir.up)
                        return true;
                    else
                        return false;
                case Dir.left:
                    if(currentDir == Dir.right)
                        return true;
                    else
                        return false;
                case Dir.right:
                    if(currentDir == Dir.left)
                        return true;
                    else
                        return false;
            }
        }

        bool isBitedByYourself(SnakeNode n)
        {
            for (int t = 0; t < snakeTail.Count; t++)
            {
                if(snakeTail[t].node == n)
                {
                    return true;
                }
            }
            return false;
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
            return Sprite.Create(txt, rect, Vector2.one * .5f, 1, 0, SpriteMeshType.FullRect);
        }

        SnakeSpecial CreateTailNode(int x, int y)
        {
            SnakeSpecial s = new SnakeSpecial();
            s.node = GetNode(x, y);
            s.superObj = new GameObject("Nested Tail " + tailPoint);
            s.superObj.transform.parent = playerTail.transform;
            s.superObj.transform.position = s.node.mapPos;
            s.superObj.transform.localScale = Vector3.one * .95f;
            SpriteRenderer r = s.superObj.AddComponent<SpriteRenderer>();
            r.sprite = playerSprite;
            r.sortingOrder = 1; // Tail spawn backward the player

            return s;
        }
        #endregion
    }
}

