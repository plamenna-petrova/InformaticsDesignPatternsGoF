using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Machine
{
    public class VotingMachineV1
    {
        private static VotingMachineV1 instance;

        private int totalVotes = 0;

        public static VotingMachineV1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VotingMachineV1();
                }

                return instance;
            }
        }

        public void RegisterVotes()
        {
            totalVotes++;
            Console.WriteLine($"Registered Vote # {totalVotes}");
        }

        public int TotalVotes { get { return totalVotes; } }
    }
}
