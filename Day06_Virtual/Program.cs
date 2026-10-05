Animal a = new Dog();
Dog d = new Dog();

a.Speak();
d.Speak();

class Animal
{
    public virtual void Speak() { Console.WriteLine("動物叫"); }
}

class Dog : Animal
{
    public override void Speak() { Console.WriteLine("汪汪"); }
}
