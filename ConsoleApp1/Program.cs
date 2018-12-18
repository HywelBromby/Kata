using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Featres.CheckSum.Interfaces;
using Kata.Featres.CheckSum.Services;
using Kata.Features.BankOCR.Interfaces;
using Kata.Features.BankOCR.Parsers;
using Kata.Features.BankOCR.Servcices;
using Kata.Foundation.FileAccess.Interfaces;
using Kata.Foundation.FileAccess.Services;
using Microsoft.Extensions.DependencyInjection;
using QuickNDirty;

namespace ConsoleApp1
{
    class Program
    {
        private static List<string> _accountNumbers;
        /// <summary>
        /// Really simple console test harness
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileParser, FileParser>()
                .AddSingleton<IEntryParser, EntryParser>()
                .AddSingleton<IDigitalNumberParser, DigitalNumberParser>()
                .AddSingleton<IIntegerParser, IntegerParser>()
                .AddSingleton<IBankOCRService, BankOCRService>()
                .AddSingleton<ICheckSumHelper, CheckSumHelper>()
                .BuildServiceProvider();

            var bankOCRService = serviceProvider.GetService<IBankOCRService>();
            var checkSumService = serviceProvider.GetService<ICheckSumHelper>();

            UserStory1(args, bankOCRService);
            
            Console.ReadLine();
        }
        
        private static void UserStory1(string[] args, IBankOCRService bankOCRService)
        {
            var fileName = "C:\\Code\\Kata\\ConsoleApp1\\UserStory1.txt";
            if (args?.Length > 0)
                fileName = args[0];

            _accountNumbers = bankOCRService.GenerateAccountNumbers(fileName).ToList();

            Console.WriteLine("User Story 1 Output");

            foreach (var line in _accountNumbers)
            {
                Console.WriteLine(line);
            }
        }
        
        [Obsolete]
        private static void QuickNDirty(string[] args)
        {
            var fileName = "C:\\Code\\Kata\\ConsoleApp1\\UserStory1.txt";
            if (args?.Length > 0)
                fileName = args[0];

            var response = QuickNDirtyParser.GetNumbers(fileName);

            Console.WriteLine("Quick N Dirty Approach");
            foreach (var line in response)
            {
                Console.WriteLine(line);
            }
        }
    }
}
