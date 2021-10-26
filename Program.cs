using System;
using System.Collections.Generic;

namespace H2CodingExam2
{
    class Program
    {
        EndUser user;
        Validator validator;

        public Program(Validator validator, EndUser user)
        {
            validator.SetUser(user);
            this.validator = validator;
            this.user = user;

        }

        static void Main(string[] args)
        {
            
            EndUser user = new EndUser("Buts");
            Validator validator = new Validator();
            Program newProgram = new Program(validator, user);

            newProgram.Start();

            //Evaluate
            Console.WriteLine("EVALUATING");
            validator.Evaluate();
        }

        public void Start()
        {
            Console.WriteLine("You have to input 5 numbers between 1-600");
            string input = string.Empty;
            
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Please input #" + (i + 1) + ": ");
                input = Console.ReadLine();
                user.AddInput(validator.Validate(input));
            }
        }
    }

    class Validator
    {
        EndUser user;
        List<int> primeList = new List<int>();


        public Validator()
        {
            InitializePrimes();
        }

        public void SetUser(EndUser user)
        {
            this.user = user;
        }

        public void InitializePrimes()
        {
            bool hasOtherFactors = false;
            for (int i = 2; i < 601; i++)
            {
                for(int j = 2; j < i; j++)
                {
                    if(i%j == 0)
                    {
                        hasOtherFactors = true;
                        break;
                    }
                }
                if (!hasOtherFactors)
                {
                    primeList.Add(i);
                    Console.Write($", " + i);
                }

                hasOtherFactors = false;
            }
        }

        private int GetNearestPrime(int input)
        {
            int nearestPrime = 0;
            foreach (int prime in primeList)
            {
                if(Math.Abs(input - prime) < Math.Abs(input - nearestPrime))
                {
                    nearestPrime = prime;
                }
            }
            return nearestPrime;
        }

        public int Validate(string input)
        {
            int output = 0;
            int.TryParse(input, out output);
            if (output != 0 && (output >= 1 && output <= 600))
            {
                return output;
            }
            else
            {
                return 0;
            }
        }

        public void Evaluate()
        {
            List<int> inputList = user.GetInputs();
            bool isOdd = false;
            int nearestPrime = 0;
            foreach (int input in inputList)
            {
                isOdd = (input % 2 == 1);
                nearestPrime = GetNearestPrime(input);
                

                if (input != 0) {
                    Console.WriteLine("Input " + input + " is " + (isOdd ? "Odd" : "Even")+
                        ". its nearest prime number is: "+ nearestPrime);
                }

                else
                {
                    Console.WriteLine("INVALID");
                }
            }
        }
    }

    class EndUser
    {
        string name;
        List<int> inputList;

        public EndUser(string name)
        {
            this.name = name;
            inputList = new List<int>();
        }

        public void AddInput(int input)
        {
            inputList.Add(input);
        }

        public List<int> GetInputs()
        {
            return inputList;
        }
    }
}
