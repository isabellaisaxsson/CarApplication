using CarApplication.Data;
using CarApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

public class Program
{
    private static CarsContext dbContext;

    public static void Main(string[] args)
    {
        dbContext = new CarsContext();

        Console.WriteLine("Välkommen till bil applikationen välj vad du vill göra nedan:(skriv alternativ 1-4)");
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Lägg till en ny bil och dess ägare");
        Console.WriteLine("2. Se lista över bilar");
        Console.WriteLine("3. Se lista över bilägare");
        Console.WriteLine("4. Se lista över bilar och bilägare");

        int answer = int.Parse(Console.ReadLine());
        switch (answer)
        {
            case 1:
                AddCarsWithOwners();
                break;

            case 2:
                ShowCars();
                break;

            case 3:
                ShowOwners();
                break;

            case 4:
                ShowOwnersWithCars();
                break;
        }
    }

    public static void AddCarsWithOwners()
    {
        Console.WriteLine("Bilens registreringsnummer:");
        string RegistrationNr = Console.ReadLine();
        Console.WriteLine("Bilmärke");
        string Make = Console.ReadLine();
        Console.WriteLine("Modell av bilen:");
        string Model = Console.ReadLine();
        Console.WriteLine("Årsmodell:");
        int Year = int.Parse(Console.ReadLine());
        Console.WriteLine("Pris:");
        int Price = int.Parse(Console.ReadLine());


        int ownerId = AddOwner(); // Detta kopplar ihop personId i Customers till Cars

        var newCar = new Cars //Detta refererar till klassen Cars och tilldelar inputsen ovan till variablerna inom Cars klassen
        {
            make = Make,
            model = Model,
            year = Year,
            price = Price,
            registrationNr = RegistrationNr,
            personId = ownerId
        };

        dbContext.Cars.Add(newCar);

        dbContext.SaveChanges();

        Console.WriteLine("Bilen har lagts till i databasen.");

    }

    public static int AddOwner()
    {
        Console.WriteLine("Förnamn:");
        string fName = Console.ReadLine();
        Console.WriteLine("Efternamn:");
        string lName = Console.ReadLine();
        Console.WriteLine("Födelsedag:");
        DateTime BirthDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Antal körkort:");
        byte Licence = (byte)Console.Read();

        var newOwner = new Customer //Refererar till klassen customer och assignar inputsen ovan till de inom customer klassen
        {
            Fname = fName,
            Lname = lName,
            birthDate = BirthDate,
            hasLicence = Licence
        };

        dbContext.Customers.Add(newOwner); //Lägger till alla inputs ovan i listan och i databasen

        dbContext.SaveChanges();

        Console.WriteLine("En ägare har lagts till");

        return newOwner.PersonId;
    }


    public static void ShowCars()
    {
        var cars = dbContext.Cars.ToList();

        foreach (var car in cars)
        {
            Console.WriteLine($"Registreringsnummer: {car.registrationNr}, Märke: {car.make}, Modell: {car.model}, Årsmodell: {car.year}, Pris: {car.price}");
        }
    }

    public static void ShowOwners()
    {
        var owners = dbContext.Customers.ToList();

        foreach (var owner in owners)
        {
            Console.WriteLine($"Förnamn: {owner.Fname}, Efternamn: {owner.Lname}, Födelsedag: {owner.birthDate}, Antal körkort: {owner.hasLicence}");
        }
       
    }

    public static void ShowOwnersWithCars()
    {
        var carsWithOwners = dbContext.Cars //Refererar till cars tabellen i databasen
        .Join( //Metod som sätter ihop två tabeller i en databas
            dbContext.Customers,
            car => car.personId, //Den här och funktionen under matchar ihop de två tabellerna i databasen genom PersonId som är detsamma i båda.
            customer => customer.PersonId,
            (car, customer) => new {Car = car, Owner = customer}) //Funktionen beskriver hur de två tabellerna ska kombineras med varandra
        .ToList();

        foreach(var carWithOwner in carsWithOwners)
        {
            Console.WriteLine($"Registreringsnummer: {carWithOwner.Car.registrationNr}, Ägare: {carWithOwner.Owner.Fname} {carWithOwner.Owner.Lname}");
        }

        
    }

}