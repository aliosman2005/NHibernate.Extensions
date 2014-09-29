﻿using System.Collections.Generic;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace NHibernate.Extensions.Tests.Entities
{
    public partial class EQBPerson : Entity
    {
        public EQBPerson()
        {
            CurrentOwnedVehicles = new HashSet<EQBVehicle>();
            OwnedHouses = new HashSet<EQBHouse>();
            PreviouslyOwnedVehicles = new HashSet<EQBVehicle>();

        }

        public virtual string Name { get; set; }

        public virtual string LastName { get; set; }

        public virtual int Age { get; set; }

        #region OneToMany

        public virtual ISet<EQBVehicle> CurrentOwnedVehicles { get; set; }

        #endregion

        #region ManyToMany

        public virtual ISet<EQBHouse> OwnedHouses { get; set; }

        public virtual ISet<EQBVehicle> PreviouslyOwnedVehicles { get; set; }

        #endregion

        #region ManyToOne

        public virtual EQBPerson BestFriend { get; set; }

        #endregion

        #region OneToOne

        public virtual EQBPerson MarriedWith { get; set; }

        public virtual EQBDrivingLicence DrivingLicence { get; set; }

        public virtual EQBIdentityCard IdentityCard { get; set; }

        #endregion

    }

    public class EQBPersonMapping : IAutoMappingOverride<EQBPerson>
    {
        public void Override(AutoMapping<EQBPerson> mapping)
        {
            mapping.HasMany(o => o.CurrentOwnedVehicles).KeyColumn("CurrentOwnerId");
            mapping.HasManyToMany(o => o.PreviouslyOwnedVehicles);
            mapping.HasManyToMany(o => o.OwnedHouses);
        }
    }
}