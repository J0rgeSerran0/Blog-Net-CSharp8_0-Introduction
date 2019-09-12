using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp80
{
    public class Program
    {

        private static string[] _myArray = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };

        public static void Main(string[] args)
        {
            // Index and Ranges
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Index and Ranges");
            IndexRangesBefore80();
            Index();
            Ranges();
            IndexAndRanges();
            RangesWithStrings();
            RangesWithClasses();
            PrintSeparators();

            // Static Local Functions
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Static Local Functions");
            var response = LocalFunctionBefore80();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(response);
            response = StaticLocalFunction();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(response);
            PrintSeparators();
            
            // Using Declarations
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Using Declarations");
            Console.ForegroundColor = ConsoleColor.Green;
            ReadFile();
            PrintSeparators();

            // Default Interface Members
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Default Interface Members");
            Console.ForegroundColor = ConsoleColor.Green;
            DefaultInterfaceMembers();
            PrintSeparators();

            // Readonly Members
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Readonly Members");
            Console.ForegroundColor = ConsoleColor.Green;
            var personStruct = new PersonStruct("Peter", 29);
            personStruct.Age = 31;
            Console.WriteLine(personStruct.GetPerson());
            PrintSeparators();

            // Pattern Matching - Switch Expressions
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pattern Matching - Switch Expressions");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(GetSwitchExpressions("Peter"));
            Console.WriteLine(GetSwitchExpressions("Mary"));
            Console.WriteLine(GetSwitchExpressions("Other"));
            Console.WriteLine(GetSwitchExpressions());
            PrintSeparators();

            // Pattern Matching - Property Patterns
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pattern Matching - Property Patterns");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Discount for John with Id 1: {PatternMatchingPropertyPatterns(new Person() { IdDiscount = 1, Name = "John" }) * 100}%");
            Console.WriteLine($"Discount for Rose with Id 2: {PatternMatchingPropertyPatterns(new Person() { IdDiscount = 2, Name = "Rose" }) * 100}%");
            Console.WriteLine($"Discount for Mary with Id 3: {PatternMatchingPropertyPatterns(new Person() { IdDiscount = 3, Name = "Mary" }) * 100}%");
            try
            {
                Console.WriteLine($"null as {PatternMatchingPropertyPatterns(null)}%");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            PrintSeparators();

            // Pattern Matching - Tuple Patterns
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pattern Matching - Tuple Patterns");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"12 Celsius to Fahrenheit: {PatternMatchingTuplePatterns(Temperature.Celsius, Temperature.Fahrenheit, 12)}");
            Console.WriteLine($"57 Fahrenheit to Celsius: {PatternMatchingTuplePatterns(Temperature.Fahrenheit, Temperature.Celsius, 57)}");
            Console.WriteLine($"12 Celsius to Celsius: {PatternMatchingTuplePatterns(Temperature.Celsius, Temperature.Celsius, 12)}");
            Console.WriteLine($"57 Fahrenheit to Fahrenheit: {PatternMatchingTuplePatterns(Temperature.Fahrenheit, Temperature.Fahrenheit, 57)}");
            PrintSeparators();

            // Pattern Matching - Positional Patterns
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pattern Matching - Positional Patterns");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"John with 10: {PatternMatchingPositionalPatterns(new Student() { Name = "John", Grade = 10 })}");
            Console.WriteLine($"Mary with 10: {PatternMatchingPositionalPatterns(new Student() { Name = "Mary", Grade = 10 })}");
            Console.WriteLine($"Mary with 0: {PatternMatchingPositionalPatterns(new Student() { Name = "Mary", Grade = 0 })}");
            Console.WriteLine($"Mike with 0: {PatternMatchingPositionalPatterns(new Student() { Name = "Mike", Grade = 0 })}");
            Console.WriteLine($"Anne with 1: {PatternMatchingPositionalPatterns(new Student() { Name = "Anne", Grade = 1 })}");
            Console.WriteLine($"null as: {PatternMatchingPositionalPatterns(null)}");
            PrintSeparators();

            // Disposable red structs
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Disposable red structs");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Without special code => see the {nameof(MyStruct)} struct to see this");
            Console.WriteLine($"Adding {nameof(MyStruct.Dispose)} the struct will be disposable");
            PrintSeparators();

            // Asynchronous Streams
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Asynchronous Streams");
            Console.ForegroundColor = ConsoleColor.Green;
            // This is not a good practice
            UseTraditionalAsyncStreamsAsync().Wait();
            // New feature
            UseAsyncStreamsAsync().Wait();
            PrintSeparators();

            // Null coalescing assignment
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Null coalescing assignment");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Without special code => see the {nameof(NullCoalescingAssignment)} method for more details");
            Console.ForegroundColor = ConsoleColor.Green;
            NullCoalescingAssignment();
            PrintSeparators();

            // Nullable reference types
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Nullable reference types");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Without special code => see the {nameof(NullableReferenceTypes)} method and the csproj");
            NullableReferenceTypes();
            PrintSeparators();

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private static void PrintSeparators()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new String('.', 48) + Environment.NewLine);
        }

        private class Person
        {
            public int IdDiscount { get; set; }
            public string Name { get; set; }
        }

        private class Student
        {
            public string Name { get; set; }
            public int Grade { get; set; }

            public void Deconstruct(out string name, out int grade) => (name, grade) = (Name, Grade);
        }

        private enum Temperature
        {
            Celsius,
            Fahrenheit
        }

        private class Employee
        {
            public string? Name { get; set; }
        }

        #region Index and Ranges

        private static void IndexRangesBefore80()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before v8.0 (using Count and Index simulation):");
                Console.ForegroundColor = ConsoleColor.Green;
                var first = _myArray[0];
                var last = _myArray[_myArray.Count() - 1];
                Console.WriteLine($"First element: {first}");
                Console.WriteLine($"Last element: {last}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before v8.0 (using Linq and Range simulation):");
                var myOtherArray = _myArray.Skip(2).Take(6).ToArray();
                ShowArrayData(myOtherArray);
            }

            private static void Index()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Use of Index:");
                Console.ForegroundColor = ConsoleColor.Green;
                Index first = 0; // list[0]
                Index last = ^1; // list[^1]
                // Showing => One
                Console.WriteLine($"First element: {_myArray[first]}");
                // Showing => Ten
                Console.WriteLine($"Last element: {_myArray[last]}");
            }

            private static void Ranges()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Use of Range:");
                // Showing => Three, Four, Five, Six, Seven, Eight, Nine, Ten
                var myOtherArray = _myArray[2..];
                ShowArrayData(myOtherArray);            
            }

            private static void IndexAndRanges()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Use of Index and Ranges:");
                // Getting the last elements
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Getting the last 4 elements");
                var myOtherArray = _myArray[^4..];
                ShowArrayData(myOtherArray);
            }

            private static void RangesWithStrings()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Use of Range with Strings:");
                var message = "Hello, this is a sample text";
                // Showing => "sample text"
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Original text: '{message}'");
                Console.WriteLine($"Text: '{message[^11..^0]}'");
            }

            private static void RangesWithClasses()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Use of Range with Classes:");
                var people = new Person[] 
                {
                    new Person() { IdDiscount = 0, Name = "Peter" },
                    new Person() { IdDiscount = 1, Name = "Mary" },
                    new Person() { IdDiscount = 2, Name = "John" },
                    new Person() { IdDiscount = 3, Name = "Anna" },
                    new Person() { IdDiscount = 4, Name = "Jonas" },
                    new Person() { IdDiscount = 5, Name = "Rose" },
                    new Person() { IdDiscount = 6, Name = "Lya" }
                };
                // Showing => "John, Anna, Jonas"
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var person in people[2..^2])
                {
                    Console.WriteLine($"Name: '{person.Name}'");
                }
            }

            private static void ShowArrayData(string[] array)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in array)
                {
                    Console.WriteLine($"Element: {item}");
                }
            }

        #endregion

        #region Static Local Functions

            public static string LocalFunctionBefore80()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Before v8.0 [7.2 or greater] (using Local Function):");
                var name = "Tom";
                var age = 27;
                return MyLocalFunction();
                string MyLocalFunction() => $"{name} is {age} years old";
            }

            public static string StaticLocalFunction()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Using Static Local Function:");
                var name = "Tom";
                var age = 27;
                return MyLocalFunction(name, age);
                static string MyLocalFunction(string myName, int myAge) => $"{myName} is {myAge} years old";
            }

        #endregion

        #region Using Declarations

            private static void ReadFile()
            {
                try
                {
                    using var reader = new StreamReader(new FileStream(@"C:\TEMP\sample.txt", FileMode.Open));
                    Console.WriteLine(reader.ReadToEnd());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Probably the sample.txt file is missing.");
                    Console.WriteLine(@"Create the file sample.txt in C:\TEMP\ to execute this method without errors");
                    Console.WriteLine($"{ex.Message}");
                }
            }

        #endregion

        #region Default Interface Members

            public interface ISample
            {
                string MyMethod(string name, DateTime registerdAt);
                
                //// Uncomment this code to see the problem extending the class:
                //string MyMethod(string name);

                //// Uncomment this code to see that the problem is missing now:
                //string MyMethod(string name) => MyMethod(name, DateTime.UtcNow);
            }

            public class MySample : ISample
            {
                public string MyMethod(string name, DateTime registerdAt) => $"{name.ToUpper()} at {registerdAt}";
            }

            private static void DefaultInterfaceMembers()
            {
                ISample sample = new MySample();
                Console.WriteLine(sample.MyMethod("Peter", DateTime.UtcNow));
            }

        #endregion

        #region Readonly Members

            public struct PersonStruct
            {
                private string _name;
                //// To force the warning, comment this line and uncomment the next one
                public readonly string Name { get => _name; }
                //public string Name { get => _name; }

                public int Age;

                public PersonStruct(string name, int age)
                {
                    _name = name;
                    Age = age;
                }

                //// Uncomment this line and comment the next one
                //// to see the error in Visual Studio
                //public readonly string GetPerson()
                public string GetPerson()
                {
                    _name = Name.ToUpper();

                    return $"{Name} is {Age} years old";
                }

                public readonly override string ToString() => $"{Name} is {Age} years old";
            }

        #endregion

        #region Pattern Matching - Switch Expressions

            private static string GetSwitchExpressions(string name) => name switch
            {
                "Peter" => "Is Peter",
                "Mary" => "Is Mary",
                _ => "Unknown"
            };

            private static string GetSwitchExpressions()
            {
                int caseSwitch = 1;

                return caseSwitch switch
                {
                    1 => "Value 1",                
                    _ => "Unknown Value"
                };
            }

        #endregion

        #region Pattern Matching - Property Patterns

            private static decimal PatternMatchingPropertyPatterns(Person person) => person switch
            {
                { IdDiscount: 1 } => 0.2M,
                { IdDiscount: 2 } => 0.1M,
                _ => 0M
                //// Comment the previous line and uncomment the next lines
                //// to study the behaviour for null
                //{ } => 0M,
                //null => throw new ArgumentNullException(nameof(Person))
            };

        #endregion

        #region Pattern Matching - Tuple Patterns

            private static double PatternMatchingTuplePatterns(Temperature temperatureOrigin, Temperature temperatureDestiny, double temperature) 
                => (temperatureOrigin, temperatureDestiny) switch
            {
                (Temperature.Celsius, Temperature.Fahrenheit) => (temperature * 9) / 5 + 32,
                (Temperature.Fahrenheit, Temperature.Celsius) => (temperature - 32) * 5 / 9,
                _ => temperature
            };

        #endregion

        #region Pattern Matching - Positional Patterns

            private static string PatternMatchingPositionalPatterns(object o) => o switch
            {
                Student(_, 10) => "Excelent",
                Student("Mary", 0) => "Fail",
                Student(var name, var grade) => "Other",
                _ => "Unknown"
            };

        #endregion

        #region Disposable red structs

            ref struct MyStruct
            {
                public void Dispose() { }
            }

        #endregion

        #region Asynchronous Streams

            private static async Task UseTraditionalAsyncStreamsAsync()
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                foreach (var data in await GetTraditionalDataAsync())
                {
                    Console.WriteLine($"{nameof(UseTraditionalAsyncStreamsAsync)} - {data} - {watch.ElapsedMilliseconds}");
                }

                watch.Stop();
                var elapsedMilliseconds = watch.ElapsedMilliseconds;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{nameof(UseTraditionalAsyncStreamsAsync)} - {elapsedMilliseconds}ms");
                Console.ForegroundColor = ConsoleColor.Green;
            }
            
            private static async Task<IEnumerable<int>> GetTraditionalDataAsync()
            {
                var data = new List<int>();

                for (var i = 1; i <= 5; i++)
                {
                    // Simulate a delay for show how it works. 
                    await Task.Delay(350);
                    data.Add(i);
                }

                return data;
            }

            private static async Task UseAsyncStreamsAsync()
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                await foreach (var data in GetDataAsync())
                {
                    Console.WriteLine($"{nameof(UseAsyncStreamsAsync)} - {data} - {watch.ElapsedMilliseconds}");
                }

                watch.Stop();
                var elapsedMilliseconds = watch.ElapsedMilliseconds;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{nameof(UseAsyncStreamsAsync)} - {elapsedMilliseconds}ms");
                Console.ForegroundColor = ConsoleColor.Green;
            }

            private static async IAsyncEnumerable<int> GetDataAsync()
            {
                for (var i = 1; i <= 5; i++)
                {
                    // Simulate a delay for show how it works. 
                    await Task.Delay(350);
                    yield return i;
                }
            }

        #endregion

        #region NullCoalescingAssignment

            private static void NullCoalescingAssignment()
            {
                string variable = null;

                //// Method 1
                //if (variable == null)
                //{
                //    variable = "method 1";
                //}

                //// Method 2
                //variable = variable ?? "method 2";

                // Method 3 (new)
                variable ??= "method 3";

                Console.WriteLine($"{nameof(variable)} => {variable}");
            }

        #endregion

        #region Nullable Reference Types       

        // Uncomment the csproj and/or the #nullable
        // directives to simulate this feature

        // CS8600: Converting null literal or possible null value to non-nullable type
        private static void NullableReferenceTypes()
            {
                //#nullable enable
                string data = null;
                //#nullable restore

                //// Uncomment to generate an execution exception
                //var result = ConvertToUpper(data);
                //Console.WriteLine(result);                
            }

            private static string ConvertToUpper(string data)
            {            
                return data.ToUpper();
            }

            // CS8602: Possible dereference of a null reference
            private static void PossibleDereferenceNullableReferenceTypes()
            {
                //#nullable enable
                string data = null;
                Console.WriteLine(data?.Length);
                //#nullable restore
            }

            // CS8603: Possible null reference return.
            //private static string? PosibleNullableReferenceTypes()
            private static string PossibleNullableReferenceTypes()
            {
                var collection = new List<string>();
                //return collection.Count > 0 ? collection[0] : null;
                return collection.Count > 0 ? collection[0] : String.Empty;
            }

            // CS8604: Possible null reference argument for parameter xxx
            private static void PosibleArgumentNullableReferenceTypes()
            {
                Person? person = new Person() { IdDiscount = 1, Name = "John" };
                Console.WriteLine(person!.Name);

                string data = null;            
                var result = ConvertToUpper(data);
            }

            // NullForgivingOperator
            private static void NullForgivingOperator()
            {
                Employee? person = GetEmployee();
                // Use of the operator !
                // to avoid a CS8602 code
                // Here we should have sure that person.Name is not null
                Console.WriteLine(person!.Name);
            }

            private static Employee? GetEmployee()
            {
                return new Employee() { Name = "John" };
            }

        #endregion

    }

}