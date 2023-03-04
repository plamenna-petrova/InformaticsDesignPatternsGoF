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
            //    firstVotingMachineV1.RegisterVote();
            //    secondVotingMachineV1.RegisterVote();
            //    thirdVotingMachineV1.RegisterVote();
            //}

            //Console.WriteLine($"Total votes: {firstVotingMachineV1.TotalVotes}");

            var numbers = Enumerable.Range(0, 10);

            // asynchronous calls

            //Parallel.ForEach(numbers, i =>
            //{
            //    var votingMachineV1 = VotingMachineV1.Instance;
            //    votingMachineV1.RegisterVote();
            //});

            //Console.WriteLine($"Total votes: {VotingMachineV1.Instance.TotalVotes}");

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV2 = VotingMachineV2.Instance;
                votingMachineV2.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV2.Instance.TotalVotes}");

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV3 = VotingMachineV3.Instance;
                votingMachineV3.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV3.Instance.TotalVotes}");

            Parallel.ForEach(numbers, i =>
            {
                var votingMachineV4 = VotingMachineV4.Instance;
                votingMachineV4.RegisterVote();
            });

            Console.WriteLine($"Total votes: {VotingMachineV4.Instance.TotalVotes}");
        }
    }
}
