
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

//string[] heroes = { "sheriff", "civilian", "doctor" };

//Random rnd = new Random();
//int randomIndex = rnd.Next(0, heroes.Length);

//string hero = heroes[randomIndex];                               //bad example
//Console.WriteLine($"Today {hero} saves the day");

//string[] villains = { "mafia", "don" };

//randomIndex = rnd.Next(0, villains.Length);

//string villain = villains[randomIndex];
//Console.WriteLine($"Today {villain} tries to take over the world");



string folderPath = @"C:\data\";
string heroFile = "heroes";
string villainFile = "villains";
string weaponFile = "weapons";
string herowpFile = "herowp";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile)); 
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapons = File.ReadAllLines(Path.Combine(folderPath, weaponFile));
string[] heroWP = File.ReadAllLines(Path.Combine(folderPath, herowpFile));
//string[] heroes = { "sheriff", "civilian", "doctor" };
//string[] villains = { "mafia", "don" };
//string[] weapons = { "gun", "katana", "sword", "hands" };


string hero = GetRandomValue(heroes);
string heroWeapon = GetRandomValue(heroWP);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;

Console.WriteLine(heroes.Length);

Console.WriteLine($"Today {hero} ({heroHP} HP) saves the day with {heroWeapon}");

string villain = GetRandomValue(villains);
string villainWeapon = GetRandomValue(weapons);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) tries to take over the world with {villainWeapon}");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValue(string[] someArray)
{
        Random rnd = new Random();
        int randomIndex = rnd.Next(0, someArray.Length);       //scope
        string randomStringFromArray = someArray[randomIndex];
        return randomStringFromArray;

}
static int  GetCharacterHP(string characterName)
{
    if (characterName.Length < 5)
    {
        return 5;
    }
    else
    {
        return characterName.Length;
    }
}
static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);
    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target");
    }
    else if(strike == characterHP - 1) 
    {
        Console.WriteLine($"{characterName} made a critical hit.");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}
