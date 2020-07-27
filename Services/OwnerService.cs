using Microsoft.EntityFrameworkCore;
using RaceSimulator.Data;
using RaceSimulator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaceSimulator.Services
{
    public interface IOwnerService
    {
        int CreateOwner(Owner owner);
        Owner GetOwner(int id);
        ICollection<Owner> GetOwners();
        Owner UpdateOwner(Owner owner);
        void DeleteOwner(int id);
    }
    class OwnerService : IOwnerService
    {
        private readonly AppDbContext _context; //jako pole czy wlasciwosc

        public OwnerService(AppDbContext context)
        {
            _context = context;
        }

        public int CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner.Id;
        }
        public Owner GetOwner(int id)
        {
            var owner = _context.Owners.Include(owner => owner.Cars).Include(owner => owner.Drivers)
                .SingleOrDefault(owner => owner.Id == id);
            if (owner == null)
            {
                throw new Exception("Car not found");
            }
            return owner;
        }
        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.Include(owner => owner.Cars).Include(owner => owner.Drivers).ToList<Owner>();
        }
       
        public Owner UpdateOwner(Owner ownerParam)
        {
            var owner = _context.Owners.SingleOrDefault(owner => owner.Id == ownerParam.Id);
            owner.Name = ownerParam.Name;
            if (owner == null)
                throw new Exception("Owner not found");

            _context.Owners.Update(owner);
            _context.SaveChanges();
            return owner;
        }
        public void DeleteOwner(int id)
        {
            var owner = _context.Owners.SingleOrDefault(owner => owner.Id == id);
            if (owner != null)
            {
                _context.Owners.Remove(owner);
                _context.SaveChanges();
            }
        }
    }
}
