# IPS_API
 
Created Backend Part.
-----------------------
1. Entity Framework Core Code First
2. New Models Created, relationships
	1. AccountType 
	2. AssociatedIndividual
	3. PersonalAccount
	4. CorporateAccount
	5. CompanyOfficer
3. DB Context Created
4. Service Layer Created for Business Logic
	1. PersonalAccountService
	2. CorporateAccountService
	3. AccountTypeService
5. Injected DB Context at Service, Configured the same at Startup.cs, Also Configured db at appsetting.json
6. Injected Services at API Controllers and configured the same at Startup.cs
7. Services URL : 
	1. To Add Personal Account    : http://localhost:65128/api/PersonalAccount/AddPersonalAccount
	2. Get all Personal Accounts  : http://localhost:65128/api/PersonalAccount
	3. To Add Corporate Account   : http://localhost:65128/api/CorporateAccount/AddCorporateAccount
	4. Get all Corporate Accounts : http://localhost:65128/api/CorporateAccount
	5. Get all Account Types      : http://localhost:65128/api/AccountType 
8. UnitTest Case : Unit Test Case to test insert / select using mock data framework.

