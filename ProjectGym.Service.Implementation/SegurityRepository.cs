using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Domain.Entities;
using ProjectGym.Domain.Repository;
using ProjectGym.Infraestructure;
using ProjectGym.Infraestructure.Repository;
using ProjectGym.Service.Interface;

namespace ProjectGym.Service.Implementation
{
    public class SegurityRepository : ISegurityRepository
    {

        private readonly DataContext _context;

        public SegurityRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Login(string username, string password)
        {
            return await _context.Employees.AnyAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<bool> VerifyExists(string username)
        {
            return await _context.Employees.AnyAsync(x => x.Username == username);
        }
    }
}
