﻿using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync (int id);
        Task<List<Student>> GetAllAsync();
    }
}
