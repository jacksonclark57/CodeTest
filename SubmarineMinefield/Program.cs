using System;

namespace SubmarineMinefield
{
    class Program
    {
        static void Main(string[] args)
        {

            //declare all variables
            int[,,] SatelliteData = GetSatelliteData();
            double watersubratio;
            double subenemyratio;
            bool Attack;

            //display all surface sub densities

            watersubratio = SubCount(SatelliteData, 0);
            Console.WriteLine("Surface sub density       -  {0}",watersubratio);

            watersubratio = SubCount(SatelliteData, 1);
            Console.WriteLine("underwater sub density    -  {0}", watersubratio);

            watersubratio = SubCount(SatelliteData, 2);
            Console.WriteLine("Deep sub  density         -  {0}", watersubratio);

            //display ratio
            subenemyratio = SubRatio(SatelliteData);
            Console.WriteLine("Sub / Enemy Sub Ratio     -  {0}", subenemyratio);

            //show attack data
            Attack = AttackCheck(SatelliteData,0);
            Console.WriteLine("Go for surface attack     -  {0}",Attack);

            Attack = AttackCheck(SatelliteData, 1);
            Console.WriteLine("Go for underwater attack  -  {0}", Attack);

            Attack = AttackCheck(SatelliteData, 2);
            Console.WriteLine("Go for deepwater attack   -  {0}", Attack);

            // Dislay full battelfield
            WriteSea(SatelliteData);





            //display battlefield






        }
        static int[,,] GetSatelliteData()
        {
            Random rand = new Random();
            int[,,] data = new int[10, 10, 3];

            for (int z = 0; z < data.GetLength(2); z++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    for (int x = 0; x < data.GetLength(0); x++)
                    {
                        if (rand.Next(0, 101) < 25)
                        {
                            data[x, y, z] = rand.Next(1, 3);

                        }//end if

                    }//end for
                }//end for
            }//end for
            return data;
        }//end get satelite data
        static double SubCount(int [,,] GetsatelliteData,int level)
        {
            int subcount = 0;
            for (int x = 0; x < GetsatelliteData.GetLength(1); x++)
            {
                for (int y = 0; y < GetsatelliteData.GetLength(0); y++)
                {
                
                    if (GetsatelliteData[x, y,level] != 0)
                    {
                    subcount += 1;

                    }
                }

            }
            return subcount / 100.0;
        }
        static bool  AttackCheck(int[,,] GetSatelliteData,int level)
        {
            int goodguy = 0;
            int badguy = 0;
            

            for (int x = 0; x < GetSatelliteData.GetLength(1); x++)
            {
                for (int y = 0; y < GetSatelliteData.GetLength(0); y++)
                {
                    if (GetSatelliteData[x, y,level ] == 1) goodguy += 1;
                    else if (GetSatelliteData[x, y,level ] == 2) badguy += 1;

                }
            }

            if (goodguy > badguy) return true;
            else return false;
        }
        static void WriteSea(int[,,] GetsatelliteData)
        {
            for (int z = 0; z < GetsatelliteData.GetLength(2); z++)
            {
                Console.WriteLine();
                if (z == 0)
                {
                    Console.WriteLine("Surface Level");

                }
                if (z == 1)
                {

                    Console.WriteLine(); 
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("The shallow waters");
                }
                if (z == 2)
                {

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("The Dark Deep");
                }
                for (int y = 0; y < GetsatelliteData.GetLength(1); y++)
                {
                    if (y != 0) Console.WriteLine();
                    for (int x = 0; x <GetsatelliteData.GetLength(0); x++)
                    {
                        Console.Write(GetsatelliteData[x,y,z] + " ");
                    }
                 }
                
             }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static double SubRatio(int[,,] GetsatelliteData)
        {
            double goodguy = 0;
            double badguy = 0;


            for (int z = 0; z < GetsatelliteData.GetLength(2); z++)
            {
                for (int x = 0; x < GetsatelliteData.GetLength(1); x++)
                {
                    for (int y = 0; y < GetsatelliteData.GetLength(0); y++)
                    {
                        if (GetsatelliteData[x, y, z] == 1) goodguy += 1;
                        else if (GetsatelliteData[x, y, z] == 2) badguy += 1;
                    }

                }
            }
            return goodguy / badguy;


            

            


        }




    }
}
