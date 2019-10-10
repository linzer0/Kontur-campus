using System;
using System.Collections.Generic;
using System.Linq;

namespace GitTask
{
    public class Git
    {
        public Dictionary<int, int> mainArray;
        public List<Dictionary<int, int>> commitsArray;
        public int commitsArrayLength;

        public Git(int filesCount)
        {
            mainArray = new Dictionary<int, int>();
            commitsArray = new List<Dictionary<int, int>>();
            commitsArrayLength = 0;
        }

        public void Update(int fileNumber, int value)
        {
            mainArray[fileNumber] = value;
        }

        public int Commit()
        {
            commitsArray.Add(new Dictionary<int, int>(mainArray));
            commitsArrayLength++;
            return commitsArrayLength - 1;
        }

        public int Checkout(int commitNumber, int fileNumber)
        {
            if (commitNumber > commitsArrayLength - 1)
                throw new ArgumentException();

            Dictionary<int, int> commitNumberArray = commitsArray[commitNumber];
            int tempVariable;
            if (commitNumberArray.TryGetValue(fileNumber, out tempVariable))
            {
                return commitNumberArray[fileNumber];
            }
            else
            {
                return 0;
            }

        }
    }
}