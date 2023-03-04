using System;
using System.Linq;
using System.Threading.Tasks;

namespace Voting_Machine
{
    public class Program
    {
        static void Main(string[] args)
        {
            //VotingMachineV1 firstVotingMachineV1 = VotingMachineV1.Instance;
            //VotingMachineV1 secondVotingMachineV1 = VotingMachineV1.Instance;
            //VotingMachineV1 thirdVotingMachineV1 = VotingMachineV1.Instance;

            //for (int i = 0; i < 3; i++)
            //{
            //    firstVotingMachineV1.RegisterVotes();
            //    secondVotingMachineV1.RegisterVotes();
            //    thirdVotingMachineV1.RegisterVotes();
            //}

            //Console.WriteLine($"Total votes: {firstVotingMachineV1.TotalVotes}");

            var numbers = Enumerable.Range(0, 10);

            // asynchronous calls

            Parallel.ForEach(numbers, i =>
            {
                var votingMachine = VotingMachineV1.Instance;
                votingMachine.RegisterVotes();
            });

            Console.WriteLine($"Total votes: {VotingMachineV1.Instance.TotalVotes}");
        }
    }
}
