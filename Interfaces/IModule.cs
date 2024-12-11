using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Interfaces
{
    public interface IModule
    {
        IEnumerable<Module> GetModules();
        Module GetModule(int id);
        bool CreateModule(Module module);
        bool UpdateModule(Module module);
        bool ModuleExists(string name);
        bool ModuleExists(int id);
    }
}
