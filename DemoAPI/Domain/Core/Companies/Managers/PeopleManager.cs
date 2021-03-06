﻿using Data.Mock;
using Domain.Areas.People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Areas.Companies.Managers
{
    public class PeopleManager
    {
        private readonly DataContext dc;

        public PeopleManager()
        {
            dc = new DataContext();
        }

        public IEnumerable<PersonDetailsModel> GetIndexModel(long companyId, PersonSearchModel search)
        {
            var company = dc.Companies.Find(X => X.Id == companyId);

            if (company == null)
            {
                throw new KeyNotFoundException();
            }
            else {
                var items = dc.People.AsQueryable().Where(X => X.CompanyId == company.Id);

                if (search != null)
                {
                    if (!string.IsNullOrEmpty(search.Term))
                    {
                        var words = search.Term.ToUpper().Split(" ");

                        foreach (string word in words)
                        {
                            items = items.Where(X => X.Forename.ToUpper().Contains(word) ||
                                X.Surname.ToUpper().Contains(word) ||
                                X.MobileNumber.ToUpper().Contains(word) ||
                                X.TelephoneNumber.ToUpper().Contains(word) ||
                                X.Email.ToUpper().Contains(word) ||
                                X.JobTitle.ToUpper().Contains(word));
                        }
                    }
                }

                var response = new List<PersonDetailsModel>();

                foreach (var item in items)
                {
                    response.Add(new PersonDetailsModel
                    {
                        PersonId = item.Id,
                        Forename = item.Forename,
                        Surname = item.Surname,
                        TelephoneNumber = item.TelephoneNumber,
                        MobileNumber = item.MobileNumber,
                        Email = item.Email,
                        JobTitle = item.JobTitle
                    });
                }

                return response; 
            }
        }

        public PersonDetailsModel GetDetailsModel(long companyId, long id)
        {
            var company = dc.Companies.Find(X => X.Id == companyId);

            if (company == null)
            {
                return null;
            }
            else
            {
                var item = dc.People.Find(X => X.Id == id);
                if (item == null)
                {
                    return null;
                }
                else
                {
                    return new PersonDetailsModel
                    {
                        PersonId = item.Id,
                        Forename = item.Forename,
                        Surname = item.Surname,
                        TelephoneNumber = item.TelephoneNumber,
                        MobileNumber = item.MobileNumber,
                        Email = item.Email,
                        JobTitle = item.JobTitle,
                    };
                }
            }
        }
    }
}
