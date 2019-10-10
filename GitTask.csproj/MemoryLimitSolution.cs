using System;
using System.Collections.Generic;

namespace GitTask
{
    public class MemoryLimitSolution
    {
        public int[] mainArray;
        public List<int[]> commitsArray;
        public MemoryLimitSolution(int filesCount)
        {
            mainArray = new int[filesCount];
            commitsArray = new List<int[]>();
        }

        public void Update(int fileNumber, int value)
        {
            mainArray[fileNumber] = value;
            //throw new System.NotImplementedException();
        }

        public int Commit()
        {
            int[] originalValues = (int[])this.mainArray.Clone();
            commitsArray.Add(originalValues);
            return commitsArray.Count - 1;
            //throw new System.NotImplementedException();
        }

        public int Checkout(int commitNumber, int fileNumber)
        {
            if (commitNumber > commitsArray.Count - 1)
                throw new ArgumentException();
            int[] commitNumberArray = (int[])commitsArray[commitNumber];
            return commitNumberArray[fileNumber];
            //throw new System.NotImplementedException();
        }
    }
}