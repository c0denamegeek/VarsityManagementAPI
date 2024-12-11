using AutoMapper;
using VarsityManagementAPI.Data;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Repositories
{
    public class ModuleRepository : IModule
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ModuleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateModule(Module module)
        {
            if (module == null)
            {
                return false;
            }
            _context.Modules.Add(module);
            _context.SaveChanges();
            return true;
        }

        public Module GetModule(int id)
        {
            return _context.Modules.Where(c => c.ModuleId == id).FirstOrDefault();
        }

        public IEnumerable<Module> GetModules()
        {
            return _context.Modules.ToList();
        }

        public bool ModuleExists(string name)
        {
            return _context.Modules.Select(c => c.ModuleName == name).FirstOrDefault();
        }

        public bool ModuleExists(int id)
        {
            return _context.Modules.Any(c => c.ModuleId == id);
        }

        public bool UpdateModule(Module module)
        {
            _context.Modules.Update(module);
            _context.SaveChanges();
            return true;
        }
    }
}
