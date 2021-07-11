using System;

namespace LifeGame
{
    public class Automaton
    {
        private int XSize { get; set; }
        private int YSize { get; set; }
        private int[,] CellInfo { get;  set; }

        public Automaton(int xSize = 16, int ySize = 16)
        {
            XSize = xSize;
            YSize = ySize;
            CellInfo = new int[XSize + 2, YSize + 2];

            CellInit();
        }

        private void CellInit()
        {
            for (int i = 0; i < YSize + 2; i++)
            {
                for (int j = 0; j < XSize + 2; j++)
                {
                    CellInfo[j, i] = -1;
                }
            }

            for (var i = 1; i < YSize + 1; i++)
            {
                for (var j = 1; j < XSize + 1; j++)
                {
                    CellInfo[j, i] = new Random().Next(2);
                }
            }
        }

        public void Update()
        {
            var nextCellInfo = CellInfo;
            
            var neighbor = new (int, int)[]
            {
                (-1, 1), (0, 1), (1, 1),
                (-1, 0), (1, 0),
                (-1, -1), (0, -1), (1, -1)
            };
            
            for (var i = 1; i < YSize + 1; i++)
            {
                for (var j = 1; j < XSize + 1; j++)
                {
                    var live = 0;
                    for (var k = 0; k < neighbor.Length; k++)
                    {
                        var cellStatus = CellInfo[j + neighbor[k].Item1, i + neighbor[k].Item2];
                        if (cellStatus == 1)
                        {
                            live++;
                        }
                    }

                    switch (CellInfo[j, i])
                    {
                        case 0 when live == 3:
                        case 1 when live == 2 || live == 3:
                            nextCellInfo[j, i] = 1;
                            break;
                        case 1 when live < 2 || live > 3:
                            nextCellInfo[j, i] = 0;
                            break;
                        default:
                            nextCellInfo[j, i] = CellInfo[j, i];
                            break;
                    }
                }
            }
   
            CellInfo = nextCellInfo;
        }

        public void Print()
        {
            for (int i = 1; i < XSize + 1; i++)
            {
                for (int j = 1; j < YSize + 1; j++)
                {
                    Console.Write(CellInfo[i, j] == 1 ? "■" : "□");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}