using System;
using static System.Console;

namespace ModifyConstantsAndReadOnly
{
    class ROExample {
        public readonly string readoString = "I cannot be changed";
    }

    class Program
    {
        public const string constString = "I cannot be changed";

		static unsafe void Main (string[] args) {
            // modify const strings
            WriteLine(constString);
            StringManipulation(constString, "I can be changed   ");
            WriteLine(constString);

            // modify readonly strings
            ROExample rx = new();

            WriteLine(rx.readoString);
            StringManipulation(rx.readoString, "I can be changed   ");
            WriteLine(rx.readoString);
		}

        static unsafe void StringManipulation(string str, string to_this) {
            fixed(char* ps = str)
                for (int i = 0; i < str.Length; i++) {
                    ps[i] = to_this[i];
                }

            WriteLine(str);
        }

	}
}
