using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joppens_djur
{
    class Program
    {
        static void Main(string[] args)
        {
            PETOWNER run = new PETOWNER();
            run.Menu();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }
    }
    class PETOWNER
    {
        string returnvalueff = "";
        string returninput = "";
        public List<Animal> pet_list = new List<Animal>();
        public List<Toys> Toy_list = new List<Toys>();
        int temp = 0;

        public void Menu()
        {
            Toys rb = new Toys("rb");
            Toys wb = new Toys("wb");
            Toys sb = new Toys("sb");
            Toy_list.Add(rb);
            Toy_list.Add(wb);
            Toy_list.Add(sb);
            pet_list.Add(new Dog(5, "dog", "snoopy", "chicken", "husky"));
            pet_list.Add(new Cat(3, "cat", "snuggles", "fish", "scottish fold"));
            pet_list.Add(new Kitten(5, "kitten", "mike", "milk", "scottish fold"));
            pet_list.Add(new Puppy(9, "puppy", "pato", "milk", "lab"));
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to jopps house");
                Console.WriteLine();
                Console.WriteLine("Press 1 to Play with animals");
                Console.WriteLine();
                Console.WriteLine("Press 2 to Feed animals");
                Console.WriteLine();
                Console.WriteLine("Press 3 to List animals");
                Console.WriteLine();
                Console.WriteLine("Press 4 to Check Ball quailty ");
                Console.WriteLine();
                Console.WriteLine("Press 5 to Exit ");
                temp = int.Parse(Console.ReadLine());
                switch (temp)
                {
                    case 1:
                        Fetach();
                        break;
                    case 2:
                        Feed();
                        break;
                    case 3:
                        List_animals();
                        break;
                    case 4:
                        Check_Toy();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }

            } while (temp != 0);

        }

        public void List_animals()
        {
            foreach (Animal i in pet_list)
            {
                if (i is Dog)
                {
                    Console.WriteLine("The " + i.returanimalname() + " name is " + i.returpetname() + " and it is " + i.returnage() + " years old. It likes " + i.returnfood() + " it is a " + i.returnbreed());
                }
                else if (i is Cat)
                {
                    Console.WriteLine("The " + i.returanimalname() + " name is " + i.returpetname() + " and it is " + i.returnage() + " years old. It likes " + i.returnfood() + " it is a " + i.returnbreed());
                }
                else if (i is Puppy)
                {
                    Console.WriteLine("The " + i.returanimalname() + " name is " + i.returpetname() + " and it is " + i.returnage() + " months old old. It likes " + i.returnfood() + " it is a " + i.returnbreed());
                }
                else if (i is Kitten)
                {
                    Console.WriteLine("The " + i.returanimalname() + " name is " + i.returpetname() + " and it is " + i.returnage() + " months old. It likes " + i.returnfood() + " it is a " + i.returnbreed());
                }
            }
        }
        public void Feed()
        {
            Console.WriteLine("which animal do you want to feed ? Type in your response.");
            Console.WriteLine("cat");
            Console.WriteLine("dog");
            Console.WriteLine("puppy");
            Console.WriteLine("kittten");
            string animal_feed = Console.ReadLine();
            foreach (var i in pet_list)
            {
                if (animal_feed == i.returanimalname())
                {
                    Console.WriteLine("The " + animal_feed + " usually eats " + i.returnfood());
                    Console.WriteLine();
                    Console.WriteLine("type in the food which you want to feed to the " + animal_feed);
                    returninput = Console.ReadLine();
                    returnvalueff = i.returnfood();
                    string returnname = i.returanimalname();
                    bool returnhungry = i.Eat(returnvalueff, returninput, animal_feed, returnname);
                    i.animal_hungry(returnhungry);
                    break;
                }

            }

        }
        public void Check_Toy()
        {
            Console.WriteLine("Which toy do you want to check qulity of");
            Console.WriteLine("Type rb for Rubber ball");
            Console.WriteLine("Type Wb for a wollen ball");
            Console.WriteLine("Type sb for a square(box)");
            string toy_inputname = Console.ReadLine();
            foreach (var i in Toy_list)
            {
                if (toy_inputname == i.returntoyname())
                {
                    int qualityvalue = +i.getquality();
                    Console.WriteLine("The quality of {0} is {1}", toy_inputname, qualityvalue);
                }
            }
            Console.WriteLine("For the toys quality of toys to exist you must play with the animals first");
        }

        public void Fetach()
        {
            string animal_toy;
            Console.WriteLine("which animal do you want to play with? Type in your response.");
            Console.WriteLine("cat");
            Console.WriteLine("dog");
            Console.WriteLine("puppy");
            Console.WriteLine("kittten");
            string animal_fetch = Console.ReadLine();
            foreach (var p in pet_list)
            {
                if (animal_fetch == p.returanimalname())
                {
                    Console.WriteLine("Choose the shape of the toy to play with the {0} type in your reponse", p.returanimalname());
                    Console.WriteLine();
                    Console.WriteLine("Type rb for a rubber ball");
                    Console.WriteLine("Type Wb for a wollen ball");
                    Console.WriteLine("Type sb for a square(box)");
                    animal_toy = Console.ReadLine();
                    foreach (var i in Toy_list)
                    {
                        if (i.returntoyname() == animal_toy)
                        {
                            p.interact(i, animal_fetch);
                            break;
                        }
                    }
                }
            }

        }

    }
    class Toys
    {
        int tq;
        string toy_name;
        public Toys(string _name)
        {
            toy_name = _name;
        }
        public string returntoyname()
        {
            return toy_name;
        }
        public int lower_quality(int qt)
        {
            return tq = qt + tq;
        }
        public int getquality()
        {
            return tq;
        }

    }
    class Animal
    {
        int age;
        string petname;
        string fav_food;
        string breed;
        string animalname;
        bool hungry;

        public Animal(int _age, string _animalname, string _petname, string _fav_food, string _breed)
        {
            age = _age;
            animalname = _animalname;
            petname = _petname;
            fav_food = _fav_food;
            breed = _breed;
        }
        public int returnage()
        {
            return age;
        }
        public string returanimalname()
        {
            return animalname;
        }
        public string returpetname()
        {
            return petname;
        }
        public string returnfood()
        {
            return fav_food;
        }
        public string returnbreed()
        {
            return breed;
        }
        public bool Eat(string returnvalueff, string returninput, string animal_feed, string returnname)
        {
            if (animal_feed == returnname)
            {
                if (returninput != returnvalueff)
                {
                    hungry = true;
                }
                else
                {
                    hungry = false;
                }
            }
            return hungry;
        }
        public virtual void animal_hungry(bool hungry)
        {

        }
        public virtual void interact(Toys rb, string animal_fetch)
        {


        }

    }
    class Dog : Animal
    {
        public Dog(int _age, string _animalname, string _petname, string _fav_food, string _breed) : base(_age, _animalname, _petname, _fav_food, _breed)
        {
            _animalname = "Dog";
        }
        public override void animal_hungry(bool hungry)
        {
            if (hungry == true)
            {
                Console.WriteLine();
                Console.WriteLine("dog doesn't want to eat feed it is's favorit food ");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Dog is fed it says woof woof");
            }

        }
        public override void interact(Toys t, string animal_fetch)
        {
            if (t.returntoyname() == "rb")
            {
                Console.WriteLine("dog likes ball says woof woof tail wiggling");
                t.lower_quality(-3);
            }
            else if (t.returntoyname() == "wb")
            {
                Console.WriteLine("Dog doesn't like it doens't play with it");
            }
            else if (t.returntoyname() == "sb")
            {
                Console.WriteLine("Dog hasn't seen this toy but is intersted");
                t.lower_quality(-1);
            }

        }
    }
    class Puppy : Animal
    {
        public Puppy(int _age, string _animalname, string _petname, string _fav_food, string _breed) : base(_age, _animalname, _petname, _fav_food, _breed)
        {
        }
        public override void animal_hungry(bool hungry)
        {
            if (hungry == true)
            {
                Console.WriteLine();
                Console.WriteLine("puppy doesn't want to eat feed it is's favorit food ");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("puppy is fed it says woof woof");
            }

        }
        public override void interact(Toys t, string animal_fetch)
        {
            if (t.returntoyname() == "rb")
            {
                Console.WriteLine("puppy likes ball");
                t.lower_quality(-1);
            }
            else if (t.returntoyname() == "wb")
            {
                Console.WriteLine("Puppy doesn't want to play");
            }
            else if (t.returntoyname() == "sb")
            {
                Console.WriteLine("Puppy goes into the box and hides");
            }

        }
    }
    class Cat : Animal
    {
        public Cat(int _age, string _animalname, string _petname, string _fav_food, string _breed) : base(_age, _animalname, _petname, _fav_food, _breed)
        {

        }
        public override void animal_hungry(bool hungry)
        {
            if (hungry == true)
            {
                Console.WriteLine();
                Console.WriteLine("Cat doesn't like the food so it will go chase a mouse ");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("cat is fed it says meow");
            }

        }
        public override void interact(Toys t, string animal_fetch)
        {
            if (t.returntoyname() == "wb")
            {
                Console.WriteLine("The cat says mawaaa!!");
                t.lower_quality(-3);

            }
            else if (t.returntoyname() == "rb")
            {
                Console.WriteLine("The doesn't like would prefer a wollen ball *hisses*");
            }
            else if (t.returntoyname() == "sb")
            {
                Console.WriteLine("Cat likes it tries fit inside");
                t.lower_quality(-2);
            }

        }

    }
    class Kitten : Animal
    {
        public Kitten(int _age, string _animalname, string _petname, string _fav_food, string _breed) : base(_age, _animalname, _petname, _fav_food, _breed)
        {

        }
        public override void animal_hungry(bool hungry)
        {
            if (hungry == true)
            {
                Console.WriteLine();
                Console.WriteLine("Kitten doesn't want to eat feed it is's favorit food ");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("kitten is fed it says woof woof");
            }

        }
        public override void interact(Toys t, string animal_fetch)
        {
            if (t.returntoyname() == "wb")
            {
                Console.WriteLine("The Kitten says mawaaa");
                t.lower_quality(-3);
            }
            else if (t.returntoyname() == "rb")
            {
                Console.WriteLine("The doesn't like would prefer a wollen ball *hisses*");
            }
            else if (t.returntoyname() == "sb")
            {
                Console.WriteLine("Kitten likes it  will try to fit inside");
                t.lower_quality(-2);
            }
        }
    }
}

