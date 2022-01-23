using Microsoft.EntityFrameworkCore;
using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Fish> Fishs { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatLoad> BoatLoads { get; set; }

        public DbSet<BoatLoadDetails> BoatLoadDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }

        public DbSet<PurchaseBatch> PurchaseBatchs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Fish>().HasData(new Fish { FishId = 1, FishName = "Tilapia", Quantity = 100 });
            modelBuilder.Entity<Fish>().HasData(new Fish { FishId = 2, FishName = "Mackerel", Quantity = 100 });
            modelBuilder.Entity<Fish>().HasData(new Fish { FishId = 3, FishName = "Grouper", Quantity = 100 });

            modelBuilder.Entity<Boat>().HasData(new Boat { BoatId = 1, BoatName = "Boat 1", BoatCaptain = "Captain 1" });
            modelBuilder.Entity<Boat>().HasData(new Boat { BoatId = 2, BoatName = "Boat 2", BoatCaptain = "Captain 2" });
            modelBuilder.Entity<Boat>().HasData(new Boat { BoatId = 3, BoatName = "Boat 3", BoatCaptain = "Captain 3" });

            modelBuilder.Entity<Agent>().HasData(new Agent
            {
                AgentId = 1,
                AgentName = "Agent 1",
                AgentEmail = "Agent1@gmail.com",
                AgentPhone = "0995514212",
                AgentAddress = "Agent 1 Address"
            });
            modelBuilder.Entity<Agent>().HasData(new Agent
            {
                AgentId = 2,
                AgentName = "Agent 2",
                AgentEmail = "Agent2@gmail.com",
                AgentPhone = "0995514212",
                AgentAddress = "Agent 2 Address"
            });
            modelBuilder.Entity<Agent>().HasData(new Agent
            {
                AgentId = 3,
                AgentName = "Agent 3",
                AgentEmail = "Agent3@gmail.com",
                AgentPhone = "0995514212",
                AgentAddress = "Agent 3 Address"
            });
        }
    }
}
