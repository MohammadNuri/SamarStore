﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}