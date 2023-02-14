using System;
using System.Collections.Generic;
namespace DataSctructures_SortingAlgorithms.Classes
{
    public class RandomGenerator: Random
    {
        //properties
        private static RandomGenerator instance = null;
        private RandomGenerator() : base() { }
        //constructor and is singleton as we don't need to generate every time for each sort
        // each build we generate once and use for all sorts
        public static RandomGenerator Get_Instance()
        {
            if(instance == null)
            {
                instance = new RandomGenerator();
            }
            return instance;
        }
    }
}
