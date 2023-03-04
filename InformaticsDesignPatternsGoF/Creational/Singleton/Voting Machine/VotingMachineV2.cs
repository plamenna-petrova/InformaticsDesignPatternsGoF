using System;
using System.Collections.Generic;
using System.Text;

namespace Voting_Machine
{
    public class VotingMachineV2
    {
        private static VotingMachineV2 instance;

        private int totalVotes = 0;

        private static readonly object lockObject = new object();

        private VotingMachineV2()
        {

        }

        public static VotingMachineV2 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new VotingMachineV2();
                        }
                    }
                }

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
