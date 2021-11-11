using BethanysPieShopHRM.HR;
using System;
using System.Collections.Generic;

namespace BethanysPieShopHRM
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee bethany = new StoreManager(55156, "Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);
            IEmployee mary = new Manager(748, "Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30);
            JuniorResearcher bobJunior = new JuniorResearcher(11231, "Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17);
            IEmployee kevin = new StoreManager(81131, "Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10);
            IEmployee kate = new StoreManager(100, "Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10);



            List<IEmployee> employees = new List<IEmployee>();
            employees.Add(bethany);
            employees.Add(mary);
            employees.Add(bobJunior);
            employees.Add(kevin);
            employees.Add(kate);
            

            employees.Sort();

            foreach (var employee in employees)
            {
                employee.DisplayEmployeeDetails();
            }

            //mary.AttendManagementMeeting();
        }
    }
}

/* NOTES

C# is a strongly typed language, this means that every variable must be declared. 

The data type set the size and location and memory, and whether its stored on the heap or the stack.

Predefined data types:
- bool
- int
- float
- double
- decimal
- char
- byte
- string
- object

Data types are stored in 2 different ways, either VALUE DATA TYPES (stored on the stack) or REFERENCE DATA TYPES (stored on the heap). Examples:
Predefined Value Data Types: int, bool
User defined Value Data Types: enumeration, struct
Predefined Reference Data Type: string, array
User defined data types: class, interface

Expressions = things on the right of the equals sign.

-- Working with dates --

We must create an instance of datetime, as it is a struct. It has a constructor.

DateTime someDateTime = new DateTime(2021, 03, 28);

DateTime has a LOT of members.

-- Converting data --

Implicit casts: You can assign 1 type to another aslong as the the type being assigned is smaller than the new type. i.e.
int a = 123456789;
long l = a;

Explicit casts: You can assign a type that is bigger than the new type aslong as the actual value fits within the new type by using an explicit cast. 
Careful with this as it'll cause a runtime exception if the value can't fit within the type. i.e.
double d = 123456789.0;
int a = (int) d;

Helpers: 

Helpers are another way to convert Types, but doesn't seem to get used much.

-- Implicit Typing --

With implicit typing the compiler will choose the type based on the expression i.e.

var a  = 123; // this becomes an int
var b = true; // this becomes a bool
var d = 123.0 // this becomes a double

------------- CREATING AND USING STRINGS ------------

Strings are basically an array of chars

Strings are surrounded by "" while single chars are surrounded by ''

Stored on the heap. It's a reference type but still a primitive type.

Few methods to work with strings:

int l = myString.Length; returns the length of a string as an int. This is a property.
string upper = myString.ToUpper(); Sets the string to uppercase
string lower = myString.ToLower(); set the string to lowercase
bool b = myString.Contains("Hello"); Checks if a string contains this string, returns true or false bool
string s = myString.Replace("a","b"); this replaces all a's with b's
string sub = myString.Substring(1, 3); Gets a part of a string (remember strings start at 0) first parameter is where to start and the 2nd is the length
string trim = myString.Trim(); Trim will remove the whitespace from either sides of the characters

-- escape characters --

\n in a string will add a new line
\t in a string will ad a tab
\\ will show a backslash
\" will show a quote

Verbatim strings use an @ before the string. These ignore escape characters but will show the string precisely as typed i.e.

@"Hello Steve! your home drive is located at:
C:\poop
Enjoy your data!"

This will print exactly as typed even though it doesnt have escape characters.
ToUpper or Lower is a great way of comparing strings i.e.

string name = "Dan";
string name2 = "dan";

name.ToUpper() == name2.ToUpper(); // returns true

-- Stringbuilder --

Stringbuilder is a class which can concatenate stringsmore performently here is an example:

StringBuilder stringBuidler = new StringBuilder();
stringBuilder.Append("Employee List");
stringBuilder.AppendLine("John Smith");
stringBuilder.AppendLine("Sally Kona");
stringBuilder.AppendLine("Roxy Latrice");
string list = stringBuilder.ToString();

-- Parsing strings --

Parse and TryParse can be used to try to turn strings into other types i.e.

string wage = "1234";
int wageValue = int.Parse(wage);

That simply performs  a parse, but if it fails itll break the applications. 
Therefore we can use TryParse which also outputs a bool when it fails so you can use an if statement i.e.

int wageValue;
if (int.TryParse(wage, out wageValue))
{
    Console.WriteLine($"Parsing success: {wageValue}");
}
else 
{
    Console.WRiteLine("Parsing failed.");
}

Parsing can also be used for some objets like DateTime

------------ WORKING WITH METHODS ------------

General c# method layout:

<access modifier> <return type> Method_Name(Paramenters)
{
    method statments
}

void = no return type needed

2 examples:

public int AddTwoNumbers(int a, int b)
{
    return a + b;
}

public void DisplayTwoNumbers(int a, int b)
{
    result = a + b;
    Console.WriteLine(result);
}

Methods can have the same names, but if they have a different amount of parameters it will use 
the method which passes the matching amount of arguments i.e.

public static void DisplaySum(int a, int b)
{...}

public static void DisplaySum(int a, int b, int c)
{...}

This is called method overloading

You can use the ref keyword which allows the original value to be used rather than a copy.
Normally the method will create a copy and use the value locally.

public int AddTwoNumbers(int a, ref int b) <- b will affect the variable the is passed through, a will just make a copy
{
    b += 10;
    int sum = a + b;
    return sum;
}

You can use params inside a parameter to accept an array of paramters i.e.

public int AddNumbers(params int[] values)
{
    for (int i = 0; i < values.Length; i++)
    {
        //Add values to calculate
    }
}

To calcluate the average wage of a bunch of wages:

private static int CalculateAverageWage(params int[] wages)
{
int total = 0;
int numberOfWages = wages.Length;

    for (int i = 0; i < values.Length; i++)
    {
        total += wages[i];
    }
 return total / numberOfWages;
}

Optional paramters can also be added by simply defining a default amount. This means you don't need
to pass the arguemnt to the parameter, it will just use the default instead. i.e.

private static int Sum(int a, int b, int c = 100)
{...}

You can use expression syntax for methods that only have a single line of code. This means you dont need to
add the curly brackets or add a return, as it will do this automatically:

public static int CalculateYearlyWage(int monthlyWage, int numbersOfMonthsWorked, int bonus) =>
    monthlyWage * numbresOfMonthsWorked + bonus;

------------ VALUE TYPES AND REFERENCE TYPES ---------------

EVery type is an object.

There are 5 categories of types in the Common TYpe System in .net:
Value types:
- Enumeration
- Struct
Reference types:
- Class
- Interface
- Delegate

EVerything is stored on the stacks but reference types have a reference on the stack to the object in the heap.

Enumeration allows you to assign a value to a name.
This makes it easier to remember what something is rather than just using a number.
The value can be set automatically from index 0 or you can get the value yourself:

enum EmployeeType
{
    Sales, // Value is set to 0
    Manager, //1
    Research, //2
    StoreManager //3
}

enum StoreType
{
    PieCorner = 10,
    Seating = 20,
    FullPieRestaurant = 100,
    Undefined = 99
}

Typically used for lightweight data structures. Can be instanced, basically alightweight class.

struct Employee
{
    public  string Name;
    public int Wage; // these are fields

    public void Work()
    {
        Console.WriteLine($"{Name} is now doing work!);
    }
}

Employee employee;
employee.Name = "Bethany";
employee.Wage = "1234";
employee.Work();

--------- UNDERSTANDING VALUE TYPES AND REFERENCE TYPES ----------- IMPORTANT

A class is a blueprint of an object

Classes are made on the heap not on the stack

Class template:

public class MyClass
{
    public int a;
    public string b;

    public void MyMethod()
    {
        Console.WriteLine("I'm a method");
    }
}

Contents of a class:
Fields: class level variables
Methods: A function within a class
Properties: Used to wrap fields
Events: Something to notify other classes when something happens i.e. a button click

Access modifiers:
Public: Can be accessed anywhere outside of the class
Private: Can only be accessed within the class
Protected: Can only be accessed within the class and inherited classes

Creating a new object or instance of an object:
Employee employee = new Employee(); // creates a new object called employee of the Employee class

Constructors:
Special method that is called whenever an instance of an object is created, it is used to set initial values
Constructor is just a method that has the same name as a class name i.e.

public class Employee
{
    public string firstName;
    public int age;

    poublic Employee(string name, int ageValue)
    {
        firstName = name;
        age = ageValue;
    }
}

Using this to create a new object:
Employee employee = new Employee("Bethany", 35);

employee.PerformWork(); // use a method of an object
employee.firstName = "Bethany" // set a field of an object
int wage = employee.RecieveWage(); // return a value from a method to a variable from an object

Objects are reference types so you can point multiple variable to the same object i.e.

Employee employee1 = new Employee();
employee1.firstName = "John";

Employee employee2 = employee1;
employee2.firstName = "Steve";

Console.WriteLine(employee1.firstName); // this will print Steve, as both variables are pointing to the same objects

--- Properties ---

Properties allow your fields to have logic and use PascalCase.
They're often used to allow other classes to access the value but not change it.

private string firstName; // this cannot be changed by other classes now

public string FirstName
{
    get { return firstName; }
    set
    {
        firstName = value; // value is a keyword which passes the value entereted in. For example if another
                              class invoked employee.FirstName = "Steve"; Steve would be passed in.
    }
}

---- DOING MORE WITH CUSTOM TYPES ----

Namespaces seperate classes out on another level. This stops naming collissions.
Can use the using statement to include it in your code.

Static values is on the class level, not the object level. 
This means that all objects of the class will share the same static field or method.

so if a class has a field called
public static int armLength = 3;

this means that every object created will have and share the same armLength;

The const modifier is always static but can't be changed from anywhere, even inside the class.

-- null --

Can set things to null which means they have no value.
Also can use ? after a type to allow it to have its usual value range but also have null. For example:
int? nullableInt = null;

 - Summary

 Namspaces are used to group classes
 Static data is class level data
 references can be null
 garbage collector deletes objects in memory that have no reference autmatically

 ---- APPLYING INHERITENCE TO C# CLASSES ----

 Inheritence allws you to create subclasses of classes, very important concept with OOP
 Easy way to understand this is:

 Employees is the main class but
 Manager, Researher, Sales Person are sub classes

 The advantage is that you can reuse code. We will need the employee data about Managers, Researchers andSales Persons
 But those roles will need extra fields and methods for themselves as they do different things thatn just the main role

 How to derive a class from a main class:

 public class Employee
 {
 }

 public class Manager: Employee
 {
 }

 The subclass inherits everything from the main class. So manager gets everything that Employee has.

 Revisiting access modifiers:
 Protected allows the subclass to access the main class members. But other classes cannot access them.

 All subclasses must pass values to the base constructor otherwise it wont construct. 
 You can do this by creating a constructor for the subclass, then calling the base class constructor
 with a colon : base and passing the values through. See below for example.

Employee class constructor:
public Employee(int empId, string first, string last, string em, DateTime bd, double? rate) // constructer sets all of the fields of the object
{
    Id = empId;
    FirstName = first;
    LastName = last;
    Email = em;
    BirthDay = bd;
    HourlyRate = rate ?? 10;
}


Manager subclass constructor:
public Manager(int id, string first, string last, string em, DateTime bd, double? rate) : base(id, first, last, em, bd, rate)
{
}

The "is a" concept. Subclasses are simple is a, for example Manager is an employee or Research is an employee.

-- Polymorphism --

Polymorphism is overriding a base class method with a new implementation

We need 2 new access modifiers to do this, virtual and override. 
The base class method must be set to virtual, and the sub class method must be set to override with the same
method name. i.e.

public class Employee
{
    public virtual void PerformWork()
    {...}
}

public class Manager: Employee
{
    public override void PerformWork()
    {...}
}

C# will always use the most specific method, so if its a manager then it will use the overrided method.
This happens even if the manager was defined as an Employee type. However if a manager is defined with
an Employee type he will not be able to use his own methods. If he was declared like this:

Employee manager = new Manager();
rather than
Manager manager = new Manager();

 -- Sealed Classes --

 Sealed classes are not allowed to be inherited from it. It's just an access modifier:

 public sealed class NoInheritence
 {
 }

 -- Abstract Classes --

 Abstract classes can't be instantiated. They just represent a concept and you'er meant to create subclasses
 offf of them. You can then instantiate the subclasses.

 Every method that is used in a subclass off of a base class must be overridden.

Abstract methods cannot have a body as they're just overridden anyway.

------------ INTERFACES ------------

Can't be instantiated 
USes interface keyword
Name starts with I

sample:

public interface IEmployee
{
    void PerformWork()
    {

    }
}

This will force the class that takes on the interface to have a PerformWork Method

TO use an interface on a class just use a colon:

public class Employee: IEmployee

-- built in interfaces



*/