# LoanApplications
Loan Applicaiton 
You will create a solution containing three projects:
Asp.Net MVC application (can be dot net core) – Create an application that will display a list of loan applicants. The application will have the following screens –
1. List of all applicants – A tabular list of loan applications. This list will allow me to edit or delete an entry. Delete will prompt a modal confirmation. Use of standard JS alert/confirmation is acceptable. As a bonus, seed the database with a thousand sample records at startup.
2. create/edit screen – the create/edit workflow will consist of the following 3 pages –
• Personal information page, tied to the demographic model in the shared lib project.
• Business Information page, tied to the business model in the shared lib project.
• Loan Application page, tied to the loan application model in the shared lib project.
You will implement a workflow with client side and server-side validations and will display proper validation error messages. You will allow the user to go forward and backward and display information that they had previously entered. You may elect to store information in a cache or to the database as they navigate through the pages. You do not need to spend time prettying up the pages using Bootstrap. You are not being graded on the aesthetic look and feel. You are being graded on the functionality and overall design choices. You will have a “submit” button on the final page that will save the loan information to the database.
3. search screen that allows searching by standard search parameters (name, id, etc) – the search screen will allow a user to search by different criteria (hint create indexes on your tables). The criteria should not be limited only to the demographic table. You should allow the user to search by applicant name, requested loan amounts (range or absolute amount), business name, credit rating, etc
The Controller methods will call the microservice. Use HttpClient and Dependency Injection.
Web Api – Create a microservice (dot net core ok) that will provide CRUD plus search operations to support the Asp.Net MVC application. You do not need to secure the controller. You will use Entity Framework with a local sql db instance. You may use database first or model first approach. Bonus points for using generics and design patterns to implement a generic repository class to perform CRUD operations.
Shared Class Library – provide whatever models are necessary to support the Asp.Net MVC application. This class lib will be shared by both the web api and asp.net app. At a minimum there will be a demographic model to support loan applicant personal information; a business model to support business info and a loan model that will contain properties that will hold loan application properties such as amount of loan requested, number of months to payback, some random APR rate that is between 4 and 12 percent (you will show this to the loan applicant on the loan application page), some random credit rating number that is between 600 and 750 (not shown in loan application page), a random (and optional) number that indicates number of defaults / late loan payments in the past 5 years (not shown in loan application page), total outstanding debt (random number between 25000 and 1,000,000) and finally a risk rating that is calculated using credit rating number (not shown in loan application page), number of defaults and outstanding debt (not shown in loan application page). There
.Net Exercise
pg. 2
is no set formula to calculate this. I would like to see some innovative way that you perform this
calculation. The properties of each model are left up to the discretion of the candidate.
To reiterate, the final application does not need to look pretty. It does need to be completely functional.
I do not need to see a secure microservice controller methods, but I do want to see use of design
patterns and EF (Core). I do not have any preconceived notions of what kind of information needs to be
stored and displayed, but I will look for how you analyse domain information. Do your research.
