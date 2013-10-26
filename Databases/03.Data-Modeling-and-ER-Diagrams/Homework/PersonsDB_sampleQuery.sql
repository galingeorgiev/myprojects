use PersonsDB
select First_name, Last_name, Address_text from Persons
join Addresses on Persons.PersonID = Addresses.AddressID