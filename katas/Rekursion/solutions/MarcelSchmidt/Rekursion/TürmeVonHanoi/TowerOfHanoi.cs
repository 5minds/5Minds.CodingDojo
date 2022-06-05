using Infrastructure;
using Infrastructure.Module;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TürmeVonHanoi
{
    public class TowerOfHanoi : BaseModule
    {
        public TowerOfHanoi(string moduleName, bool solved = false) : base(moduleName)
        {
            if (solved)
            {
                // Init last stack with all disks in correct order
                _gameStacks[^1].Content.AddRange(_gameDisks.OrderByDescending(x => x.Size).ToList());
            }
        }

        private readonly List<GameStack> _gameStacks = new List<GameStack>()
        {
            new GameStack(),
            new GameStack(),
            new GameStack(),
        };

        private readonly List<GameDisk> _gameDisks = new List<GameDisk>()
        {
            new GameDisk(1),
            new GameDisk(2),
            new GameDisk(3),
            new GameDisk(4),
            new GameDisk(5),
            new GameDisk(6),
            new GameDisk(7),
            new GameDisk(8),
        };

        protected override void Process()
        {
            // Init first stack with all disks
            _gameStacks[0].Content.AddRange(_gameDisks.OrderByDescending(x => x.Size).ToList());

            ProcessGame();
        }

        private void ProcessGame()
        {
            DisplayGameBoard();

            if (!EvaluateUserInput())
            {
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }

            if (CheckWinCondition())
            {
                DisplayGameBoard();
                Console.WriteLine("-------------------------");
                Console.WriteLine("Congratulations you won!");
                Console.WriteLine("-------------------------");
                return;
            }

            ProcessGame();
        }

        private bool EvaluateUserInput()
        {
            Console.WriteLine("\nSelect a stack to take from (1/2/3...)");
            var input = Console.ReadLine();

            var isValidInput = int.TryParse(input, out int selectedStackTake);
            if (!isValidInput || selectedStackTake < 1 || selectedStackTake > _gameStacks.Count)
            {
                Console.WriteLine("Error: Invalid input detected! >> {0}", input);
                return false;
            }

            if (!_gameStacks[selectedStackTake - 1].Content.Any())
            {
                Console.WriteLine("Error: Invalid operation detected >> Stack {0} is empty!", selectedStackTake);
                return false;
            }

            var selectedDisk = _gameStacks[selectedStackTake - 1].Content.Peek();

            Console.WriteLine("Select a stack (1/2/3...) to place selected disk (size {0})", selectedDisk.Size);
            input = Console.ReadLine();

            isValidInput = int.TryParse(input, out int selectedStackPlace);
            if (!isValidInput || selectedStackPlace < 1 || selectedStackPlace > _gameStacks.Count)
            {
                Console.WriteLine("Error: Invalid input detected! >> {0}", input);
                return false;
            }

            if (selectedStackPlace == selectedStackTake)
            {
                Console.WriteLine("Error: Invalid operation detected. >> Same stack selected {0}!", selectedStackTake);
                return false;
            }

            var selectedStackPlaceContent = _gameStacks[selectedStackPlace - 1].Content;
            if (selectedStackPlaceContent.Any() && selectedStackPlaceContent.Peek().Size < selectedDisk.Size)
            {
                Console.WriteLine("Error: Invalid operation detected. >> Stack already contains a smaller disk! {0} > {1}",
                    selectedDisk.Size,
                    selectedStackPlaceContent.Peek().Size);
                return false;
            }

            var gameDisk = _gameStacks[selectedStackTake - 1].Content.Pop();
            _gameStacks[selectedStackPlace - 1].Content.Push(gameDisk);

            return true;
        }

        private void DisplayGameBoard()
        {
            Console.Clear();
            Console.WriteLine(ModuleName);

            for (var i = 0; i < _gameStacks.Count; i++)
            {
                Console.Write("\nStack {0}:", i + 1);

                foreach (var disk in _gameStacks[i].Content.Reverse())
                {
                    Console.Write("|-{0}-|", disk.Size);
                }
            }

            Console.WriteLine();
        }

        private bool CheckWinCondition()
        {
            var lastStackDisks = _gameStacks.Last().Content;
            if (lastStackDisks.Count != _gameDisks.Count)
                return false;

            var expectedSize = _gameDisks.Max(x => x.Size);
            foreach (var disk in lastStackDisks.Reverse())
            {
                if (disk.Size != expectedSize)
                    return false;

                expectedSize--;
            }

            return true;
        }
    }
}
