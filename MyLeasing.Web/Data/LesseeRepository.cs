﻿using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entity;
using System.Linq;

namespace MyLeasing.Web.Data
{
    public class LesseeRepository : GenericRepository<Lessee>, ILesseeRepository
    {
        private readonly DataContext _context;

        public LesseeRepository(DataContext context) : base (context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Lessee.Include(l => l.User);
        }
    }
}
