﻿using Rest414Test.Dto;
using Rest414Test.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest414Test.Resources
{
    public class LockedUserResource : RestQueries<SimpleEntity, SimpleEntity, SimpleEntity, SimpleEntity>
    {


        public LockedUserResource() : base(RestUrlRepository.GetLockedUser())
        {

        }

    }
    
}
