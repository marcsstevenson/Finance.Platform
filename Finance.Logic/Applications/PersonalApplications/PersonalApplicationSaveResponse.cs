using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Finance.Logic.Shared;
using Generic.Framework.Interfaces;

namespace Finance.Logic.Applications.PersonalApplications
{public class PersonalApplicationSaveResponse
    {
        public Guid? PersistedId { get; set; }
        
    }
}
