using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KarnelTravelAgency.Core
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {            
        }
        // Add DbSet properties for each model

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public DbSet<TransportCompany> TransportCompanies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }

        public DbSet<Resort> Resorts { get; set; }
        public DbSet<ResortRoom> ResortRooms { get; set; }
        public DbSet<ResortGuest> ResortGuests { get; set; }
        public DbSet<ResortReservation> ResortReservations { get; set; }
        public DbSet<ResortActivity> ResortActivities { get; set; }
        public DbSet<ResortReservationActivity> ResortReservationActivities { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<RestaurantCustomer> RestaurantCustomers { get; set; }
        public DbSet<RestaurantReservation> RestaurantReservations { get; set; }
        public DbSet<RestaurantMenuItem> RestaurantMenuItems { get; set; }
        public DbSet<RestaurantOrderItem> RestaurantOrderItems { get; set; }
        public DbSet<RestaurantPayment> RestaurantPayments { get; set; }

        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }
        public DbSet<PackageService> PackageServices { get; set; }
        public DbSet<PackageActivity> PackageActivities { get; set; }
        public DbSet<PackageMeal> PackageMeals { get; set; }

        // Add DbSet properties for the remaining models

    }
}
