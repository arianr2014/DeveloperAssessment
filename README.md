# Developer Assessment
# Developer Assessment
AREYES
<br/>
Back-End Developer Assessment
<br/>
Run the EF Migrations
<br/>
From the command line, navigate to the Data project directory and run the following commands to create the database and tables:
<br/>
dotnet ef migrations add InitialCreate --startup-project ../AreyesAssessment.Api
dotnet ef database update --startup-project ../AreyesAssessment.Api
