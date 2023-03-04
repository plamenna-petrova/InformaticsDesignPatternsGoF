using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Machine
{
    public class VotingMachineV4
    {
        private static readonly Lazy<VotingMachineV4> instance = new Lazy<VotingMachineV4>(() => new VotingMachineV4());

        private int totalVotes = 0;


        private VotingMachineV4()
        {

        }

        public static VotingMachineV4 Instance
        {
            get
            {
                return instance.Value;
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
