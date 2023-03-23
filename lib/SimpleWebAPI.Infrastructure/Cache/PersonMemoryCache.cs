namespace SimpleWebAPI.Infrastructure.Cache
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Extensions.Caching.Memory;

    using SimpleWebAPI.Application.Common.Interfaces;

    public class PersonMemoryCache : IPersonMemoryCache
    {
        private readonly IMemoryCache _memoryCache;

        public string Key { get { return "persons"; } }

        public PersonMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public bool CreatePerson(string name, string address)
        {
            if (!PersonExists(name))
            {
                var users = SelectAllPersons();
                users.Add(name, address);
                SetAllPersons(users);
                return true;
            }

            return false;
        }

        public bool DeletePerson(string name)
        {
            if (PersonExists(name))
            {
                var users = SelectAllPersons();
                users.Remove(name);
                SetAllPersons(users);
                return true;
            }

            return false;
        }

        public bool PersonExists(string name)
        {
            var users = SelectAllPersons();
            return users.ContainsKey(name);
        }

        public IDictionary<string, string> SelectAllPersons()
        {
            return _memoryCache.Get<IDictionary<string, string>>(Key) ?? new Dictionary<string, string>();
        }

        public void SetAllPersons(IDictionary<string, string> persons)
        {
            _memoryCache.Set(Key, persons);
        }

        public bool UpdatePerson(string name, string address)
        {
            if (PersonExists(name))
            {
                var users = SelectAllPersons();
                users[name] = address;
                SetAllPersons(users);
                return true;
            }

            return false;
        }
    }
}
