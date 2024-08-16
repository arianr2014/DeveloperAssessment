# Developer Assessment<br/>
AREYES
<br/>
Back-End Developer Assessment
<br/>
Run the EF Migrations to create Database and Tables
<br/>
<br/>
From the command line, navigate to the Data project directory and run the following commands to create the database and tables:
<br/><br/>
dotnet ef migrations add InitialCreate --startup-project ../AreyesAssessment.Api
<br/>
<br/>
dotnet ef database update --startup-project ../AreyesAssessment.Api
