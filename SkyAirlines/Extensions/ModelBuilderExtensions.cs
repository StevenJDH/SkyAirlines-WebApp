using Microsoft.EntityFrameworkCore;
using SkyAirlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyAirlines.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().HasData(
                new Passenger { PassengerId = 1, FirstName = "John", LastName = "Doe", Passport = "837568289", DOB = new DateTime(1980, 12, 31), PhoneNumber = "15005550000", Email = "jdoe@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 2, FirstName = "Jenny", LastName = "Dowers", Passport = "385648365", DOB = new DateTime(1981, 01, 15), PhoneNumber = "15015550001", Email = "jdowers@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 3, FirstName = "David", LastName = "Row", Passport = "121493498", DOB = new DateTime(1982, 02, 10), PhoneNumber = "15025550002", Email = "drow@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 4, FirstName = "Anny", LastName = "Jones", Passport = "982433847", DOB = new DateTime(1983, 03, 05), PhoneNumber = "15035550003", Email = "ajones@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 5, FirstName = "Steven", LastName = "Jenkins", Passport = "999999999", DOB = new DateTime(1984, 04, 01), PhoneNumber = "15045550004", Email = "sjenkins@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 6, FirstName = "Rachel ", LastName = "Doe", Passport = "123456789", DOB = new DateTime(1985, 05, 25), PhoneNumber = "15055550005", Email = "rdoe@email.com", CheckedBaggage = true },
                new Passenger { PassengerId = 7, FirstName = "Frank", LastName = "Stanly", Passport = "111111111", DOB = new DateTime(1986, 06, 20), PhoneNumber = "15065550006", Email = "fstanly@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 8, FirstName = "Jack", LastName = "Bowe", Passport = "101010101", DOB = new DateTime(1987, 07, 15), PhoneNumber = "15075550007", Email = "jbowe@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 9, FirstName = "Christina", LastName = "Lake", Passport = "987654321", DOB = new DateTime(1988, 05, 10), PhoneNumber = "15085550008", Email = "clake@mail.com", CheckedBaggage = true },
                new Passenger { PassengerId = 10, FirstName = "Jenny", LastName = "Divers", Passport = "567894321", DOB = new DateTime(1989, 06, 05), PhoneNumber = "15095550009", Email = "jdivers@mail.com", CheckedBaggage = true }
            );

            modelBuilder.Entity<Aircraft>().HasData(
                new Aircraft { AircraftId = 1, AircraftModel = "A380-800", AircraftCapacity = 853 },
                new Aircraft { AircraftId = 2, AircraftModel = "747-8", AircraftCapacity = 700 },
                new Aircraft { AircraftId = 3, AircraftModel = "747-400", AircraftCapacity = 624 },
                new Aircraft { AircraftId = 4, AircraftModel = "777-300", AircraftCapacity = 550 },
                new Aircraft { AircraftId = 5, AircraftModel = "777-200", AircraftCapacity = 440 },
                new Aircraft { AircraftId = 6, AircraftModel = "A320", AircraftCapacity = 150 },
                new Aircraft { AircraftId = 7, AircraftModel = "A319", AircraftCapacity = 126 },
                new Aircraft { AircraftId = 8, AircraftModel = "A321", AircraftCapacity = 192 },
                new Aircraft { AircraftId = 9, AircraftModel = "A320", AircraftCapacity = 150 },
                new Aircraft { AircraftId = 10, AircraftModel = "A320", AircraftCapacity = 150 }
            );

            modelBuilder.Entity<Airport>().HasData(
                new Airport { AirportId = 1, AirportCode = "ATT", AirportName = "Atmautluak" },
                new Airport { AirportId = 2, AirportCode = "LAS", AirportName = "Mccarran International" },
                new Airport { AirportId = 3, AirportCode = "AOK", AirportName = "Karpathos" },
                new Airport { AirportId = 4, AirportCode = "BEO", AirportName = "Belmont" },
                new Airport { AirportId = 5, AirportCode = "CDG", AirportName = "Charles De Gaulle" },
                new Airport { AirportId = 6, AirportCode = "DDP", AirportName = "Dorado Beach" },
                new Airport { AirportId = 7, AirportCode = "ESR", AirportName = "El Salvador" },
                new Airport { AirportId = 8, AirportCode = "FRF", AirportName = "Rhein-Main AFB" },
                new Airport { AirportId = 9, AirportCode = "GFK", AirportName = "Grand Forks" },
                new Airport { AirportId = 10, AirportCode = "HBH", AirportName = "Hobart Bay" }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight { FlightPrefix = "SA", FlightId = 11000, AircraftId = 10, AirportId = 1, Departure = new DateTime(2017, 06, 01, 17, 20, 00), Arrival = new DateTime(2017, 07, 01, 19, 50, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11010, AircraftId = 9, AirportId = 2, Departure = new DateTime(2017, 07, 01, 16, 15, 00), Arrival = new DateTime(2017, 07, 01, 18, 45, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11020, AircraftId = 8, AirportId = 3, Departure = new DateTime(2017, 07, 01, 15, 10, 00), Arrival = new DateTime(2017, 07, 01, 17, 40, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11030, AircraftId = 7, AirportId = 4, Departure = new DateTime(2017, 07, 01, 14, 05, 00), Arrival = new DateTime(2017, 07, 01, 17, 50, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11040, AircraftId = 6, AirportId = 5, Departure = new DateTime(2017, 07, 01, 13, 00, 00), Arrival = new DateTime(2017, 07, 01, 18, 55, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11050, AircraftId = 5, AirportId = 6, Departure = new DateTime(2017, 07, 02, 12, 35, 00), Arrival = new DateTime(2017, 07, 02, 19, 00, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11060, AircraftId = 4, AirportId = 7, Departure = new DateTime(2017, 07, 02, 11, 30, 00), Arrival = new DateTime(2017, 07, 02, 20, 10, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11070, AircraftId = 3, AirportId = 8, Departure = new DateTime(2017, 07, 02, 10, 25, 00), Arrival = new DateTime(2017, 07, 02, 21, 15, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11080, AircraftId = 2, AirportId = 9, Departure = new DateTime(2017, 07, 02, 09, 20, 00), Arrival = new DateTime(2017, 07, 02, 22, 10, 00) },
                new Flight { FlightPrefix = "SA", FlightId = 11090, AircraftId = 1, AirportId = 10, Departure = new DateTime(2017, 07, 02, 08, 15, 00), Arrival = new DateTime(2017, 07, 02, 23, 25, 00) }
            );

            modelBuilder.Entity<Manifest>().HasData(
                new Manifest { FlightPrefix = "SA", FlightId = 11000, PassengerId = 1, Seat = "A01" },
                new Manifest { FlightPrefix = "SA", FlightId = 11010, PassengerId = 2, Seat = "B02" },
                new Manifest { FlightPrefix = "SA", FlightId = 11020, PassengerId = 3, Seat = "C03" },
                new Manifest { FlightPrefix = "SA", FlightId = 11030, PassengerId = 4, Seat = "D04" },
                new Manifest { FlightPrefix = "SA", FlightId = 11040, PassengerId = 5, Seat = "A10" },
                new Manifest { FlightPrefix = "SA", FlightId = 11050, PassengerId = 6, Seat = "G01" },
                new Manifest { FlightPrefix = "SA", FlightId = 11060, PassengerId = 7, Seat = "H02" },
                new Manifest { FlightPrefix = "SA", FlightId = 11070, PassengerId = 8, Seat = "I03" },
                new Manifest { FlightPrefix = "SA", FlightId = 11080, PassengerId = 9, Seat = "J04" },
                new Manifest { FlightPrefix = "SA", FlightId = 11090, PassengerId = 10, Seat = "K05" }
            );

        }
    }
}
