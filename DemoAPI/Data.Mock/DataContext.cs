﻿using Data.Mock.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mock
{
    public class DataContext
    {
        private List<Person> _people;
        private List<Company> _companies;
        private List<History> _histories;

        public List<Person> People
        {
            get
            {
                if (_people == null)
                {
                    _people = new List<Person>();
                    _people.Add(new Person
                    {
                        Id = 123456,
                        Forename = "David",
                        Surname = "Exampleson",
                        Email = "david@example.com",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678",
                        JobTitle = "Shopfloor Assistant",
                        CompanyId = 876432
                    });
                    _people.Add(new Person
                    {
                        Id = 999324,
                        Forename = "Barry",
                        Surname = "Banana",
                        Email = "barry@example.com",
                        TelephoneNumber = "01449123825",
                        MobileNumber = "07519123724",
                        JobTitle = "Bishop",
                        CompanyId = 123459
                    });
                    _people.Add(new Person
                    {
                        Id = 666345,
                        Forename = "Amanda",
                        Surname = "Apricot",
                        Email = "amanda@example.com",
                        TelephoneNumber = "013457432",
                        MobileNumber = "07519123635",
                        JobTitle = "Clerk",
                        CompanyId = 123452
                    });
                }

                return _people;
            }

        }

        public List<Company> Companies
        {
            get
            {
                if (_companies == null)
                {
                    _companies = new List<Company>();
                    _companies.Add(new Company
                    {
                        Id = 876432,
                        CompanyName = "ABC Plumbing",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678"
                    });
                    _companies.Add(new Company
                    {
                        Id = 213483,
                        CompanyName = "Testing Ltd",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678"
                    });
                    _companies.Add(new Company
                    {
                        Id = 123459,
                        CompanyName = "Example Company",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678"
                    });
                    _companies.Add(new Company
                    {
                        Id = 123452,
                        CompanyName = "Carefree Cars",
                        TelephoneNumber = "01449784213",
                        MobileNumber = "075194312678"
                    });
                }

                return _companies;
            }
        }
        public List<History> Histories
        {
            get
            {
                if (_histories == null)
                {
                    _histories = new List<History>();
                    _histories.Add(new History
                    {

                        Id = 678432,
                        LinkId = 876432,
                        LinkType = "Company",
                        Description = "Company Created",
                        TimeStamp = new DateTime(2017, 01, 01)
                    });
                    _histories.Add(new History
                    {

                        Id = 678432,
                        LinkId = 876432,
                        LinkType = "Company",
                        Description = "Company Name changed from \"Previous Company Name\" to \"ABC Plumbing\"",
                        TimeStamp = new DateTime(2018, 01, 01)
                    });
                    _histories.Add(new History
                    {

                        Id = 678432,
                        LinkId = 876432,
                        LinkType = "Company",
                        Description = "Telephone number changed",
                        TimeStamp = new DateTime(2019, 01, 01)
                    });
                }

                return _histories;
            }
        }
    }
}
