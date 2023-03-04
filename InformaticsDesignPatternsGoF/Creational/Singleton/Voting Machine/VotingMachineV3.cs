using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Machine
{
    public class VotingMachineV3
    {
        private static readonly VotingMachineV3 instance = new VotingMachineV3();

        private int totalVotes = 0;


        private VotingMachineV3()
        {

        }

        public static VotingMachineV3 Instance
        {
            get
            {
                return instance;
            }
        }

        public void RegisterVote()
        {
            totalVotes++;
            Console.WriteLine($"Registered Vote # {totalVotes}");
        }

        public int TotalVotes
        {
            get
            {
                return totalVotes;
            }
        }
    }
}
