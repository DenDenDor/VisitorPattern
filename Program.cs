using System.Collections.Generic;
using System.Reflection;
using System;

namespace Visitor
{
    public class Program
    {
        static void Main(string[] args)
        {
                Village village = new Village();
                village.AddEntity(new Cat("Матроскин", 5));
                village.AddEntity(new Dog("Шарик", 2));
                village.AddEntity(new Farmer("Игорь", "Печкин", 45));
                village.Talk(new Visitor());
            System.Console.ReadLine();
        }
    }
    public class Village
    {
       private List<IEntity> _entities = new List<IEntity>();
       public void AddEntity(IEntity entity) => _entities.Add(entity);
       public void RemoveEntity(IEntity entity) => _entities.Remove(entity);
       public void Talk(IVisitor visitor)=> _entities.ForEach(e => e.Accept(visitor));

    }
    public interface IEntity
    {
        void Accept(IVisitor visitor);
    }
    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; init; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    public abstract class Person
    {
        public string FirstName { get; set; }
         public string LastName { get; set; }
          public int Age { get; set; }
        public Person(string firstName, string lastName, int age)
        {
            FirstName =firstName;
            LastName =lastName;
            Age =age;
        }
    }
    public class Farmer : Person, IEntity
    {
        public Farmer(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Live(this);
        }
    }
    public class Cat : Animal, IEntity
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Live(this);
        }
    }
    public class Dog : Animal, IEntity
    {
        public Dog(string name, int age) : base(name, age)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Live(this);
        }
    }
   public interface IVisitor
    {
       void Live(Cat cat);
       void Live(Dog dog);
       void Live(Farmer farmer);
   }
    public  class Visitor : IVisitor
    {
        public void Live(Cat cat)
        {
            System.Console.WriteLine($"Mya Mya,  I am {cat.Name} and i like milk! I am {cat.Age} years old.");
        }
        public void Live(Dog dog)
       {
            System.Console.WriteLine($"Gav Gav,  I am {dog.Name} and i really like running!  I am {dog.Age} years old.");
        }
        public void Live(Farmer farmer)
        {
            System.Console.WriteLine($"I am {farmer.FirstName} {farmer.LastName}. I love my animals, they are good! I am {farmer.Age} years old!");
        }
    }

}
