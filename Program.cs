using System;
using System.Collections.Generic;

namespace H2CodingExam2
{
    class Program
    {
        EndUser user;

        public Program(EndUser user)
        {
            this.user = user;
        }

        static void Main(string[] args)
        {
            
            EndUser user = new EndUser("Buts");
            Validator validator = new Validator(user);
            Program newProgram = new Program(user);

            Console.WriteLine("You have to input 5 numbers between 1-600");
            string input = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Please input #" + (i+1) + ": ");
                input = Console.ReadLine();
                validator.Validate(input);
            }

            //Evaluate
            Console.WriteLine("EVALUATING");
            validator.Evaluate();
        }
    }

    class Validator
    {
        EndUser user;
        public Validator(EndUser user)
        {
            this.user = user;
        }

        public bool Validate(string input)
        {
            int output = 0;
            int.TryParse(input, out output);
            if (output != 0 && (output >= 1 && output <= 600))
            {
                user.AddInput(output);
                return true;
            }
            else
            {
                user.AddInput(0);
                return false;
            }
        }

        public void Evaluate()
        {
            List<int> inputList = user.GetInputs();
            bool isOdd = false;
            int prime = 0;
            foreach (int input in inputList)
            {
                isOdd = (input % 2 == 1);
                prime = Math.Abs((input % 78) * 2 - 74); 

                if (input != 0) {
                    Console.WriteLine("Input " + input + "is " + (isOdd ? "Odd" : "Even")+
                        ". its nearest prime number is: "+ prime);
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
