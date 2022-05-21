using Microsoft.AspNetCore.Mvc;
using StudentNotes.Application.IRepositories;
using StudentNotes.Core.Entities;

namespace StudentNotes.API.Controllers
{
    public class TeachersController : Controller
    {
        private readonly IGenericRepository<Teacher> _teachersRepository;

        public TeachersController(IGenericRepository<Teacher> teachersRepository)
        {
            this._teachersRepository = teachersRepository;
        }
    }
}
