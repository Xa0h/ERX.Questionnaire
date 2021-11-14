ERX Questionnaire Test

Tech Stack :
1. Dot Net Core WebAPi
2. Sql Server
3. XUnit
4. FluentValidations
5. Dependency Injection
6. EF Core
7. Closed XML
8. Swagger

How to Run?

1. Run Sql Server Script from "ERX Sql Scripts.sql" file
2. Run the ERX.Questionnaire.Api Project
3. Endpoints :  

A. Questionnaire

GET
​/api​/Questionnaire​/v1​/GetGroups -- Questions are divided into 3 groups "Personal/Address/Occupation"

GET
​/api​/Questionnaire​/v1​/GetQuestions -- Pass GroupId to fetch Question list

GET
​/api​/Questionnaire​/v1​/GetApplicationStatus -- Get Application State if user has an incomplete application

GET
​/api​/Questionnaire​/v1​/GetQuestionnaireByUserId -- Get A full retrieved user application

GET
​/api​/Questionnaire​/v1​/DownloadQuestionnaireReport -- Download a list of questionnaire submitted by a user by date into an excel
 
POST
​/api​/Questionnaire​/v1​/AddQuestion -- Backoffice Functionality to Add a new Question

POST
​/api​/Questionnaire​/v1​/EditQuestion -- Backoffice Functionality to Edit a existing Question

POST
​/api​/Questionnaire​/v1​/DeleteQuestion -- -- Backoffice Functionality to Delete existing Question


B. User

GET
​/api​/User​/v1​/Country​/Get --Get a list of Countries

POST
​/api​/User​/v1​/AddPersonalInfo - Add Personal Info for a user

POST
​/api​/User​/v1​/AddAddress -- Add Address (Home and Work)

POST
​/api​/User​/v1​/AddWorkInfo -- Add Occupation Details