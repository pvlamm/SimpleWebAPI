namespace SimpleWebAPI.Application.Common.Interfaces
{
    using System.Collections.Generic;

    using SimpleWebAPI.Domain.Entities;

    public interface IPersonMemoryCache
    {
        string Key { get; }
        bool PersonExists(string name);
        bool CreatePerson(string name, string address);
        bool UpdatePerson(string name, string address);
        bool DeletePerson(string name);
        IDictionary<string, string> SelectAllPersons();
        void SetAllPersons(IDictionary<string, string> persons);
    }
}
