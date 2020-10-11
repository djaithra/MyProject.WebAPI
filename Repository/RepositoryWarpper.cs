using MyProject.Contracts;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Repository
{
    public class RepositoryWarpper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IEmployeeRepository _employee;
        
        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }        
        public RepositoryWarpper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
